using System.ComponentModel.DataAnnotations;

namespace BankingSystem.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public byte[] PasswordHash { get; set; }
        [Required]
        public byte[] PasswordSalt { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Role { get; set; }
        [Required]
        public string AccountStatus { get; set; }

        public ICollection<Account> Accounts { get; set; }
        public ICollection<Loan> Loans { get; set; }
        public Employee Employee { get; set; }
    }
}
