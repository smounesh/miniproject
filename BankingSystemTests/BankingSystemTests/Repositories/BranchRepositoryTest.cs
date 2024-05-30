using BankingSystem.Contexts;
using BankingSystem.Models;
using BankingSystem.Repositories;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankingSystemTests.Repositories
{
    [TestFixture]
    public class BranchRepositoryTest
    {
        private BankingSystemContext? _context;
        private BranchRepository? _branchRepository;

        [SetUp]
        public void TestInitialize()
        {
            var options = new DbContextOptionsBuilder<BankingSystemContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()) // Unique name for each test
                .Options;

            _context = new BankingSystemContext(options);

            _branchRepository = new BranchRepository(_context);
        }

        [Test]
        public async Task GetById_ReturnsCorrectBranch()
        {
            // Arrange
            var expectedBranchId = 1;
            var data = new List<Branch>
            {
                new Branch
                {
                    BranchID = 1,
                    BranchName = "Test Branch",
                    Location = "123 Test Street"
                },
                // Add more branches...
            };

            if (_context != null)
            {
                await _context.Branches.AddRangeAsync(data);
                await _context.SaveChangesAsync();
            }

            // Act
            var branch = await _branchRepository?.GetById(expectedBranchId);

            Console.WriteLine($"Retrieved branch: {branch?.BranchID}");

            // Assert
            Assert.That(branch, Is.Not.Null);
            Assert.That(branch?.BranchID, Is.EqualTo(expectedBranchId));
        }

        [Test]
        public async Task GetAll_ReturnsAllBranches()
        {
            // Arrange
            var data = new List<Branch>
            {
                new Branch
                {
                    BranchID = 1,
                    BranchName = "Test Branch",
                    Location = "123 Test Street"
                },
                new Branch
                {
                    BranchID = 2,
                    BranchName = "Test Branch 2",
                    Location = "456 Test Street"
                },
                new Branch
                {
                    BranchID = 3,
                    BranchName = "Test Branch 3",
                    Location = "789 Test Street"
                },
            };

            if (_context != null)
            {
                await _context.Branches.AddRangeAsync(data);
                await _context.SaveChangesAsync();
            }

            // Act
            var branches = await _branchRepository?.GetAll();

            Console.WriteLine($"Retrieved {branches?.Count()} branches");

            // Assert
            Assert.That(branches, Is.Not.Null);
            Assert.That(branches?.Count(), Is.EqualTo(3));
        }

        [Test]
        public async Task Add_AddsNewBranch()
        {
            // Arrange
            var newBranch = new Branch
            {
                BranchID = 4,
                BranchName = "Test Branch 4",
                Location = "012 Test Street"
            };

            // Act
            await _branchRepository?.Add(newBranch);

            // Assert
            var addedBranch = await _branchRepository?.GetById(newBranch.BranchID);
            Assert.That(addedBranch, Is.Not.Null);
            Assert.That(addedBranch?.BranchID, Is.EqualTo(newBranch.BranchID));
        }

        [Test]
        public async Task Update_UpdatesExistingBranch()
        {
            // Arrange
            var existingBranch = new Branch
            {
                BranchID = 5,
                BranchName = "Test Branch 5",
                Location = "345 Test Street"
            };

            if (_context != null)
            {
                await _context.Branches.AddAsync(existingBranch);
                await _context.SaveChangesAsync();
            }

            existingBranch.BranchName = "Updated Test Branch 5";

            // Act
            await _branchRepository?.Update(existingBranch);

            // Assert
            var updatedBranch = await _branchRepository?.GetById(existingBranch.BranchID);
            Assert.That(updatedBranch, Is.Not.Null);
            Assert.That(updatedBranch?.BranchName, Is.EqualTo("Updated Test Branch 5"));
        }

        [Test]
        public async Task Delete_DeletesExistingBranch()
        {
            // Arrange
            var existingBranch = new Branch
            {
                BranchID = 6,
                BranchName = "Test Branch 6",
                Location = "678 Test Street"
            };

            if (_context != null)
            {
                await _context.Branches.AddAsync(existingBranch);
                await _context.SaveChangesAsync();
            }

            // Act
            await _branchRepository?.Delete(existingBranch.BranchID);

            // Assert
            var deletedBranch = await _branchRepository?.GetById(existingBranch.BranchID);
            Assert.That(deletedBranch, Is.Null);
        }

        [TearDown]
        public void TestCleanup()
        {
            _context?.Database.EnsureDeleted();
        }
    }
}
