using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using BankApp.Domain.Enum;


//-Account(Id, UserId, AccountNumber, Balance, AccountType, CreatedDate)

namespace BankApp.Domain
{
    public class Accounts
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        public string UserId { get; set; } = string.Empty;
        
        [Required]
        //[MinLength(10,ErrorMessage ="Account number must be 10 digit!!!")]
        public long AccountNumber { get; set; }
        [Required]
        public decimal Balance { get; set; }
        [Required]
        public AccountTypes AccountTypes { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }= DateTime.Now;
        [Required]
        public int IsDelete { get; set; }
        [JsonIgnore]

        public ICollection<Transactions>? Transactions { get; set; }
    }
}
