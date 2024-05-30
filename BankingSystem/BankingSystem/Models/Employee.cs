using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using BankingSystem.Enums;

namespace BankingSystem.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Employee name cannot be longer than 100 characters.")]
        public string EmployeeName { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required]
        public byte[] PasswordHash { get; set; }

        [Required]
        public byte[] PasswordSalt { get; set; }

        [Required]
        [Phone(ErrorMessage = "Invalid Phone Number")]
        public string PhoneNumber { get; set; }

        [Required]
        [EnumDataType(typeof(EmployeeRoleEnum), ErrorMessage = "Invalid Role")]
        public EmployeeRoleEnum Role { get; set; }

        [Required]
        [EnumDataType(typeof(EmployeeStatusEnum), ErrorMessage = "Invalid Status")]
        public EmployeeStatusEnum Status { get; set; }


        [ForeignKey("Branch")]
        public int BranchID { get; set; }

        [Required]
        public string Department { get; set; }

        [Required]
        public string JobTitle { get; set; }

        [JsonIgnore]
        public Branch Branch { get; set; }
    }
}
