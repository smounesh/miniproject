using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankingSystem.Migrations
{
    public partial class intialcreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Branches",
                columns: table => new
                {
                    BranchID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branches", x => x.BranchID);
                });

            migrationBuilder.CreateTable(
                name: "UserDetails",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDetails", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BranchID = table.Column<int>(type: "int", nullable: false),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JobTitle = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeID);
                    table.ForeignKey(
                        name: "FK_Employees_Branches_BranchID",
                        column: x => x.BranchID,
                        principalTable: "Branches",
                        principalColumn: "BranchID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    AccountNo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    AccountType = table.Column<int>(type: "int", nullable: false),
                    Balance = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    AccountCreatedBranch = table.Column<int>(type: "int", nullable: false),
                    CurrentHomeBranch = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.AccountNo);
                    table.ForeignKey(
                        name: "FK_Accounts_Branches_AccountCreatedBranch",
                        column: x => x.AccountCreatedBranch,
                        principalTable: "Branches",
                        principalColumn: "BranchID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Accounts_Branches_CurrentHomeBranch",
                        column: x => x.CurrentHomeBranch,
                        principalTable: "Branches",
                        principalColumn: "BranchID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Accounts_UserDetails_UserID",
                        column: x => x.UserID,
                        principalTable: "UserDetails",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    UserDetailID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                    table.ForeignKey(
                        name: "FK_Users_UserDetails_UserDetailID",
                        column: x => x.UserDetailID,
                        principalTable: "UserDetails",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Loans",
                columns: table => new
                {
                    LoanID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    AccountID = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    InterestRate = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Term = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loans", x => x.LoanID);
                    table.ForeignKey(
                        name: "FK_Loans_Accounts_AccountID",
                        column: x => x.AccountID,
                        principalTable: "Accounts",
                        principalColumn: "AccountNo",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Loans_UserDetails_UserID",
                        column: x => x.UserID,
                        principalTable: "UserDetails",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    TransactionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountID = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FromAccountID = table.Column<int>(type: "int", nullable: false),
                    ToAccountID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.TransactionID);
                    table.ForeignKey(
                        name: "FK_Transactions_Accounts_AccountID",
                        column: x => x.AccountID,
                        principalTable: "Accounts",
                        principalColumn: "AccountNo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transactions_Accounts_FromAccountID",
                        column: x => x.FromAccountID,
                        principalTable: "Accounts",
                        principalColumn: "AccountNo",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transactions_Accounts_ToAccountID",
                        column: x => x.ToAccountID,
                        principalTable: "Accounts",
                        principalColumn: "AccountNo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Branches",
                columns: new[] { "BranchID", "BranchName", "Location" },
                values: new object[] { 1, "Main Branch", "123 Main St, City, State, Country, 12345" });

            migrationBuilder.InsertData(
                table: "Branches",
                columns: new[] { "BranchID", "BranchName", "Location" },
                values: new object[] { 2, "Secondary Branch", "456 Secondary St, City, State, Country, 67890" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeID", "BranchID", "Department", "Email", "EmployeeName", "JobTitle", "PasswordHash", "PasswordSalt", "PhoneNumber", "Role", "Status" },
                values: new object[] { 1, 1, "Administration", "admin@bankingsystem.com", "Admin", "Administrator", new byte[] { 173, 55, 213, 157, 63, 6, 110, 196, 106, 34, 15, 183, 15, 53, 12, 185, 165, 18, 19, 230, 187, 86, 248, 82, 105, 214, 153, 181, 186, 112, 214, 80, 12, 206, 21, 74, 99, 50, 162, 165, 224, 52, 76, 233, 109, 57, 151, 155, 42, 54, 14, 146, 90, 118, 216, 145, 219, 136, 188, 200, 31, 233, 117, 253 }, new byte[] { 65, 192, 109, 175, 25, 143, 67, 192, 48, 216, 122, 255, 81, 134, 79, 39, 10, 92, 9, 181, 225, 50, 153, 68, 73, 93, 232, 105, 151, 109, 80, 230, 182, 87, 25, 156, 166, 104, 194, 27, 101, 126, 247, 114, 45, 22, 183, 101, 249, 204, 15, 242, 37, 9, 93, 100, 126, 201, 92, 224, 154, 21, 171, 95, 134, 58, 11, 1, 61, 78, 3, 101, 57, 222, 198, 78, 108, 186, 166, 66, 169, 254, 153, 162, 124, 88, 114, 28, 47, 237, 218, 2, 220, 86, 80, 61, 107, 233, 76, 63, 16, 251, 37, 225, 172, 26, 181, 182, 142, 34, 35, 206, 70, 65, 125, 192, 46, 83, 206, 165, 187, 0, 131, 100, 221, 134, 176, 231 }, "1234567890", "Admin", "Active" });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_AccountCreatedBranch",
                table: "Accounts",
                column: "AccountCreatedBranch");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_CurrentHomeBranch",
                table: "Accounts",
                column: "CurrentHomeBranch");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_UserID",
                table: "Accounts",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_BranchID",
                table: "Employees",
                column: "BranchID");

            migrationBuilder.CreateIndex(
                name: "IX_Loans_AccountID",
                table: "Loans",
                column: "AccountID");

            migrationBuilder.CreateIndex(
                name: "IX_Loans_UserID",
                table: "Loans",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_AccountID",
                table: "Transactions",
                column: "AccountID");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_FromAccountID",
                table: "Transactions",
                column: "FromAccountID");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_ToAccountID",
                table: "Transactions",
                column: "ToAccountID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserDetailID",
                table: "Users",
                column: "UserDetailID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Loans");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Branches");

            migrationBuilder.DropTable(
                name: "UserDetails");
        }
    }
}
