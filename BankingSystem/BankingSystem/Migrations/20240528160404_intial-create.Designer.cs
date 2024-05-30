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
    [Migration("20240528160404_intial-create")]
    partial class intialcreate
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
                            PasswordHash = new byte[] { 173, 55, 213, 157, 63, 6, 110, 196, 106, 34, 15, 183, 15, 53, 12, 185, 165, 18, 19, 230, 187, 86, 248, 82, 105, 214, 153, 181, 186, 112, 214, 80, 12, 206, 21, 74, 99, 50, 162, 165, 224, 52, 76, 233, 109, 57, 151, 155, 42, 54, 14, 146, 90, 118, 216, 145, 219, 136, 188, 200, 31, 233, 117, 253 },
                            PasswordSalt = new byte[] { 65, 192, 109, 175, 25, 143, 67, 192, 48, 216, 122, 255, 81, 134, 79, 39, 10, 92, 9, 181, 225, 50, 153, 68, 73, 93, 232, 105, 151, 109, 80, 230, 182, 87, 25, 156, 166, 104, 194, 27, 101, 126, 247, 114, 45, 22, 183, 101, 249, 204, 15, 242, 37, 9, 93, 100, 126, 201, 92, 224, 154, 21, 171, 95, 134, 58, 11, 1, 61, 78, 3, 101, 57, 222, 198, 78, 108, 186, 166, 66, 169, 254, 153, 162, 124, 88, 114, 28, 47, 237, 218, 2, 220, 86, 80, 61, 107, 233, 76, 63, 16, 251, 37, 225, 172, 26, 181, 182, 142, 34, 35, 206, 70, 65, 125, 192, 46, 83, 206, 165, 187, 0, 131, 100, 221, 134, 176, 231 },
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

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

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

                    b.HasIndex("UserDetailID")
                        .IsUnique();

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
                        .WithOne("User")
                        .HasForeignKey("BankingSystem.Models.User", "UserDetailID")
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

                    b.Navigation("User")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
