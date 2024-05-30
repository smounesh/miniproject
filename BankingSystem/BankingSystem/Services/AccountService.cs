using System;
using System.Threading.Tasks;
using AutoMapper;
using BankingSystem.Exceptions;
using BankingSystem.Models;
using BankingSystem.Models.DTO_s;
using BankingSystem.Repositories;
using BankingSystem.Repositories.Interfaces;
using BankingSystem.Services.Interfaces;
using Microsoft.Extensions.Logging;

namespace BankingSystem.Services
{
    public class AccountService : IAccountService
    {
        private readonly IRepository<Account> _accountRepository;
        private readonly IRepository<UserDetail> _userDetailRepository;
        private readonly IRepository<Branch> _branchRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public AccountService(IRepository<Account> accountRepository, IRepository<UserDetail> userDetailRepository, IMapper mapper, ILogger<AccountService> logger, IRepository<Branch> branchRepository)
        {
            _accountRepository = accountRepository;
            _userDetailRepository = userDetailRepository;
            _mapper = mapper;
            _logger = logger;
            _branchRepository = branchRepository;
        }

        public async Task CreateUserDetail(UserDetailCreateDTO userDetailCreateDTO)
        {
            if (userDetailCreateDTO == null || string.IsNullOrEmpty(userDetailCreateDTO.Username))
            {
                throw new UserDetailValidationException("UserDetail is invalid.");
            }
            var userDetail = _mapper.Map<UserDetail>(userDetailCreateDTO);
            await _userDetailRepository.Add(userDetail);
        }


        public async Task CreateAccount(AccountCreateDTO accountCreateDTO)
        {
            try
            {
                // Check if the branch exists
                var createdBranch = await _branchRepository.GetById(accountCreateDTO.BranchID);
                var homeBranch = await _branchRepository.GetById(accountCreateDTO.BranchID);
                if (createdBranch == null || homeBranch == null)
                {
                    _logger.LogError("Branch not found.");
                    throw new BranchNotFoundException(accountCreateDTO.BranchID);
                }

                var account = _mapper.Map<Account>(accountCreateDTO);
                account.CreatedBranch = createdBranch;
                account.HomeBranch = homeBranch;
                await _accountRepository.Add(account);
                _logger.LogInformation("Account created successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating Account.");
                throw;
            }
        }



        public async Task UpdateUserDetail(UserDetailUpdateDTO userDetailUpdateDTO)
        {
            try
            {
                var userDetail = await _userDetailRepository.GetById(userDetailUpdateDTO.UserID);
                if (userDetail == null)
                {
                    _logger.LogError("UserDetail not found.");
                    throw new Exception("UserDetail not found.");
                }

                _mapper.Map(userDetailUpdateDTO, userDetail);
                await _userDetailRepository.Update(userDetail);
                _logger.LogInformation("UserDetail updated successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating UserDetail.");
                throw;
            }
        }

        public async Task UpdateAccount(AccountUpdateDTO accountUpdateDTO)
        {
            try
            {
                var account = await _accountRepository.GetById(accountUpdateDTO.AccountNo);
                if (account == null)
                {
                    _logger.LogError("Account not found.");
                    throw new Exception("Account not found.");
                }

                _mapper.Map(accountUpdateDTO, account);
                await _accountRepository.Update(account);
                _logger.LogInformation("Account updated successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating Account.");
                throw;
            }
        }
        public async Task<IEnumerable<Account>> GetAllAccounts()
        {
            try
            {
                var accounts = await _accountRepository.GetAll();
                _logger.LogInformation("Retrieved all accounts successfully.");
                return accounts;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving all accounts.");
                throw;
            }
        }

        public async Task<IEnumerable<UserDetail>> GetAllUserDetails()
        {
            try
            {
                var userDetails = await _userDetailRepository.GetAll();
                _logger.LogInformation("Retrieved all user details successfully.");
                return userDetails;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving all user details.");
                throw;
            }
        }
        public async Task<Account> GetAccountById(int id)
        {
            try
            {
                var account = await _accountRepository.GetById(id);
                _logger.LogInformation("Retrieved account successfully.");
                return account;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving account.");
                throw;
            }
        }

        public async Task<UserDetail> GetUserDetailById(int id)
        {
            var userDetail = await _userDetailRepository.GetById(id);
            if (userDetail == null)
            {
                throw new UserDetailNotFoundException(id);
            }
            return userDetail;
        }

        public async Task EnableAccount(int accountId)
        {
            try
            {
                var account = await _accountRepository.GetById(accountId);
                if (account == null)
                {
                    _logger.LogError("Account not found.");
                    throw new Exception("Account not found.");
                }

                account.Status = 0; // Active
                await _accountRepository.Update(account);
                _logger.LogInformation("Account enabled successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error enabling account.");
                throw;
            }
        }

        public async Task DisableAccount(int accountId)
        {
            try
            {
                var account = await _accountRepository.GetById(accountId);
                if (account == null)
                {
                    _logger.LogError("Account not found.");
                    throw new Exception("Account not found.");
                }

                account.Status = (Enums.AccountStatusEnum)1; // Inactive
                await _accountRepository.Update(account);
                _logger.LogInformation("Account disabled successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error disabling account.");
                throw;
            }
        }

        public async Task CloseAccount(int accountId)
        {
            try
            {
                var account = await _accountRepository.GetById(accountId);
                if (account == null)
                {
                    _logger.LogError("Account not found.");
                    throw new Exception("Account not found.");
                }

                if (account.Balance != 0)
                {
                    _logger.LogError("Account balance is not zero.");
                    throw new Exception("Account balance must be zero to close the account.");
                }

                account.Status = (Enums.AccountStatusEnum)2; // Hold
                await _accountRepository.Update(account);
                _logger.LogInformation("Account closed successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error closing account.");
                throw;
            }
        }

    }
}
