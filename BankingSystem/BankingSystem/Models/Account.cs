using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankingSystem.Models
{
    public class Account
    {
        [Key]
        public int AccountID { get; set; }

        [ForeignKey("User")]
        public int UserID { get; set; }

        [Required]
        public string AccountType { get; set; }

        [Required]
        public decimal Balance { get; set; }

        [Required]
        public string Status { get; set; }  // Account status (Active, Closed, etc.)

        [ForeignKey("CreatedBranch")]
        public int AccountCreatedBranch { get; set; }

        [ForeignKey("HomeBranch")]
        public int CurrentHomeBranch { get; set; }

        public User User { get; set; }
        public Branch CreatedBranch { get; set; }
        public Branch HomeBranch { get; set; }
        public ICollection<Transaction> Transactions { get; set; }
    }
}
