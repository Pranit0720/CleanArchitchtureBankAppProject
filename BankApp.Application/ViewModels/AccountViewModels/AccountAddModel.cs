using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankApp.Domain.Enum;

namespace BankApp.Application.ViewModels.AccountViewModels
{
    public class AccountAddModel
    {
        [Required]
        public long AccountNumber { get; set; }
        [Required]
        public decimal Balance { get; set; }
        [Required]
        public AccountTypes AccountTypes { get; set; }
    }
}
