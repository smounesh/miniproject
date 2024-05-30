using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using BankingSystem.Enums;

namespace BankingSystem.Models
{
    public class Account
    {
        [Key]
        [Required]
        public int AccountNo { get; set; }

        [ForeignKey("UserID")]
        [Required]
        public int UserID { get; set; }

        [Required]
        [EnumDataType(typeof(AccountTypeEnum), ErrorMessage = "Invalid Account Type")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public AccountTypeEnum AccountType { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Balance must be a positive number.")]
        public decimal Balance { get; set; }

        [Required]
        [EnumDataType(typeof(AccountStatusEnum), ErrorMessage = "Invalid Account Status")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public AccountStatusEnum Status { get; set; }

        [ForeignKey("CreatedBranch")]
        [Required]
        public int AccountCreatedBranch { get; set; }

        [ForeignKey("HomeBranch")]
        [Required]
        public int CurrentHomeBranch { get; set; }

        [JsonIgnore]
        public UserDetail UserDetail { get; set; }
        public Branch CreatedBranch { get; set; }
        public Branch HomeBranch { get; set; }
        [NotMapped]
        public ICollection<Transaction> Transactions { get; set; }
        public ICollection<Loan> Loans { get; set; }
    }
}
