using AutoMapper;
using BankingSystem.Models;
using BankingSystem.Models.DTO_s;
using BankingSystem.Repositories.Interfaces;
using BankingSystem.Services.Interfaces;
using BankingSystem.Exceptions;
using BankingSystem.Repositories;
using BankingSystem.Enums;
public class EmployeeService : IEmployeeService
{
    private readonly IRepository<Employee> _employeeRepository;
    private readonly IMapper _mapper;
    private readonly IRepository<Branch> _branchRepository;
    private readonly ILogger<EmployeeService> _logger;

    public EmployeeService(IRepository<Employee> employeeRepository, IMapper mapper, IRepository<Branch> branchRepository, ILogger<EmployeeService> logger)
    {
        _employeeRepository = employeeRepository;
        _mapper = mapper;
        _branchRepository = branchRepository;
        _logger = logger;
    }

    public async Task<EmployeeDTO> CreateEmployee(EmployeeRegisterDTO employeeRegisterDto)
    {
        _logger.LogInformation("Creating a new employee.");

        var existingEmployees = await _employeeRepository.GetAll();
        var employeesNameAndEmail = existingEmployees.ToDictionary(e => e.EmployeeName, e => e.Email);

        if (employeesNameAndEmail.ContainsKey(employeeRegisterDto.EmployeeName) && employeesNameAndEmail.ContainsValue(employeeRegisterDto.Email))
        {
            _logger.LogWarning($"Conflict: An employee with the name {employeeRegisterDto.EmployeeName} and email {employeeRegisterDto.Email} already exists.");
            throw new EmployeeAlreadyExistsException(employeeRegisterDto.EmployeeName, employeeRegisterDto.Email);
        }

        var branch = await _branchRepository.GetById(employeeRegisterDto.BranchID);
        if (branch == null)
        {
            _logger.LogWarning($"Not Found: No branch found with ID {employeeRegisterDto.BranchID}.");
            throw new BranchNotFoundException(employeeRegisterDto.BranchID);
        }

        var employee = _mapper.Map<Employee>(employeeRegisterDto);

        CreatePasswordHash(employeeRegisterDto.Password, out byte[] passwordHash, out byte[] passwordSalt);

        employee.PasswordHash = passwordHash;
        employee.PasswordSalt = passwordSalt;

        employee.Role = EmployeeRoleEnum.Employee;
        employee.Status = EmployeeStatusEnum.Active;

        await _employeeRepository.Add(employee);

        _logger.LogInformation("Employee created successfully.");

        return _mapper.Map<EmployeeDTO>(employee);
    }

    private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
    {
        using (var hmac = new System.Security.Cryptography.HMACSHA512())
        {
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        }
    }


    public async Task<EmployeeDTO> GetEmployeeById(int id)
    {
        var employee = await _employeeRepository.GetById(id);
        if (employee == null || employee.Status == EmployeeStatusEnum.Archieved)
        {
            throw new EmployeeNotFoundException(id);
        }

        return _mapper.Map<EmployeeDTO>(employee);
    }
    public async Task<EmployeeDTO> DeleteEmployee(int id)
    {
        var employee = await _employeeRepository.GetById(id);
        if (employee == null || employee.Status == EmployeeStatusEnum.Archieved)
        {
            throw new EmployeeNotFoundException(id);
        }

        employee.Status = EmployeeStatusEnum.Archieved;
        await _employeeRepository.Update(employee);
        return _mapper.Map<EmployeeDTO>(employee);
    }

    public async Task<EmployeeDTO> UpdateEmployee(int id, EmployeeUpdateDTO employeeUpdateDto)
    {
        var employee = await _employeeRepository.GetById(id);
        if (employee == null || employee.Status == EmployeeStatusEnum.Archieved)
        {
            throw new EmployeeNotFoundException(id);    
        }

        _mapper.Map(employeeUpdateDto, employee);
        await _employeeRepository.Update(employee);
        return _mapper.Map<EmployeeDTO>(employee);
    }


    public async Task<IEnumerable<EmployeeDTO>> GetAllEmployees()
    {
        var employees = await _employeeRepository.GetAll();
        var activeEmployees = employees.Where(e => e.Status != EmployeeStatusEnum.Archieved);
        return _mapper.Map<IEnumerable<EmployeeDTO>>(activeEmployees);
    }

    public async Task<EmployeeDTO> DisableEmployee(int id)
    {
        var employee = await _employeeRepository.GetById(id);
        if (employee == null || employee.Status == EmployeeStatusEnum.Archieved)
        {
            throw new EmployeeNotFoundException(id);
        }

        employee.Status = EmployeeStatusEnum.Disabled;
        await _employeeRepository.Update(employee);
        return _mapper.Map<EmployeeDTO>(employee);
    }
    public async Task<IEnumerable<EmployeeDTO>> GetArchivedEmployees()
    {
        var employees = await _employeeRepository.GetAll();
        var archivedEmployees = employees.Where(e => e.Status == EmployeeStatusEnum.Archieved);
        return _mapper.Map<IEnumerable<EmployeeDTO>>(archivedEmployees);
    }

    public async Task<EmployeeDTO> UpdateEmployeeRole(int id, EmployeeUpdateRoleDTO employeeUpdateRoleDto)
    {
        var employee = await _employeeRepository.GetById(id);
        if (employee == null || employee.Status == EmployeeStatusEnum.Archieved)
        {
            throw new EmployeeNotFoundException(id);
        }

        _mapper.Map(employeeUpdateRoleDto, employee);
        await _employeeRepository.Update(employee);
        return _mapper.Map<EmployeeDTO>(employee);
    }

    public async Task<EmployeeDTO> UpdateEmployeeStatus(int id, EmployeeUpdateStatusDTO employeeUpdateStatusDto)
    {
        var employee = await _employeeRepository.GetById(id);
        if (employee == null || employee.Status == EmployeeStatusEnum.Archieved)
        {
            throw new EmployeeNotFoundException(id);
        }

        _mapper.Map(employeeUpdateStatusDto, employee);
        await _employeeRepository.Update(employee);
        return _mapper.Map<EmployeeDTO>(employee);
    }

}
