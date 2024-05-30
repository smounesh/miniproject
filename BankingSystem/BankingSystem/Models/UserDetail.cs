using BankingSystem.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BankingSystem.Models
{
    public class UserDetail
    {
        [Key]
        public int UserID { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Username cannot be longer than 100 characters.")]
        public string Username { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        [EnumDataType(typeof(UserStatusEnum), ErrorMessage = "Invalid Transaction Type")]
        public UserStatusEnum Status { get; set; }

        [Required]
        [Phone(ErrorMessage = "Invalid Phone Number")]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "Address cannot be longer than 200 characters.")]
        public string Address { get; set; }

        public ICollection<Account> Accounts { get; set; }
        public ICollection<Loan> Loans { get; set; }
        public ICollection<Transaction> Transactions { get; set; }
    }
}
