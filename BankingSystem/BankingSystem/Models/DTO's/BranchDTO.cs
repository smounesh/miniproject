using System.ComponentModel.DataAnnotations;

namespace BankingSystem.Models.DTO_s
{
    public class BranchDTO
    {
        [Range(1, int.MaxValue, ErrorMessage = "BranchID must be a positive number")]
        public int BranchID { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "BranchName length can't be more than 100.")]
        public string BranchName { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "Location length can't be more than 200.")]
        public string Location { get; set; }
    }
}