using System.ComponentModel.DataAnnotations;
using BankingSystem.Enums;

namespace BankingSystem.Models.DTO_s
{
    public class LoanDTO
    {
        [Range(1, int.MaxValue, ErrorMessage = "LoanID must be a positive number")]
        public int LoanID { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "UserID must be a positive number")]
        public int UserID { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "AccountID must be a positive number")]
        public int AccountID { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Amount must be a positive number")]
        public decimal Amount { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "InterestRate must be a positive number")]
        public decimal InterestRate { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Term must be a positive number")]
        public int Term { get; set; }

        [Required]
        [EnumDataType(typeof(LoanStatusEnum), ErrorMessage = "Invalid Status")]
        public LoanStatusEnum Status { get; set; }
    }
}
