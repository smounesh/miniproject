using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BankingSystem.Enums;

namespace BankingSystem.Models
{
    public class Loan
    {
        [Key]
        public int LoanID { get; set; }

        [Required]
        public int UserID { get; set; }

        [Required]
        public int AccountID { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Loan amount must be greater than 0.")]
        public decimal Amount { get; set; }

        [Required]
        [Range(0.01, 100.00, ErrorMessage = "Interest rate must be between 0.01 and 100.")]
        public decimal InterestRate { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Loan term must be at least 1 month.")]
        public int Term { get; set; }

        [Required]
        [EnumDataType(typeof(LoanStatusEnum), ErrorMessage = "Invalid Status")]
        public LoanStatusEnum Status { get; set; }


        [ForeignKey("UserID")]
        public UserDetail UserDetail { get; set; }

        [ForeignKey("AccountID")]
        public Account Account { get; set; }
    }
}
