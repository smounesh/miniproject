using AutoMapper;
using BankingSystem.Models.DTO_s;
using BankingSystem.Models;
using BankingSystem.Repositories;
using BankingSystem.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using BankingSystem.Repositories.Interfaces;
using BankingSystem.Exceptions;

public class AuthService : IAuthService
{
    private readonly IMapper _mapper;
    private readonly string _jwtSecret;
    private readonly IConfiguration _configuration;
    private readonly ILogger<AuthService> _logger;
    private readonly IRepository<User> _userRepository;
    private readonly IRepository<UserDetail> _userDetailRepository;
    private readonly IRepository<Employee> _employeeRepository;

    public AuthService(IMapper mapper, IConfiguration configuration, ILogger<AuthService> logger, IRepository<User> userRepository, IRepository<UserDetail> userDetailRepository, IRepository<Employee> employeeRepository)
    {
        _mapper = mapper;
        _configuration = configuration;
        _jwtSecret = _configuration["JWT:Secret"] ?? string.Empty;
        _logger = logger;
        _userRepository = userRepository;
        _userDetailRepository = userDetailRepository;
        _employeeRepository = employeeRepository;
    }

    public async Task<UserLoginResponseDTO> Login(UserLoginDTO userLoginDTO)
    {
        var userDetails = await _userDetailRepository.GetAll();
        var userDetail = userDetails.FirstOrDefault(ud => ud.Username == userLoginDTO.Username);

        if (userDetail == null)
        {
            throw new UserNotRegisteredException();
        }

        var users = await _userRepository.GetAll();
        var user = users.FirstOrDefault(u => u.UserDetailID == userDetail.UserID);

        if (user == null || !VerifyPasswordHash(userLoginDTO.Password, user.PasswordHash, user.PasswordSalt))
        {
            throw new InvalidUsernameOrPasswordException();
        }

        var token = GenerateJwtToken(userDetail);

        return new UserLoginResponseDTO
        {
            UserId = user.UserID,
            Username = userDetail.Username,
            Role = "User",
            Token = token
        };
    }

    public async Task<bool> ResetPassword(UserResetPasswordDTO userResetPasswordDTO)
    {
        var userDetails = await _userDetailRepository.GetAll();
        UserDetail userDetail;

        // Check if the provided identifier is an email
        if (userResetPasswordDTO.UsernameOrEmail.Contains("@"))
        {
            userDetail = userDetails.FirstOrDefault(ud => ud.Email == userResetPasswordDTO.UsernameOrEmail);
        }
        else
        {
            userDetail = userDetails.FirstOrDefault(ud => ud.Username == userResetPasswordDTO.UsernameOrEmail);
        }

        if (userDetail == null)
        {
            throw new UserNotRegisteredException();
        }

        var users = await _userRepository.GetAll();
        var user = users.FirstOrDefault(u => u.UserDetailID == userDetail.UserID);

        if (user == null)
        {
            throw new UserNotRegisteredException();
        }

        CreatePasswordHash(userResetPasswordDTO.NewPassword, out byte[] passwordHash, out byte[] passwordSalt);

        user.PasswordHash = passwordHash;
        user.PasswordSalt = passwordSalt;

        await _userRepository.Update(user);

        return true;
    }

    private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
    {
        using (var hmac = new System.Security.Cryptography.HMACSHA512())
        {
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        }
    }

    private string GenerateJwtToken(UserDetail user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_jwtSecret);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim("userid", user.UserID.ToString()),
                new Claim("username", user.Username),
                new Claim(ClaimTypes.Role, "User")
            }),
            Expires = DateTime.UtcNow.AddMinutes(5000),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    private bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
    {
        using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
        {
            var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != storedHash[i]) return false;
            }
        }
        return true;
    }


    public async Task<EmployeeLoginResponseDTO> EmployeeLogin(EmployeeLoginDTO employeeLoginDTO)
    {
        _logger.LogInformation("EmployeeLogin method called");

        var employees = await _employeeRepository.GetAll();
        var employee = employees.FirstOrDefault(e => e.EmployeeName == employeeLoginDTO.Username);

        if (employee == null || !VerifyPasswordHash(employeeLoginDTO.Password, employee.PasswordHash, employee.PasswordSalt))
        {
            _logger.LogWarning("Invalid username or password");
            throw new Exception("Username or password is incorrect");
        }

        var token = GenerateJwtToken(employee);

        _logger.LogInformation("Employee logged in successfully");

        var employeeLoginResponseDTO = _mapper.Map<EmployeeLoginResponseDTO>(employee);
        employeeLoginResponseDTO.Token = token;

        return employeeLoginResponseDTO;
    }

    private string GenerateJwtToken(Employee employee)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_jwtSecret);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
            new Claim("employeeid", employee.EmployeeID.ToString()),
            new Claim("employeename", employee.EmployeeName),
            new System.Security.Claims.Claim(System.Security.Claims.ClaimTypes.Role, employee.Role.ToString())

        }),
            Expires = DateTime.UtcNow.AddMinutes(5000),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}
