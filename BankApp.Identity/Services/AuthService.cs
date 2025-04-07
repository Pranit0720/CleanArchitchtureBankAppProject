
using BankApp.Application.Interfaces.Identity;
using BankApp.Application.Models;
using BankApp.Identity.Models;
using Microsoft.AspNetCore.Identity;
using BankApp.Application.Exceptions;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Options;
using System.Text;

namespace BankApp.Identity.Services
{
    public class AuthService : IAuthService
    {
        readonly SignInManager<ApplicationUser> _signInManager;
        readonly UserManager<ApplicationUser> _userManager;
        readonly JwtSettings _jwtSettings;
        public AuthService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IOptions<JwtSettings> jwtSettings)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _jwtSettings = jwtSettings.Value;
        }

        public async Task<LoginResponse> Login(LoginRequest loginRequest)
        {
            var user = await _userManager.FindByEmailAsync(loginRequest.Email);
            if (user == null)
            {
                throw new NotFoundException($"user with Email {loginRequest.Email} not exists");
            }
            var userPassword = await _signInManager.CheckPasswordSignInAsync(user, loginRequest.Password, false);
            if (!userPassword.Succeeded)
            {
                throw new BadRequestException("password Credentials are wrong!!");
            }
            JwtSecurityToken jwtSecurityToken =await GenerateToken(user);

            var response = new LoginResponse()
            {
                Id = user.Id,
                Email = user.Email,
                UserName = user.UserName,
                Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken)


            };

            return response;

        }

        private async Task<JwtSecurityToken> GenerateToken(ApplicationUser user)
        {
            //Get  User Information
            var userClaim = await _userManager.GetClaimsAsync(user);
            //List of user roles
            var roles = await _userManager.GetRolesAsync(user);
            //Convert roles list into claim
            var roleClaims = roles.Select(x => new Claim(ClaimTypes.Role, x)).ToList();
            //create claim
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub,user.Email),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email,user.Email),
                new Claim("uid",user.Id.ToString()),
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString())


            }
            .Union(userClaim)
            .Union(roleClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var signInCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires:DateTime.Now.AddMinutes(_jwtSettings.DurationInMinutes),
                signingCredentials: signInCredentials
                );
            return jwtSecurityToken;
        }

        public async Task<RegisterResponse> Register(RegisterRequest registerRequest)
        {
            var user = new ApplicationUser
            {
                UserName = registerRequest.Email,
                Email = registerRequest.Email,
                FirstName = registerRequest.FirstName,
                LastName = registerRequest.LastName,
                EmailConfirmed = true
            };
            var result = await _userManager.CreateAsync(user, registerRequest.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "User");
                return new RegisterResponse()
                {
                    UserId = user.Id

                };
            }
            else
            {
                var errorResult = string.Join(", ", result.Errors.Select(e => e.Description));
                //var errorResult = result.Errors.Select(x => x.Description).ToList();
                throw new BadRequestException($"{errorResult}");
            }
        }
    }
}
