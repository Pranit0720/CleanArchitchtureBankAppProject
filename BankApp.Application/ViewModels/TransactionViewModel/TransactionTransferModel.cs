using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Application.ViewModels.TransactionViewModel
{
    public class TransactionTransferModel
    {
        [Required]
        public long AccountNumber { get; set; }
        [Required]
        public decimal Amount { get; set; }
    }
}
