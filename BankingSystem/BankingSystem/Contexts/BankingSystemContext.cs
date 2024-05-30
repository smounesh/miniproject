using Microsoft.EntityFrameworkCore;
using BankingSystem.Models;
using BankingSystem.Enums;

namespace BankingSystem.Contexts
{
    public class BankingSystemContext : DbContext
    {
        public BankingSystemContext(DbContextOptions<BankingSystemContext> options) : base(options) { }
        public DbSet<User>? Users { get; set; }
        public DbSet<UserDetail>? UserDetails { get; set; }
        public DbSet<Account>? Accounts { get; set; }
        public DbSet<Transaction>? Transactions { get; set; }
        public DbSet<Loan>? Loans { get; set; }
        public DbSet<Employee>? Employees { get; set; }
        public DbSet<Branch>? Branches { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // UserDetail-Account relationship
            modelBuilder.Entity<Account>()
                .HasOne(a => a.UserDetail)
                .WithMany(ud => ud.Accounts)
                .HasForeignKey(a => a.UserID)
                .OnDelete(DeleteBehavior.Cascade);

            // UserDetail-Loan relationship
            modelBuilder.Entity<Loan>()
                .HasOne(l => l.UserDetail)
                .WithMany(ud => ud.Loans)
                .HasForeignKey(l => l.UserID)
                .OnDelete(DeleteBehavior.Restrict);

            // Loan-Account relationship
            modelBuilder.Entity<Loan>()
                .HasOne(l => l.Account)
                .WithMany(a => a.Loans)
                .HasForeignKey(l => l.AccountID)
                .OnDelete(DeleteBehavior.Restrict);

            // Account-Transaction relationship
            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.Account)
                .WithMany(a => a.Transactions)
                .HasForeignKey(t => t.AccountID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.FromAccount)
                .WithMany()
                .HasForeignKey(t => t.FromAccountID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.ToAccount)
                .WithMany()
                .HasForeignKey(t => t.ToAccountID)
                .OnDelete(DeleteBehavior.Restrict);

            // UserDetails-Loan relationship
            modelBuilder.Entity<Loan>()
                .HasOne(l => l.UserDetail)
                .WithMany(u => u.Loans)
                .HasForeignKey(l => l.UserID)
                .OnDelete(DeleteBehavior.Cascade);

            // Employee-Branch relationship
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Branch)
                .WithMany()
                .HasForeignKey(e => e.BranchID)
                .OnDelete(DeleteBehavior.Cascade);

            // UserDetail-Transaction relationship
            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.UserDetail)
                .WithMany(ud => ud.Transactions)
                .HasForeignKey(t => t.UserID)
                .OnDelete(DeleteBehavior.Restrict);

            // Account-Branch relationship (created and home branches)
            modelBuilder.Entity<Account>()
                .HasOne(a => a.CreatedBranch)
                .WithMany()
                .HasForeignKey(a => a.AccountCreatedBranch)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Account>()
                .HasOne(a => a.HomeBranch)
                .WithMany()
                .HasForeignKey(a => a.CurrentHomeBranch)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Account>()
                .Property(a => a.Balance)
                .HasPrecision(18, 2); // Set precision and scale for Balance

            modelBuilder.Entity<Loan>()
                .Property(l => l.Amount)
                .HasPrecision(18, 2); // Set precision and scale for Amount

            modelBuilder.Entity<Loan>()
                .Property(l => l.InterestRate)
                .HasPrecision(18, 2); // Set precision and scale for InterestRate

            modelBuilder.Entity<Transaction>()
                .Property(t => t.Amount)
                .HasPrecision(18, 2); // Set precision and scale for Amount

            // Seed branches
            modelBuilder.Entity<Branch>().HasData(
            new Branch
            {
                BranchID = 1,
                BranchName = "Main Branch",
                Location = "123 Main St, City, State, Country, 12345"
            },
            new Branch
            {
                BranchID = 2,
                BranchName = "Secondary Branch",
                Location = "456 Secondary St, City, State, Country, 67890"
            });

            using var hmac = new System.Security.Cryptography.HMACSHA512();
            var passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes("admin"));
            var passwordSalt = hmac.Key;

            // Seed admin employee
            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeID = 1,
                EmployeeName = "Admin",
                Email = "admin@bankingsystem.com",
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                PhoneNumber = "1234567890",
                Role = EmployeeRoleEnum.Admin,
                Status = EmployeeStatusEnum.Active,
                BranchID = 1,
                Department = "Administration",
                JobTitle = "Administrator"
            });
        }
    }
}
