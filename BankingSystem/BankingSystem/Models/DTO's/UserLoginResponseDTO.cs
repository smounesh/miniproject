using System.ComponentModel.DataAnnotations;

namespace BankingSystem.Models.DTO_s
{
    public class UserLoginResponseDTO
    {
        [Range(1, int.MaxValue, ErrorMessage = "UserId must be a positive number")]
        public int UserId { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Username cannot be longer than 100 characters.")]
        public string Username { get; set; }

        [Required]
        public string Role { get; set; }

        [Required]
        public string Token { get; set; }
    }
}