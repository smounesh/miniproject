namespace BankingSystem.Models.DTO_s
{
    public class LoanDTO
    {
        public int LoanID { get; set; }
        public int UserID { get; set; }
        public decimal Amount { get; set; }
        public decimal InterestRate { get; set; }
        public int Term { get; set; }
        public string Status { get; set; }
    }
}
