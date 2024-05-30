using System.ComponentModel.DataAnnotations;
using BankingSystem.Enums;

namespace BankingSystem.Models.DTO_s
{
    public class EmployeeLoginResponseDTO
    {
        [Range(1, int.MaxValue, ErrorMessage = "EmployeeID must be a positive number")]
        public int EmployeeID { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "EmployeeName length can't be more than 100.")]
        public string EmployeeName { get; set; }

        [Required]
        [EnumDataType(typeof(EmployeeRoleEnum), ErrorMessage = "Invalid Role")]
        public EmployeeRoleEnum Role { get; set; }


        [Required]
        public string Token { get; set; }
    }
}
