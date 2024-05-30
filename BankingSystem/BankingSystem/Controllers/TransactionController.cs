using BankingSystem.Exceptions;
using BankingSystem.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BankingSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "User")]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;
        private readonly IUserService _userService;
        private readonly ILogger<TransactionController> _logger;

        private int UserId
        {
            get
            {
                if (int.TryParse(User.FindFirst("userid")?.Value, out int userId))
                {
                    return userId;
                }
                return 0;
            }
        }

        public TransactionController(ITransactionService transactionService, IUserService userService, ILogger<TransactionController> logger)
        {
            _transactionService = transactionService;
            _userService = userService;
            _logger = logger;
        }

        [HttpPost("deposit")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Deposit(int accountId, decimal amount)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _transactionService.Deposit(UserId, accountId, amount);
                _logger.LogInformation($"Successfully deposited {amount} to account {accountId}");
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while depositing to account {accountId}");
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("withdraw")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Withdraw(int accountId, decimal amount)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!(await _userService.DoesAccountBelongToUser(accountId, UserId)))
            {
                throw new AccountNumberIncorrectException("The account number is incorrect.");
            }

            try
            {
                await _transactionService.Withdraw(UserId, accountId, amount);
                _logger.LogInformation($"Successfully withdrew {amount} from account {accountId}");
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while withdrawing from account {accountId}");
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("transfer")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Transfer(int fromAccountId, int toAccountId, decimal amount)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!(await _userService.DoesAccountBelongToUser(fromAccountId, UserId)))
            {
                throw new AccountNumberIncorrectException("The account number is incorrect.");
            }

            try
            {
                await _transactionService.Transfer(UserId, fromAccountId, toAccountId, amount);
                _logger.LogInformation($"Successfully transferred {amount} from account {fromAccountId} to account {toAccountId}");
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while transferring from account {fromAccountId} to account {toAccountId}");
                return BadRequest(ex.Message);
            }
        }


    }
}

