using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankingSystem.Models
{
    public class Transaction
    {
        [Key]
        public int TransactionID { get; set; }

        [ForeignKey("Account")]
        public int AccountID { get; set; }

        [Required]
        public string Type { get; set; }  // Type of transaction (Deposit, Withdrawal, Transfer)

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public DateTime Timestamp { get; set; }

        public int? FromAccountID { get; set; }
        public int? ToAccountID { get; set; }

        public Account Account { get; set; }
        public Account FromAccount { get; set; }
        public Account ToAccount { get; set; }
    }
}
