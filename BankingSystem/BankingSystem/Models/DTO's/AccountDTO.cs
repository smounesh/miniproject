namespace BankingSystem.Models.DTO_s
{
    public class AccountDTO
    {
        public int AccountID { get; set; }
        public int UserID { get; set; }
        public string AccountType { get; set; }
        public decimal Balance { get; set; }
        public string Status { get; set; }
        public int AccountCreatedBranch { get; set; }
        public int CurrentHomeBranch { get; set; }
    }
}
