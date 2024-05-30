using System.ComponentModel.DataAnnotations;

namespace BankingSystem.Models.DTO_s
{
    public class UserResetPasswordDTO
    {
        [Required]
        [StringLength(100, ErrorMessage = "UsernameOrEmail cannot be longer than 100 characters.")]
        public string UsernameOrEmail { get; set; }

        [Required]
        [Phone(ErrorMessage = "Invalid Phone Number")]
        public string PhoneNumber { get; set; }

        [Required]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$",
                    ErrorMessage = "Password must be minimum eight characters, at least one letter, one number and one special character.")]
        public string NewPassword { get; set; }
    }
}