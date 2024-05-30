using BankingSystem.Models.DTO_s;
using BankingSystem.Services;
using BankingSystem.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

[Route("api/auth/")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;
    private readonly IUserService _userService;
    private readonly ILogger<AuthController> _logger;

    public AuthController(IAuthService authService, IUserService userService, ILogger<AuthController> logger)
    {
        _authService = authService;
        _userService = userService;
        _logger = logger;
    }

    [HttpPost("user/register")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> Register(UserRegisterDTO userRegisterDTO)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            var user = await _userService.Register(userRegisterDTO);

            if (user == null)
            {
                _logger.LogWarning("Registration failed for user: {Username}", userRegisterDTO.Username);
                return BadRequest(new { message = "Registration failed" });
            }

            _logger.LogInformation("User registered successfully: {Username}", userRegisterDTO.Username);
            return Ok(user);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while registering user: {Username}", userRegisterDTO.Username);
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPost("user/login")]
    [ProducesResponseType(200)]
    [ProducesResponseType(401)]
    public async Task<IActionResult> Login(UserLoginDTO userLoginDTO)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            var user = await _authService.Login(userLoginDTO);

            if (user == null)
            {
                _logger.LogWarning("Login failed for user: {Username}", userLoginDTO.Username);
                return Unauthorized();
            }

            _logger.LogInformation("User logged in successfully: {Username}", userLoginDTO.Username);
            return Ok(user);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while logging in user: {Username}", userLoginDTO.Username);
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPost("user/reset-password")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> ResetPassword(UserResetPasswordDTO userResetPasswordDTO)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            var result = await _authService.ResetPassword(userResetPasswordDTO);

            if (!result)
            {
                _logger.LogWarning("Failed to reset password for user: {Username}", userResetPasswordDTO.UsernameOrEmail);
                return BadRequest(new { message = "Failed to reset password" });
            }

            _logger.LogInformation("Password reset successfully for user: {Username}", userResetPasswordDTO.UsernameOrEmail);
            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while resetting password for user: {Username}", userResetPasswordDTO.UsernameOrEmail);
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPost("employee/login")]
    [ProducesResponseType(200)]
    [ProducesResponseType(401)]
    public async Task<IActionResult> EmployeeLogin(EmployeeLoginDTO employeeLoginDTO)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            var employee = await _authService.EmployeeLogin(employeeLoginDTO);

            if (employee == null)
            {
                _logger.LogWarning("Login failed for employee: {Username}", employeeLoginDTO.Username);
                return Unauthorized();
            }

            _logger.LogInformation("Employee logged in successfully: {Username}", employeeLoginDTO.Username);
            return Ok(employee);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while logging in employee: {Username}", employeeLoginDTO.Username);
            return BadRequest(new { message = ex.Message });
        }
    }
}
