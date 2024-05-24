namespace BankingSystem.Models.DTO_s
{
	public class EmployeeDTO
	{
		public int EmployeeID { get; set; }
		public int UserID { get; set; }
		public int BranchID { get; set; }
		public string Department { get; set; }
		public string JobTitle { get; set; }
		public User User { get; set; }
		public Branch Branch { get; set; }
	}
}
