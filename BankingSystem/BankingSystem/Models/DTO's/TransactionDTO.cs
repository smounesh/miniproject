using System.ComponentModel.DataAnnotations;
using BankingSystem.Enums;

namespace BankingSystem.Models.DTO_s
{
    public class TransactionDTO
    {
        [Range(1, int.MaxValue, ErrorMessage = "TransactionID must be a positive number")]
        public int TransactionID { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "AccountID must be a positive number")]
        public int AccountID { get; set; }

        [Required]
        [EnumDataType(typeof(TransactionTypeEnum), ErrorMessage = "Invalid Transaction Type")]
        public TransactionTypeEnum TransactionType { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Amount must be a positive number")]
        public decimal Amount { get; set; }

        [Required]
        public System.DateTime Timestamp { get; set; }

        public int? FromAccountID { get; set; }
        public int? ToAccountID { get; set; }
    }
}