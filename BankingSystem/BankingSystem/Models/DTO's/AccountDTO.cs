using BankingSystem.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BankingSystem.Models.DTO_s
{
    public class AccountDTO
    {
        [Range(1, int.MaxValue, ErrorMessage = "AccountNo must be a positive number")]
        public int AccountNo { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "UserID must be a positive number")]
        public int UserID { get; set; }

        [Required]
        [EnumDataType(typeof(AccountTypeEnum), ErrorMessage = "Invalid Account Type")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public AccountTypeEnum AccountType { get; set; }

        [Required]
        [EnumDataType(typeof(AccountStatusEnum), ErrorMessage = "Invalid Account Status")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public AccountStatusEnum Status { get; set; }


        [Range(1, int.MaxValue, ErrorMessage = "AccountCreatedBranch must be a positive number")]
        public int AccountCreatedBranch { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "CurrentHomeBranch must be a positive number")]
        public int CurrentHomeBranch { get; set; }
    }
}