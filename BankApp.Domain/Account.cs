using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankApp.Domain.Enum;

//-Account(Id, UserId, AccountNumber, Balance, AccountType, CreatedDate)

namespace BankApp.Domain
{
    public class Account
    {
        public int ID { get; set; }
        public string UserId { get; set; }=string.Empty;
        public User User { get; set; }
        public long AccountNumber { get; set; }
        public decimal Balance { get; set; }
        public AccountTypes AccountTypes { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
