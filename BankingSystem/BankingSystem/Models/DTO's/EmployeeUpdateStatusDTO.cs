using System.ComponentModel.DataAnnotations;
using BankingSystem.Enums;

namespace BankingSystem.Models.DTO_s
{
    public class EmployeeUpdateStatusDTO
    {
        [Required]
        [EnumDataType(typeof(EmployeeStatusEnum), ErrorMessage = "Invalid Status")]
        public EmployeeStatusEnum Status { get; set; }

    }
}
