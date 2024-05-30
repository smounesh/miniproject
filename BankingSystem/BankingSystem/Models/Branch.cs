using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BankingSystem.Models
{
    public class Branch
    {
        [Key]
        public int BranchID { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Branch name cannot be longer than 100 characters.")]
        public string BranchName { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "Location cannot be longer than 200 characters.")]
        public string Location { get; set; }
    }
}
