using BankingSystem.Models;
using BankingSystem.Repositories.Interfaces;
using BankingSystem.Services.Interfaces;
using BankingSystem.Exceptions;
using BankingSystem.Enums;
using System.Security.Principal;

namespace BankingSystem.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly IRepository<Account> _accountRepository;
        private readonly IRepository<Transaction> _transactionRepository;
        private readonly ILogger<TransactionService> _logger;

        public TransactionService(IRepository<Account> accountRepository, IRepository<Transaction> transactionRepository, ILogger<TransactionService> logger)
        {
            _accountRepository = accountRepository;
            _transactionRepository = transactionRepository;
            _logger = logger;
        }

        public async Task Deposit(int userid, int accountId, decimal amount)
        {
            var account = await _accountRepository.GetById(accountId);
            if (account == null)
            {
                _logger.LogError($"Account {accountId} not found.");
                throw new AccountNotFoundException($"Account {accountId} not found.");
            }

            if (account.Status == AccountStatusEnum.OnHold)
            {
                _logger.LogError($"Account {accountId} is on hold.");
                throw new AccountOnHoldException($"Account {accountId} is on hold.");
            }

            if (account.Status == AccountStatusEnum.Closed)
            {
                _logger.LogError($"Account {accountId} is closed.");
                throw new AccountClosedException($"Account {accountId} is closed.");
            }

            account.Balance += amount;
            await _accountRepository.Update(account);

            var transaction = new Transaction
            {
                UserID = userid,
                AccountID = account.AccountNo,
                Amount = amount,
                TransactionType = TransactionTypeEnum.Deposit
            };

            await _transactionRepository.Add(transaction);
        }

        public async Task Withdraw(int userid, int accountId, decimal amount)
        {
            var account = await _accountRepository.GetById(accountId);
            if (account == null)
            {
                _logger.LogError($"Account {accountId} not found.");
                throw new AccountNotFoundException($"Account {accountId} not found.");
            }

            if (account.Status == AccountStatusEnum.OnHold)
            {
                _logger.LogError($"Account {accountId} is on hold.");
                throw new AccountOnHoldException($"Account {accountId} is on hold.");
            }

            if (account.Status == AccountStatusEnum.Closed)
            {
                _logger.LogError($"Account {accountId} is closed.");
                throw new AccountClosedException($"Account {accountId} is closed.");
            }

            if (account.Balance < amount)
            {
                _logger.LogError($"Insufficient balance in account {accountId}.");
                throw new InsufficientBalanceException($"Insufficient balance in account {accountId}.");
            }

            account.Balance -= amount;

            await _accountRepository.Update(account);

            var transaction = new Transaction
            {
                UserID = userid,
                AccountID = account.AccountNo,
                Amount = amount,
                TransactionType = TransactionTypeEnum.Withdraw
            };

            await _transactionRepository.Add(transaction);
        }

        public async Task Transfer(int userid, int fromAccountId, int toAccountId, decimal amount)
        {
            var fromAccount = await _accountRepository.GetById(fromAccountId);
            var toAccount = await _accountRepository.GetById(toAccountId);

            if (fromAccount == null)
            {
                _logger.LogError($"Account {fromAccountId} not found.");
                throw new AccountNotFoundException($"Account {fromAccountId} not found.");
            }

            if (toAccount == null)
            {
                _logger.LogError($"Account {toAccountId} not found.");
                throw new AccountNotFoundException($"Account {toAccountId} not found.");
            }

            if (fromAccount.Status == AccountStatusEnum.OnHold)
            {
                _logger.LogError($"Account {fromAccountId} is on hold.");
                throw new AccountOnHoldException($"Account {fromAccountId} is on hold.");
            }

            if (fromAccount.Status == AccountStatusEnum.Closed)
            {
                _logger.LogError($"Account {fromAccountId} is closed.");
                throw new AccountClosedException($"Account {fromAccountId} is closed.");
            }


            if (toAccount.Status == AccountStatusEnum.OnHold)
            {
                _logger.LogError($"Account {toAccountId} is on hold.");
                throw new AccountOnHoldException($"Account {toAccountId} is on hold.");
            }

            if (toAccount.Status == AccountStatusEnum.Closed)
            {
                _logger.LogError($"Account {toAccountId} is closed.");
                throw new AccountClosedException($"Account {toAccountId} is closed.");
            }

            if (fromAccount.Balance < amount)
            {
                _logger.LogError($"Insufficient balance in account {fromAccountId}.");
                throw new InsufficientBalanceException($"Insufficient balance in account {fromAccountId}.");
            }

            fromAccount.Balance -= amount;
            toAccount.Balance += amount;

            await _accountRepository.Update(fromAccount);
            await _accountRepository.Update(toAccount);

            var transaction = new Transaction
            {
                UserID = userid,
                AccountID = fromAccountId,
                Amount = amount,
                TransactionType = TransactionTypeEnum.Transfer,
                FromAccountID = fromAccountId,
                ToAccountID = toAccountId
            };

            await _transactionRepository.Add(transaction);
        }
    }
}
