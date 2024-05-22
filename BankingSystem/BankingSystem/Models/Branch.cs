using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BankingSystem.Models
{
    public class Branch
    {
        [Key]
        public int BranchID { get; set; }

        [Required]
        public string BranchName { get; set; }

        [Required]
        public string Location { get; set; }

        public ICollection<Account> CreatedAccounts { get; set; }
        public ICollection<Account> HomeAccounts { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
