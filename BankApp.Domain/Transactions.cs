﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankApp.Domain.Enum;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Text.Json.Serialization;

//-Transaction(Id, AccountId, Type, Amount, Date, Description)
namespace BankApp.Domain
{
    public class Transactions
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int AccountId { get; set; }
        [JsonIgnore]
        [ForeignKey("AccountId")]
        public Accounts? Accounts { get; set; }
        [Required]
        public TransactionTypes TransactionType { get; set; }
        [Required]
        public decimal Amount { get; set; }
        [Required]
        public DateTime Date { get; set; }

        // Stores additional details about the transaction
        [Required]
        public string Description { get; set; }



    }
}
