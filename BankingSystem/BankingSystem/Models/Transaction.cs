using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using BankingSystem.Enums;

namespace BankingSystem.Models
{
    public class Transaction
    {
        [Key]
        public int TransactionID { get; set; }

        [ForeignKey("Account")]
        [Required]
        public int AccountID { get; set; }

        [ForeignKey("UserDetail")]
        [Required]
        public int UserID { get; set; }

        [Required]
        [EnumDataType(typeof(TransactionTypeEnum), ErrorMessage = "Invalid Transaction Type")]
        public TransactionTypeEnum TransactionType { get; set; } 

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Transaction amount must be greater than 0.")]
        public decimal Amount { get; set; }

        [Required]
        public DateTime Timestamp { get; set; }

        [AllowNull]
        public int? FromAccountID { get; set; }

        [AllowNull]
        public int? ToAccountID { get; set; }

        public Account? Account { get; set; }
        public Account? FromAccount { get; set; }
        public Account? ToAccount { get; set; }
        public UserDetail UserDetail { get; set; }
    }
}
