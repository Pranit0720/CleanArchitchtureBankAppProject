using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankApp.Domain.Enum;

namespace BankApp.Application.ViewModels.TransactionViewModel
{
    public class TransactionAddModel
    {
        [Required]
        public TransactionTypes TransactionType { get; set; }
        [Required]
        public decimal Amount { get; set; }
        // Stores additional details about the transaction
        [Required]
        public string Description { get; set; }
    }
}
