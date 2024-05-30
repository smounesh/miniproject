using AutoMapper;
using BankingSystem.Exceptions;
using BankingSystem.Models;
using BankingSystem.Models.DTO_s;
using BankingSystem.Repositories;
using BankingSystem.Services.Interfaces;
namespace BankingSystem.Services
{
    public class UserService : IUserService
    {
        private readonly UserRepository _userRepository;
        private readonly UserDetailRepository _userDetailRepository;
        private readonly TransactionRepository _transactionRepository;
        private readonly AccountRepository _accountRepository;
        private readonly LoanRepository _loanRepository;
        private readonly ILogger<UserService> _logger;
        private readonly IMapper _mapper;

        public UserService(UserRepository userRepository, UserDetailRepository userDetailRepository,  ILogger<UserService> logger, IMapper mapper, TransactionRepository transactionRepository, AccountRepository accountRepository, LoanRepository loanRepository)
        {
            _userRepository = userRepository;
            _userDetailRepository = userDetailRepository;
            _logger = logger;
            _mapper = mapper;
            _transactionRepository = transactionRepository;
            _accountRepository = accountRepository;
            _loanRepository = loanRepository;
        }

        public async Task<AccountBalanceDTO> GetAccountBalance(int accountId)
        {
            _logger.LogInformation($"Fetching balance for account {accountId}");

            var account = await _accountRepository.GetById(accountId);
            if (account == null)
            {
                _logger.LogWarning($"Account {accountId} not found");
                throw new AccountNotFoundException();
            }

            var accountBalanceDto = new AccountBalanceDTO
            {
                Balance = account.Balance
            };

            _logger.LogInformation($"Fetched balance for account {accountId}");

            return accountBalanceDto;
        }
        public async Task<IEnumerable<AccountDTO>> GetAccounts(int userId)
        {
            _logger.LogInformation($"Fetching accounts for user {userId}");

            var accounts = await _accountRepository.GetByUserId(userId);
            var accountDtos = _mapper.Map<IEnumerable<AccountDTO>>(accounts);

            _logger.LogInformation($"Fetched {accountDtos.Count()} accounts for user {userId}");

            return accountDtos;
        }
        public async Task<IEnumerable<LoanDTO>> GetLoanDetails(int userId)
        {
            _logger.LogInformation($"Fetching loan details for user {userId}");

            var loans = await _loanRepository.GetByUserId(userId);
            var loanDtos = _mapper.Map<IEnumerable<LoanDTO>>(loans);

            _logger.LogInformation($"Fetched {loanDtos.Count()} loan details for user {userId}");

            return loanDtos;
        }

        public async Task<IEnumerable<TransactionDTO>> GetTransactions(int accountId)
        {
            _logger.LogInformation($"Fetching transactions for account {accountId}");

            var transactions = await _transactionRepository.GetByAccountId(accountId);
            var transactionDtos = _mapper.Map<IEnumerable<TransactionDTO>>(transactions);

            _logger.LogInformation($"Fetched {transactionDtos.Count()} transactions for account {accountId}");

            return transactionDtos;
        }

        public async Task<UserDetailDTO> GetUserDetail(int userId)
        {
            _logger.LogInformation($"Fetching user details for user {userId}");

            var userDetail = await _userDetailRepository.GetById(userId);
            if (userDetail == null)
            {
                _logger.LogWarning($"User {userId} not found");
                throw new UserNotFoundException();
            }

            var userDetailDto = _mapper.Map<UserDetailDTO>(userDetail);

            _logger.LogInformation($"Fetched user details for user {userId}");

            return userDetailDto;
        }

        public async Task<UserLoginResponseDTO> Register(UserRegisterDTO userRegisterDTO)
        {
            _logger.LogInformation("Registering a new user");

            var userDetails = await _userDetailRepository.GetAll();
            var userDetail = userDetails.FirstOrDefault(ud =>
                ud.Email == userRegisterDTO.Email &&
                ud.Username == userRegisterDTO.Username &&
                ud.PhoneNumber == userRegisterDTO.PhoneNumber);

            if (userDetail == null)
            {
                _logger.LogWarning("User not found");
                throw new UserNotFoundException();
            }

            var user = _mapper.Map<User>(userRegisterDTO);
            user.UserDetailID = userDetail.UserID;
            CreatePasswordHash(userRegisterDTO.Password, out byte[] passwordHash, out byte[] passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            await _userRepository.Add(user);
            _logger.LogInformation("User registered successfully");

            return _mapper.Map<UserLoginResponseDTO>(user);
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public async Task<bool> DoesAccountBelongToUser(int accountId, int userId)
        {
            var account = await _accountRepository.GetById(accountId);
            if (account == null)
            {
                return false;
            }

            return account.UserID == userId;
        }
    }
}
