using AutoMapper;
using BankingSystem.Models;
using BankingSystem.Models.DTO_s;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        //mappings for UserLoginDTO, UserRegisterDTO, UserResetPasswordDTO, and UserLoginResponseDTO
        CreateMap<UserLoginDTO, User>();
        CreateMap<UserRegisterDTO, User>();
        CreateMap<UserResetPasswordDTO, User>();
        CreateMap<User, UserLoginResponseDTO>();


        //mappings for Employee DTOs
        CreateMap<Employee, EmployeeDTO>();
        CreateMap<EmployeeDTO, Employee>();
        CreateMap<EmployeeLoginDTO, Employee>();
        CreateMap<Employee, EmployeeLoginResponseDTO>();
        CreateMap<EmployeeUpdateDTO, Employee>();
        CreateMap<EmployeeRegisterDTO, Employee>();
        CreateMap<EmployeeUpdateRoleDTO, Employee>();
        CreateMap<EmployeeUpdateStatusDTO, Employee>();

        //mapping for Branch DTO
        CreateMap<Branch, BranchDTO>();
        CreateMap<BranchDTO, Branch>();

        //mappings for User DTOs
        CreateMap<UserDetailCreateDTO, User>();

        //mappings for Account DTOs
        CreateMap<AccountCreateDTO, Account>();
        CreateMap<Account, AccountDTO>();
        CreateMap<AccountDTO, Account>();

        //mappings for UserDetail DTOs
        CreateMap<UserDetailCreateDTO, UserDetail>();
        CreateMap<UserDetailUpdateDTO, UserDetail>();
        CreateMap<UserDetail, UserDetailUpdateDTO>();

        //mappings for Account DTOs
        CreateMap<AccountCreateDTO, Account>();
        CreateMap<AccountUpdateDTO, Account>();
        CreateMap<Account, AccountUpdateDTO>();

        //mappings for UserDetail DTOs
        CreateMap<UserDetail, UserDetailDTO>();
        CreateMap<UserDetailDTO, UserDetail>();
        //CreateMap<Account, AccountDTO>()
        //    .ForMember(dest => dest.UserDetailDTO, opt => opt.MapFrom(src => src.UserDetail));

        //mappings for TransactionDTO
        CreateMap<Transaction, TransactionDTO>();
        CreateMap<TransactionDTO, Transaction>();

        //mappings for LoanDTO
        CreateMap<Loan, LoanDTO>();
        CreateMap<LoanDTO, Loan>();
    }
}
