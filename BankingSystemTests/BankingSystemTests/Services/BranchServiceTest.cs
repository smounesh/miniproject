using AutoMapper;
using BankingSystem.Contexts;
using BankingSystem.Models;
using BankingSystem.Models.DTO_s;
using BankingSystem.Repositories;
using BankingSystem.Services;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankingSystemTests.Services
{
    [TestFixture]
    public class BranchServiceTest
    {
        private Mock<BankingSystemContext>? _contextMock;
        private BranchService? _branchService;
        private IMapper? _mapper;

        [SetUp]
        public void TestInitialize()
        {
            var options = new DbContextOptionsBuilder<BankingSystemContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var context = new BankingSystemContext(options);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Branch, BranchDTO>();
                cfg.CreateMap<BranchDTO, Branch>();
            });

            _mapper = config.CreateMapper();

            var branchRepository = new BranchRepository(context);
            _branchService = new BranchService(branchRepository, _mapper);
        }

        [Test]
        public async Task GetBranchById_ReturnsCorrectBranch()
        {
            // Arrange
            var expectedBranchDto = new BranchDTO
            {
                BranchID = 1,
                BranchName = "Test Branch",
                Location = "123 Test Street"
            };

            await _branchService.CreateBranch(expectedBranchDto);

            // Act
            var branch = await _branchService.GetBranchById(expectedBranchDto.BranchID);

            // Assert
            Assert.That(branch, Is.Not.Null);
            Assert.That(branch.BranchID, Is.EqualTo(expectedBranchDto.BranchID));
        }

        [Test]
        public async Task GetAll_ReturnsAllBranches()
        {
            // Arrange
            var data = new List<BranchDTO>
                            {
                                new BranchDTO
                                {
                                    BranchID = 1,
                                    BranchName = "Test Branch",
                                    Location = "123 Test Street"
                                },
                                new BranchDTO
                                {
                                    BranchID = 2,
                                    BranchName = "Test Branch 2",
                                    Location = "456 Test Street"
                                },
                                new BranchDTO
                                {
                                    BranchID = 3,
                                    BranchName = "Test Branch 3",
                                    Location = "789 Test Street"
                                },
                            };

            foreach (var branchDto in data)
            {
                await _branchService.CreateBranch(branchDto);
            }

            // Act
            var branches = await _branchService.GetAll();

            // Assert
            Assert.That(branches, Is.Not.Null);
            Assert.That(branches.Count(), Is.EqualTo(data.Count));
        }

        [Test]
        public async Task CreateBranch_CreatesNewBranch()
        {
            // Arrange
            var newBranchDto = new BranchDTO
            {
                BranchID = 4,
                BranchName = "Test Branch 4",
                Location = "012 Test Street"
            };

            // Act
            await _branchService.CreateBranch(newBranchDto);

            // Assert
            var addedBranch = await _branchService.GetBranchById(newBranchDto.BranchID);
            Assert.That(addedBranch, Is.Not.Null);
            Assert.That(addedBranch.BranchID, Is.EqualTo(newBranchDto.BranchID));
        }

        [Test]
        public async Task UpdateBranch_UpdatesExistingBranch()
        {
            // Arrange
            var existingBranchDto = new BranchDTO
            {
                BranchID = 5,
                BranchName = "Test Branch 5",
                Location = "345 Test Street"
            };

            await _branchService.CreateBranch(existingBranchDto);

            var updatedBranchDto = new BranchDTO
            {
                BranchID = existingBranchDto.BranchID,
                BranchName = "Updated Test Branch 5",
                Location = existingBranchDto.Location
            };

            // Act
            await _branchService.UpdateBranch(updatedBranchDto.BranchID, updatedBranchDto);

            // Assert
            var updatedBranch = await _branchService.GetBranchById(updatedBranchDto.BranchID);
            Assert.That(updatedBranch, Is.Not.Null);
            Assert.That(updatedBranch.BranchName, Is.EqualTo(updatedBranchDto.BranchName));
        }

        [Test]
        public async Task DeleteBranch_DeletesExistingBranch()
        {
            // Arrange
            var existingBranchDto = new BranchDTO
            {
                BranchID = 6,
                BranchName = "Test Branch 6",
                Location = "678 Test Street"
            };

            await _branchService.CreateBranch(existingBranchDto);

            // Act
            await _branchService.DeleteBranch(existingBranchDto.BranchID);

            // Assert
            var deletedBranch = await _branchService.GetBranchById(existingBranchDto.BranchID);
            Assert.That(deletedBranch, Is.Null);
        }

        [TearDown]
        public void TestCleanup()
        {
            _branchService = null;
            _mapper = null;

            if (_contextMock != null)
            {
                _contextMock.Object.Database.EnsureDeleted();
                _contextMock = null;
            }
        }

    }
}
