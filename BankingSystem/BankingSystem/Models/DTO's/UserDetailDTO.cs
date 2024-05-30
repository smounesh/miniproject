using System.ComponentModel.DataAnnotations;

namespace BankingSystem.Models.DTO_s
{
    public class UserDetailDTO
    {
        [Range(1, int.MaxValue, ErrorMessage = "UserID must be a positive number")]
        public int UserID { get; set; }

        [StringLength(100, ErrorMessage = "Username cannot be longer than 100 characters.")]
        public string Username { get; set; }

        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Phone(ErrorMessage = "Invalid Phone Number")]
        public string PhoneNumber { get; set; }

        [StringLength(200, ErrorMessage = "Address cannot be longer than 200 characters.")]
        public string Address { get; set; }
    }
}