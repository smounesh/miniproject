namespace BankingSystem.Models.DTO_s
{
    public class PasswordResetDTO
    {
        public string Username { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
