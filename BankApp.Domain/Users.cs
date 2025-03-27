using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;


//User(Id, Name, Email, Password, Role)

namespace BankApp.Domain
{
    public class Users:IdentityUser
    {
        //public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        //public string Email { get; set; }   
        //public string Password { get; set; }
        //public string Role { get; set; }
        public ICollection<Accounts> Accounts { get; set; }
    }
}
