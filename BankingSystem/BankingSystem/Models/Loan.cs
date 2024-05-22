using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankingSystem.Models
{
    public class Loan
    {
        [Key]
        public int LoanID { get; set; }

        [ForeignKey("User")]
        public int UserID { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public decimal InterestRate { get; set; }

        [Required]
        public int Term { get; set; }

        [Required]
        public string Status { get; set; }

        public User User { get; set; }
    }
}
