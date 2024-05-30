using BankingSystem.Contexts;
using BankingSystem.Enums;
using BankingSystem.Models;
using BankingSystem.Repositories;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BankingSystem.Tests.RepositoriesTests
{
    [TestFixture]
    public class AccountRepositoryTest
    {
        private BankingSystemContext? _context;
        private AccountRepository? _accountRepository;

        [SetUp]
        public void TestInitialize()
        {
            var options = new DbContextOptionsBuilder<BankingSystemContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()) // Unique name for each test
                .Options;

            _context = new BankingSystemContext(options);

            _accountRepository = new AccountRepository(_context);
        }

        //[Test]
        //public async Task GetById_ReturnsCorrectAccount()
        //{
        //    // Arrange
        //    var expectedAccountNo = 1;
        //    var userDetail = new UserDetail
        //    {
        //        UserID = 1,
        //        Username = "TestUser",
        //        Email = "testuser@example.com",
        //        Status = UserStatusEnum.Active, // Replace with the correct enum value
        //        PhoneNumber = "1234567890",
        //        Address = "123 Test Street"
        //    };

        //    var branch = new Branch
        //    {
        //        BranchID = 1,
        //        BranchName = "Test Branch",
        //        Location = "123 Test Street"
        //    };

        //    var data = new List<Account>
        //    {
        //        new Account
        //        {
        //            AccountNo = 1,
        //            UserID = userDetail.UserID,
        //            UserDetail = userDetail,
        //            AccountType = AccountTypeEnum.Savings, // Replace with the correct enum value
        //            Balance = 1000m,
        //            Status = AccountStatusEnum.Active, // Replace with the correct enum value
        //            AccountCreatedBranch = branch.BranchID,
        //            CurrentHomeBranch = branch.BranchID,
        //        },
        //        // Add more accounts...
        //    };

        //    if (_context != null)
        //    {
        //        await _context.UserDetails.AddAsync(userDetail);
        //        await _context.Branches.AddAsync(branch);
        //        await _context.Accounts.AddRangeAsync(data);
        //        await _context.SaveChangesAsync();
        //    }

        //    // Act
        //    var account = await _accountRepository?.GetById(expectedAccountNo);

        //    Debug.WriteLine($"Retrieved account: {account?.AccountNo}");

        //    // Assert
        //    Assert.That(account, Is.Not.Null);
        //    Assert.That(account?.AccountNo, Is.EqualTo(expectedAccountNo));
        //}

        //[Test]
        //public async Task GetAll_ReturnsAllAccounts()
        //{
        //    // Arrange
        //    // Add your data here...

        //    if (_context != null)
        //    {
        //        await _context.Accounts.AddRangeAsync(data);
        //        await _context.SaveChangesAsync();
        //    }

        //    // Act
        //    var accounts = await _accountRepository?.GetAll();

        //    Debug.WriteLine($"Retrieved {accounts?.Count()} accounts");

        //    // Assert
        //    Assert.That(accounts, Is.Not.Null);
        //    Assert.That(accounts?.Count(), Is.EqualTo(3));
        //}

        // Add more tests for Add, Update, Delete...
    }
}
