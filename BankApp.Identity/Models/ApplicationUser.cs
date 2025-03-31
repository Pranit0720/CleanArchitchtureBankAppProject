using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankApp.Domain;

//using BankApp.Domain;
using Microsoft.AspNetCore.Identity;

namespace BankApp.Identity.Models
{
    public class ApplicationUser:IdentityUser
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        public ICollection<Accounts> Accounts { get; set; }
    }
}
