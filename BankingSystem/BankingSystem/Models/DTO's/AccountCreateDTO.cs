using System.ComponentModel.DataAnnotations;
using BankingSystem.Enums;

namespace BankingSystem.Models.DTO_s
{
    public class AccountCreateDTO
    {
        [Required]
        [EnumDataType(typeof(AccountTypeEnum), ErrorMessage = "Invalid Account Type")]
        public AccountTypeEnum AccountType { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "BranchID must be a positive number")]
        public int BranchID { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "UserID must be a positive number")]
        public int UserID { get; set; }
    }
}
