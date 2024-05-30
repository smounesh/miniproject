using System.ComponentModel.DataAnnotations;

namespace BankingSystem.Models.DTO_s
{
    public class EmployeeRegisterDTO
    {
        [Required]
        [StringLength(100, ErrorMessage = "EmployeeName length can't be more than 100.")]
        public string EmployeeName { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required]
        [Phone(ErrorMessage = "Invalid Phone Number")]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be between 6 and 100 characters.")]
        public string Password { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Department length can't be more than 100.")]
        public string Department { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "JobTitle length can't be more than 100.")]
        public string JobTitle { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "BranchID must be a positive number")]
        public int BranchID { get; set; }
    }
}