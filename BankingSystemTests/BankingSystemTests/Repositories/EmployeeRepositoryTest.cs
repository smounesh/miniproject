using NUnit.Framework;
using BankingSystem.Contexts;
using BankingSystem.Repositories;
using BankingSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BankingSystemTests.Repositories
{
    public class EmployeeRepositoryTest
    {
        private BankingSystemContext _context;
        private EmployeeRepository _employeeRepository;
        private Branch _branch;

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        [SetUp]
        public async Task Setup()
        {
            var options = new DbContextOptionsBuilder<BankingSystemContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            _context = new BankingSystemContext(options);
            _employeeRepository = new EmployeeRepository(_context);

            _branch = new Branch
            {
                BranchID = 1,
                BranchName = "Test Branch",
                Location = "123 Test Street"
            };

            _context.Branches.Add(_branch);
            await _context.SaveChangesAsync();
        }

        [TearDown]
        public void TearDown()
        {
            _context.Database.EnsureDeleted();
        }

        [Test]
        public async Task GetById_ReturnsCorrectEmployee()
        {
            // Arrange
            var password = "testPassword";
            CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

            var employee = new Employee
            {
                EmployeeID = 1,
                EmployeeName = "Test Employee",
                Email = "test@employee.com",
                PhoneNumber = "1234567890",
                Department = "Test Department",
                JobTitle = "Test Job Title",
                BranchID = _branch.BranchID,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };

            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();

            // Act
            var result = await _employeeRepository.GetById(employee.EmployeeID);

            // Assert
            Assert.AreEqual(employee.EmployeeID, result.EmployeeID);
        }

        [Test]
        public async Task GetAll_ReturnsAllEmployees()
        {
            // Arrange
            var password = "testPassword";
            CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

            var employees = new[]
                        {
                            new Employee { EmployeeID = 1, EmployeeName = "Test Employee 1", Email = "test1@employee.com", PhoneNumber = "1234567890", Department = "Test Department", JobTitle = "Test Job Title", BranchID = _branch.BranchID, PasswordHash = passwordHash, PasswordSalt = passwordSalt },
                            new Employee { EmployeeID = 2, EmployeeName = "Test Employee 2", Email = "test2@employee.com", PhoneNumber = "1234567890", Department = "Test Department", JobTitle = "Test Job Title", BranchID = _branch.BranchID, PasswordHash = passwordHash, PasswordSalt = passwordSalt },
                            new Employee { EmployeeID = 3, EmployeeName = "Test Employee 3", Email = "test3@employee.com", PhoneNumber = "1234567890", Department = "Test Department", JobTitle = "Test Job Title", BranchID = _branch.BranchID, PasswordHash = passwordHash, PasswordSalt = passwordSalt }
                        };

            _context.Employees.AddRange(employees);
            await _context.SaveChangesAsync();

            // Act
            var result = await _employeeRepository.GetAll();

            // Assert
            Assert.AreEqual(employees.Length, result.Count());
        }

        [Test]
        public async Task Add_AddsNewEmployee()
        {
            // Arrange
            var password = "testPassword";
            CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

            var employee = new Employee
            {
                EmployeeID = 1,
                EmployeeName = "Test Employee",
                Email = "test@employee.com",
                PhoneNumber = "1234567890",
                Department = "Test Department",
                JobTitle = "Test Job Title",
                BranchID = _branch.BranchID,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };

            // Act
            await _employeeRepository.Add(employee);

            // Assert
            var result = await _context.Employees.FindAsync(employee.EmployeeID);
            Assert.AreEqual(employee.EmployeeID, result.EmployeeID);
        }


        [Test]
        public async Task Update_UpdatesExistingEmployee()
        {
            // Arrange
            var password = "testPassword";
            CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

            var employee = new Employee
            {
                EmployeeID = 1,
                EmployeeName = "Test Employee",
                Email = "test@employee.com",
                PhoneNumber = "1234567890",
                Department = "Test Department",
                JobTitle = "Test Job Title",
                BranchID = _branch.BranchID,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };

            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();

            employee.EmployeeName = "Updated Employee Name";
            employee.Email = "updated@employee.com";

            // Act
            await _employeeRepository.Update(employee);

            // Assert
            var result = await _context.Employees.FindAsync(employee.EmployeeID);
            Assert.AreEqual(employee.EmployeeName, result.EmployeeName);
            Assert.AreEqual(employee.Email, result.Email);
        }

        [Test]
        public async Task Delete_DeletesExistingEmployee()
        {
            // Arrange
            var password = "testPassword";
            CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

            var employee = new Employee
            {
                EmployeeID = 1,
                EmployeeName = "Test Employee",
                Email = "test@employee.com",
                PhoneNumber = "1234567890",
                Department = "Test Department",
                JobTitle = "Test Job Title",
                BranchID = _branch.BranchID,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };

            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();

            // Act
            await _employeeRepository.Delete(employee.EmployeeID);

            // Assert
            var result = await _context.Employees.FindAsync(employee.EmployeeID);
            Assert.IsNull(result);
        }

    }
}
