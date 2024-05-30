using AutoMapper;
using BankingSystem.Models.DTO_s;
using BankingSystem.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using BankingSystem.Exceptions;

namespace BankingSystem.Controllers
{
    [ApiController]
    [Authorize(Roles = "Employee")]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly IUserService _userService;
        private readonly ILogger<AccountController> _logger;
        private readonly IMapper _mapper;

        public AccountController(IAccountService accountService, IMapper mapper, ILogger<AccountController> logger, IUserService userService)
        {
            _accountService = accountService;
            _userService = userService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> CreateAccount(AccountCreateDTO accountCreateDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _userService.GetUserDetail(accountCreateDTO.UserID);
                await _accountService.CreateAccount(accountCreateDTO);
                _logger.LogInformation("Account created successfully.");
                return Ok();
            }
            catch(UserNotFoundException ex)
            {
                _logger.LogError(ex, "User not found");
                return NotFound("User not found");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating the account");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> UpdateAccount(int id, AccountUpdateDTO accountUpdateDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _accountService.UpdateAccount(accountUpdateDTO);
                _logger.LogInformation("Account updated successfully.");
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating the account");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost("userdetail")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> CreateUserDetail(UserDetailCreateDTO userDetailCreateDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _accountService.CreateUserDetail(userDetailCreateDTO);
                _logger.LogInformation("UserDetail created successfully.");
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating the UserDetail");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("userdetail/{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> UpdateUserDetail(int id, UserDetailUpdateDTO userDetailUpdateDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _accountService.UpdateUserDetail(userDetailUpdateDTO);
                _logger.LogInformation("UserDetail updated successfully.");
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating the UserDetail");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetAccount(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var account = await _accountService.GetAccountById(id);
                if (account == null)
                {
                    return NotFound();
                }
                var accountDTO = _mapper.Map<AccountDTO>(account);
                return Ok(accountDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while getting the account with ID {id}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("userdetail/{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetUserDetail(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var userDetail = await _accountService.GetUserDetailById(id);
                if (userDetail == null)
                {
                    return NotFound();
                }
                var userDetailDTO = _mapper.Map<UserDetailDTO>(userDetail);
                return Ok(userDetailDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while getting the user detail with ID {id}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetAllAccounts()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var accounts = await _accountService.GetAllAccounts();
                var accountDTOs = _mapper.Map<IEnumerable<AccountDTO>>(accounts);
                return Ok(accountDTOs);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting all accounts");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("userdetail")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetAllUserDetails()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var userDetails = await _accountService.GetAllUserDetails();
                var userDetailDTOs = _mapper.Map<IEnumerable<UserDetailDTO>>(userDetails);
                return Ok(userDetailDTOs);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting all user details");
                return StatusCode(500, "Internal server error");
            }
        }

        // Enable account
        [HttpPut("{id}/enable")]
        public async Task<IActionResult> EnableAccount(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _accountService.EnableAccount(id);
                _logger.LogInformation("Account enabled successfully.");
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while enabling the account");
                return StatusCode(500, "Internal server error");
            }
        }

        // Disable account
        [HttpPut("{id}/disable")]
        public async Task<IActionResult> DisableAccount(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _accountService.DisableAccount(id);
                _logger.LogInformation("Account disabled successfully.");
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while disabling the account");
                return StatusCode(500, "Internal server error");
            }
        }

        // Close account
        [HttpDelete("{id}")]
        public async Task<IActionResult> CloseAccount(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _accountService.CloseAccount(id);
                _logger.LogInformation("Account closed successfully.");
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while closing the account");
                return StatusCode(500, "Internal server error");
            }
        }

    }
}
