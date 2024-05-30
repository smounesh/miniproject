using BankingSystem.Models.DTO_s;

namespace BankingSystem.Services.Interfaces
{
    public interface IAuthService
    {
        Task<UserLoginResponseDTO> Login(UserLoginDTO userLoginDTO);
        Task<bool> ResetPassword(UserResetPasswordDTO userResetPasswordDTO);
        Task<EmployeeLoginResponseDTO> EmployeeLogin(EmployeeLoginDTO employeeLoginDTO);
    }
}
