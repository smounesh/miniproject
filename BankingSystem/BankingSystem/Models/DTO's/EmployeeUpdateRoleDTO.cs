using System.ComponentModel.DataAnnotations;
using BankingSystem.Enums;

namespace BankingSystem.Models.DTO_s
{
    public class EmployeeUpdateRoleDTO
    {
        [Required]
        [EnumDataType(typeof(EmployeeRoleEnum), ErrorMessage = "Invalid Role")]
        public EmployeeRoleEnum Role { get; set; }
    }
}
