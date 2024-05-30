using NUnit.Framework;
using BankingSystem.Contexts;
using BankingSystem.Services;
using BankingSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using BankingSystem.Repositories.Interfaces;
using AutoMapper;
using BankingSystem.Models.DTO_s;
using BankingSystem.Exceptions;
using Microsoft.Extensions.Logging;

namespace BankingSystemTests.Services
{
    public class EmployeeServiceTest
    {
        private BankingSystemContext? _context;
        private EmployeeService? _employeeService;
        private Mock<IRepository<Employee>>? _employeeRepositoryMock;
        private Mock<IRepository<Branch>>? _branchRepositoryMock;
        private Mock<IMapper>? _mapperMock;
        private Mock<ILogger<EmployeeService>>? _loggerMock;
        private Branch? _branch;

        [SetUp]
        public async Task Setup()
        {
            var options = new DbContextOptionsBuilder<BankingSystemContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            _context = new BankingSystemContext(options);

            _employeeRepositoryMock = new Mock<IRepository<Employee>>();
            _branchRepositoryMock = new Mock<IRepository<Branch>>();
            _mapperMock = new Mock<IMapper>();
            _loggerMock = new Mock<ILogger<EmployeeService>>();

            _employeeService = new EmployeeService(_employeeRepositoryMock.Object, _mapperMock.Object, _branchRepositoryMock.Object, _loggerMock.Object);

            _branch = new Branch
            {
                BranchID = 1,
                BranchName = "Test Branch",
                Location = "123 Test Street"
            };

            if (_context != null && _branch != null)
            {
                _context.Branches.Add(_branch);
                await _context.SaveChangesAsync();

                _branchRepositoryMock.Setup(r => r.GetById(_branch.BranchID)).Returns(Task.FromResult(_branch));
            }
        }

        [TearDown]
        public void TearDown()
        {
            _context?.Database.EnsureDeleted();
        }

        [Test]
        public async Task CreateEmployee_ReturnsEmployeeDTO()
        {
            // Arrange
            var employeeRegisterDto = new EmployeeRegisterDTO
            {
                EmployeeName = "Test Employee",
                Email = "test@employee.com",
                PhoneNumber = "1234567890",
                Department = "Test Department",
                JobTitle = "Test Job Title",
                BranchID = _branch?.BranchID ?? 0,
                Password = "testPassword"
            };

            var branch = _context != null && _branch != null ? await _context.Branches.FindAsync(_branch.BranchID) : null;
            if (branch != null)
            {
                Console.WriteLine($"Branch ID: {branch.BranchID}, Branch Name: {branch.BranchName}, Location: {branch.Location}");
            }

            var employeeDto = new EmployeeDTO
            {
                EmployeeID = 1,
                EmployeeName = "Test Employee",
                Email = "test@employee.com",
                PhoneNumber = "1234567890",
                Department = "Test Department",
                JobTitle = "Test Job Title"
            };

            _mapperMock?.Setup(m => m.Map<EmployeeDTO>(employeeRegisterDto)).Returns(employeeDto);

            // Act
            var result = await _employeeService?.CreateEmployee(employeeRegisterDto);

            // Assert
            Assert.That(result, Is.EqualTo(employeeDto));
        }
    }
}
