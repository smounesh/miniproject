using System.ComponentModel.DataAnnotations;

namespace BankingSystem.Models.DTO_s
{
    public class UserLoginDTO
    {
        [Required]
        [StringLength(100, ErrorMessage = "Username cannot be longer than 100 characters.")]
        public string Username { get; set; }

        [Required]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$",
                    ErrorMessage = "Password must be minimum eight characters, at least one letter, one number and one special character.")]
        public string Password { get; set; }
    }
}