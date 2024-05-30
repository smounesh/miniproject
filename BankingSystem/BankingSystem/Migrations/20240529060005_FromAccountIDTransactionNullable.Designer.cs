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
    [Migration("20240529060005_FromAccountIDTransactionNullable")]
    partial class FromAccountIDTransactionNullable
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
                            PasswordHash = new byte[] { 94, 0, 240, 61, 131, 118, 42, 252, 215, 138, 45, 53, 164, 153, 184, 235, 158, 147, 17, 20, 203, 173, 187, 117, 3, 161, 104, 213, 47, 6, 152, 102, 56, 97, 242, 94, 146, 157, 51, 192, 19, 242, 111, 10, 164, 45, 144, 59, 152, 34, 160, 244, 25, 95, 229, 129, 201, 108, 208, 196, 95, 54, 224, 31 },
                            PasswordSalt = new byte[] { 159, 242, 240, 60, 29, 241, 40, 147, 174, 220, 165, 123, 86, 239, 212, 66, 251, 69, 76, 102, 203, 218, 121, 212, 91, 134, 95, 172, 131, 169, 49, 255, 181, 85, 138, 140, 189, 229, 94, 205, 2, 136, 88, 104, 119, 114, 248, 205, 206, 149, 104, 139, 228, 79, 255, 35, 247, 183, 28, 255, 159, 84, 150, 78, 145, 2, 32, 83, 168, 138, 249, 135, 228, 98, 76, 35, 136, 4, 85, 228, 40, 233, 138, 116, 122, 226, 251, 187, 60, 227, 120, 143, 167, 57, 231, 113, 23, 16, 98, 98, 234, 177, 134, 73, 121, 118, 226, 136, 242, 254, 10, 23, 0, 127, 162, 33, 112, 138, 30, 129, 133, 7, 253, 103, 49, 184, 37, 209 },
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
                        .HasColumnType("int");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ToAccountID")
                        .HasColumnType("int");

                    b.Property<int>("TransactionType")
                        .HasColumnType("int");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("TransactionID");

                    b.HasIndex("AccountID");

                    b.HasIndex("FromAccountID");

                    b.HasIndex("ToAccountID");

                    b.HasIndex("UserID");

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
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("BankingSystem.Models.Account", "ToAccount")
                        .WithMany()
                        .HasForeignKey("ToAccountID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("BankingSystem.Models.UserDetail", "UserDetail")
                        .WithMany("Transactions")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("FromAccount");

                    b.Navigation("ToAccount");

                    b.Navigation("UserDetail");
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

                    b.Navigation("Transactions");
                });
#pragma warning restore 612, 618
        }
    }
}