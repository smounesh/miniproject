using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankingSystem.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }

        [Required]
        public byte[] PasswordHash { get; set; }

        [Required]
        public byte[] PasswordSalt { get; set; }

        [ForeignKey("UserDetail")]
        [Required]
        public int UserDetailID { get; set; }

        public UserDetail? UserDetail { get; set; }
    }
}
