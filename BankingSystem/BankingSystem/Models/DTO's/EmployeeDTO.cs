﻿using System.ComponentModel.DataAnnotations;
using BankingSystem.Enums;

namespace BankingSystem.Models.DTO_s
{
    public class EmployeeDTO
    {
        [Range(1, int.MaxValue, ErrorMessage = "EmployeeID must be a positive number")]
        public int EmployeeID { get; set; }

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
        public Branch Branch { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Department length can't be more than 100.")]
        public string Department { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "JobTitle length can't be more than 100.")]
        public string JobTitle { get; set; }

        [Required]
        [EnumDataType(typeof(EmployeeRoleEnum), ErrorMessage = "Invalid Role")]
        public EmployeeRoleEnum Role { get; set; }

        [Required]
        [EnumDataType(typeof(EmployeeStatusEnum), ErrorMessage = "Invalid Status")]
        public EmployeeStatusEnum Status { get; set; }
    }
}