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
    [Migration("20240529051907_Transaction")]
    partial class Transaction
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
                            PasswordHash = new byte[] { 155, 181, 71, 171, 231, 152, 249, 5, 15, 11, 189, 82, 125, 212, 16, 54, 154, 131, 18, 244, 252, 229, 174, 210, 42, 1, 219, 244, 226, 152, 184, 139, 74, 208, 120, 182, 250, 195, 5, 65, 242, 249, 109, 1, 136, 213, 28, 111, 81, 75, 149, 159, 57, 158, 204, 248, 23, 134, 236, 153, 48, 147, 11, 6 },
                            PasswordSalt = new byte[] { 37, 141, 63, 169, 91, 157, 39, 185, 252, 92, 240, 187, 187, 16, 46, 48, 164, 74, 88, 6, 61, 113, 23, 107, 58, 57, 154, 242, 141, 169, 255, 9, 251, 53, 228, 186, 218, 9, 150, 176, 168, 37, 24, 18, 93, 148, 131, 130, 101, 220, 237, 66, 195, 193, 241, 217, 22, 155, 156, 106, 54, 140, 7, 117, 65, 99, 2, 48, 227, 105, 109, 198, 125, 163, 125, 73, 3, 233, 176, 10, 163, 197, 29, 58, 78, 48, 116, 134, 44, 69, 68, 147, 71, 249, 66, 220, 142, 207, 219, 14, 32, 206, 7, 191, 67, 88, 95, 25, 160, 144, 24, 42, 31, 17, 207, 87, 21, 64, 99, 96, 57, 72, 240, 225, 255, 228, 159, 151 },
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
