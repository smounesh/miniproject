using System.ComponentModel.DataAnnotations;
using BankingSystem.Enums;

namespace BankingSystem.Models.DTO_s
{
    public class AccountUpdateDTO
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "AccountNo must be a positive number")]
        public int AccountNo { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "CurrentHomeBranch must be a positive number")]
        public int CurrentHomeBranch { get; set; }
    }
}