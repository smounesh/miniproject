using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankingSystem.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }

        [ForeignKey("User")]
        public int UserID { get; set; }

        [ForeignKey("Branch")]
        public int BranchID { get; set; }

        [Required]
        public string Department { get; set; }

        [Required]
        public string JobTitle { get; set; }

        public User User { get; set; }
        public Branch Branch { get; set; }
    }
}
