using System.ComponentModel.DataAnnotations;

namespace BankingSystem.Models.DTO_s
{
    public class AccountBalanceDTO
    {
        [Range(0, double.MaxValue, ErrorMessage = "Balance must be a positive number")]
        public decimal Balance { get; set; }
    }
}
