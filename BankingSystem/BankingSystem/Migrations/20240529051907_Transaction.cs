using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankingSystem.Migrations
{
    public partial class Transaction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Transactions");

            migrationBuilder.AddColumn<int>(
                name: "TransactionType",
                table: "Transactions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeID",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 155, 181, 71, 171, 231, 152, 249, 5, 15, 11, 189, 82, 125, 212, 16, 54, 154, 131, 18, 244, 252, 229, 174, 210, 42, 1, 219, 244, 226, 152, 184, 139, 74, 208, 120, 182, 250, 195, 5, 65, 242, 249, 109, 1, 136, 213, 28, 111, 81, 75, 149, 159, 57, 158, 204, 248, 23, 134, 236, 153, 48, 147, 11, 6 }, new byte[] { 37, 141, 63, 169, 91, 157, 39, 185, 252, 92, 240, 187, 187, 16, 46, 48, 164, 74, 88, 6, 61, 113, 23, 107, 58, 57, 154, 242, 141, 169, 255, 9, 251, 53, 228, 186, 218, 9, 150, 176, 168, 37, 24, 18, 93, 148, 131, 130, 101, 220, 237, 66, 195, 193, 241, 217, 22, 155, 156, 106, 54, 140, 7, 117, 65, 99, 2, 48, 227, 105, 109, 198, 125, 163, 125, 73, 3, 233, 176, 10, 163, 197, 29, 58, 78, 48, 116, 134, 44, 69, 68, 147, 71, 249, 66, 220, 142, 207, 219, 14, 32, 206, 7, 191, 67, 88, 95, 25, 160, 144, 24, 42, 31, 17, 207, 87, 21, 64, 99, 96, 57, 72, 240, 225, 255, 228, 159, 151 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TransactionType",
                table: "Transactions");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeID",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 22, 231, 37, 4, 66, 183, 153, 201, 74, 33, 226, 67, 165, 159, 78, 166, 39, 130, 92, 107, 211, 8, 154, 4, 47, 113, 221, 242, 248, 44, 18, 198, 242, 88, 47, 241, 48, 135, 217, 222, 252, 230, 233, 215, 224, 37, 112, 155, 49, 183, 239, 56, 67, 228, 248, 92, 170, 45, 181, 70, 129, 241, 145, 98 }, new byte[] { 145, 102, 8, 40, 121, 174, 231, 238, 32, 214, 247, 94, 149, 234, 139, 231, 146, 164, 139, 230, 76, 73, 142, 38, 36, 110, 16, 245, 93, 234, 6, 123, 75, 201, 163, 18, 109, 157, 107, 190, 211, 109, 101, 221, 85, 1, 194, 201, 86, 212, 146, 57, 0, 27, 250, 230, 66, 136, 245, 214, 228, 81, 14, 37, 115, 20, 179, 198, 59, 23, 112, 135, 74, 58, 156, 21, 14, 112, 55, 146, 46, 109, 176, 177, 58, 142, 146, 204, 140, 20, 33, 121, 122, 75, 189, 105, 228, 96, 10, 163, 155, 63, 193, 24, 87, 60, 145, 183, 61, 212, 154, 141, 177, 2, 126, 71, 14, 110, 249, 21, 157, 26, 91, 136, 226, 240, 125, 252 } });
        }
    }
}
