using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankApp.Domain.Enum;
using static System.Runtime.InteropServices.JavaScript.JSType;

//-Transaction(Id, AccountId, Type, Amount, Date, Description)
namespace BankApp.Domain
{
    public class Transaction
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public Account Account { get; set; }
        public TransactionTypes TransactionType { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }

        // Stores additional details about the transaction
        public string Description { get; set; }



    }
}
