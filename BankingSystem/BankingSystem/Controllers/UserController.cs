using AutoMapper;
using BankingSystem.Exceptions;
using BankingSystem.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BankingSystem.Controllers
{
    [Authorize(Roles = "User")]
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<UserController> _logger;
        private readonly IMapper _mapper;

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

        public UserController(IUserService userService, ILogger<UserController> logger, IMapper mapper)
        {
            _userService = userService;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet("details")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetUserDetail()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _logger.LogInformation($"Fetching details for user {UserId}");
            try
            {
                var result = await _userService.GetUserDetail(UserId);
                _logger.LogInformation($"Successfully fetched details for user {UserId}");
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while fetching details for user {UserId}");
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{accountId}/balance")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAccountBalance(int accountId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _logger.LogInformation($"Fetching balance for account {accountId}");
            try
            {
                if (!(await _userService.DoesAccountBelongToUser(accountId, UserId)))
                {
                    throw new AccountNumberIncorrectException("The account number is incorrect.");
                }

                var result = await _userService.GetAccountBalance(accountId);
                _logger.LogInformation($"Successfully fetched balance for account {accountId}");
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while fetching balance for account {accountId}");
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("accounts")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAccounts()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _logger.LogInformation($"Fetching accounts for user {UserId}");
            try
            {
                var result = await _userService.GetAccounts(UserId);
                _logger.LogInformation($"Successfully fetched accounts for user {UserId}");
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while fetching accounts for user {UserId}");
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("loans")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetLoanDetails()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _logger.LogInformation($"Fetching loan details for user {UserId}");
            try
            {
                var result = await _userService.GetLoanDetails(UserId);
                _logger.LogInformation($"Successfully fetched loan details for user {UserId}");
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while fetching loan details for user {UserId}");
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{accountId}/transactions")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetTransactions(int accountId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _logger.LogInformation($"Fetching transactions for account {accountId}");
            try
            {
                if (!(await _userService.DoesAccountBelongToUser(accountId, UserId)))
                {
                    throw new AccountNumberIncorrectException("The account number is incorrect.");
                }

                var result = await _userService.GetTransactions(accountId);
                _logger.LogInformation($"Successfully fetched transactions for account {accountId}");
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while fetching transactions for account {accountId}");
                return BadRequest(ex.Message);
            }
        }
    }
}
