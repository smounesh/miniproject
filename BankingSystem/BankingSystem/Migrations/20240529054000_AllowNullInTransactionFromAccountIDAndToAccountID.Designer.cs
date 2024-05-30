﻿// <auto-generated />
using System;
using BankingSystem.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BankingSystem.Migrations
{
    [DbContext(typeof(BankingSystemContext))]
    [Migration("20240529054000_AllowNullInTransactionFromAccountIDAndToAccountID")]
    partial class AllowNullInTransactionFromAccountIDAndToAccountID
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.30")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BankingSystem.Models.Account", b =>
                {
                    b.Property<int>("AccountNo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AccountNo"), 1L, 1);

                    b.Property<int>("AccountCreatedBranch")
                        .HasColumnType("int");

                    b.Property<int>("AccountType")
                        .HasColumnType("int");

                    b.Property<decimal>("Balance")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("CurrentHomeBranch")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("AccountNo");

                    b.HasIndex("AccountCreatedBranch");

                    b.HasIndex("CurrentHomeBranch");

                    b.HasIndex("UserID");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("BankingSystem.Models.Branch", b =>
                {
                    b.Property<int>("BranchID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BranchID"), 1L, 1);

                    b.Property<string>("BranchName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BranchID");

                    b.ToTable("Branches");

                    b.HasData(
                        new
                        {
                            BranchID = 1,
                            BranchName = "Main Branch",
                            Location = "123 Main St, City, State, Country, 12345"
                        },
                        new
                        {
                            BranchID = 2,
                            BranchName = "Secondary Branch",
                            Location = "456 Secondary St, City, State, Country, 67890"
                        });
                });

            modelBuilder.Entity("BankingSystem.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeID"), 1L, 1);

                    b.Property<int>("BranchID")
                        .HasColumnType("int");

                    b.Property<string>("Department")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmployeeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JobTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmployeeID");

                    b.HasIndex("BranchID");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            EmployeeID = 1,
                            BranchID = 1,
                            Department = "Administration",
                            Email = "admin@bankingsystem.com",
                            EmployeeName = "Admin",
                            JobTitle = "Administrator",
                            PasswordHash = new byte[] { 232, 54, 206, 239, 79, 207, 130, 83, 83, 54, 119, 77, 86, 139, 103, 127, 1, 3, 3, 90, 87, 11, 232, 238, 54, 167, 17, 65, 103, 199, 83, 127, 128, 210, 11, 58, 3, 95, 50, 213, 248, 42, 250, 64, 110, 52, 222, 126, 228, 69, 50, 194, 54, 57, 224, 85, 94, 105, 37, 63, 171, 158, 161, 33 },
                            PasswordSalt = new byte[] { 89, 178, 212, 154, 84, 18, 30, 102, 23, 79, 238, 55, 224, 86, 15, 18, 82, 243, 74, 229, 113, 245, 215, 145, 167, 2, 111, 163, 215, 114, 162, 37, 116, 252, 38, 47, 129, 56, 16, 125, 102, 253, 163, 251, 50, 62, 83, 207, 243, 142, 238, 151, 109, 12, 178, 64, 134, 217, 62, 163, 19, 166, 142, 43, 53, 196, 239, 17, 126, 231, 250, 189, 153, 185, 250, 125, 12, 106, 85, 192, 95, 17, 60, 167, 143, 52, 81, 51, 143, 199, 241, 121, 150, 111, 223, 94, 214, 34, 29, 244, 219, 41, 125, 60, 93, 205, 172, 255, 172, 219, 9, 110, 168, 37, 80, 185, 97, 88, 106, 223, 167, 155, 169, 139, 255, 235, 179, 88 },
                            PhoneNumber = "1234567890",
                            Role = "Admin",
                            Status = "Active"
                        });
                });

            modelBuilder.Entity("BankingSystem.Models.Loan", b =>
                {
                    b.Property<int>("LoanID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LoanID"), 1L, 1);

                    b.Property<int>("AccountID")
                        .HasColumnType("int");

                    b.Property<decimal>("Amount")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("InterestRate")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Term")
                        .HasColumnType("int");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("LoanID");

                    b.HasIndex("AccountID");

                    b.HasIndex("UserID");

                    b.ToTable("Loans");
                });

            modelBuilder.Entity("BankingSystem.Models.Transaction", b =>
                {
                    b.Property<int>("TransactionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TransactionID"), 1L, 1);

                    b.Property<int>("AccountID")
                        .HasColumnType("int");

                    b.Property<decimal>("Amount")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("FromAccountID")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ToAccountID")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int>("TransactionType")
                        .HasColumnType("int");

                    b.HasKey("TransactionID");

                    b.HasIndex("AccountID");

                    b.HasIndex("FromAccountID");

                    b.HasIndex("ToAccountID");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("BankingSystem.Models.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserID"), 1L, 1);

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("UserDetailID")
                        .HasColumnType("int");

                    b.HasKey("UserID");

                    b.HasIndex("UserDetailID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BankingSystem.Models.UserDetail", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserID"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserID");

                    b.ToTable("UserDetails");
                });

            modelBuilder.Entity("BankingSystem.Models.Account", b =>
                {
                    b.HasOne("BankingSystem.Models.Branch", "CreatedBranch")
                        .WithMany()
                        .HasForeignKey("AccountCreatedBranch")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("BankingSystem.Models.Branch", "HomeBranch")
                        .WithMany()
                        .HasForeignKey("CurrentHomeBranch")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("BankingSystem.Models.UserDetail", "UserDetail")
                        .WithMany("Accounts")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CreatedBranch");

                    b.Navigation("HomeBranch");

                    b.Navigation("UserDetail");
                });

            modelBuilder.Entity("BankingSystem.Models.Employee", b =>
                {
                    b.HasOne("BankingSystem.Models.Branch", "Branch")
                        .WithMany()
                        .HasForeignKey("BranchID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Branch");
                });

            modelBuilder.Entity("BankingSystem.Models.Loan", b =>
                {
                    b.HasOne("BankingSystem.Models.Account", "Account")
                        .WithMany("Loans")
                        .HasForeignKey("AccountID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("BankingSystem.Models.UserDetail", "UserDetail")
                        .WithMany("Loans")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("UserDetail");
                });

            modelBuilder.Entity("BankingSystem.Models.Transaction", b =>
                {
                    b.HasOne("BankingSystem.Models.Account", "Account")
                        .WithMany("Transactions")
                        .HasForeignKey("AccountID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BankingSystem.Models.Account", "FromAccount")
                        .WithMany()
                        .HasForeignKey("FromAccountID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("BankingSystem.Models.Account", "ToAccount")
                        .WithMany()
                        .HasForeignKey("ToAccountID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("FromAccount");

                    b.Navigation("ToAccount");
                });

            modelBuilder.Entity("BankingSystem.Models.User", b =>
                {
                    b.HasOne("BankingSystem.Models.UserDetail", "UserDetail")
                        .WithMany()
                        .HasForeignKey("UserDetailID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserDetail");
                });

            modelBuilder.Entity("BankingSystem.Models.Account", b =>
                {
                    b.Navigation("Loans");

                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("BankingSystem.Models.UserDetail", b =>
                {
                    b.Navigation("Accounts");

                    b.Navigation("Loans");
                });
#pragma warning restore 612, 618
        }
    }
}