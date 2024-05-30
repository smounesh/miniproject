using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankingSystem.Migrations
{
    public partial class FromAccountIDTransactionNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ToAccountID",
                table: "Transactions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "FromAccountID",
                table: "Transactions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeID",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 94, 0, 240, 61, 131, 118, 42, 252, 215, 138, 45, 53, 164, 153, 184, 235, 158, 147, 17, 20, 203, 173, 187, 117, 3, 161, 104, 213, 47, 6, 152, 102, 56, 97, 242, 94, 146, 157, 51, 192, 19, 242, 111, 10, 164, 45, 144, 59, 152, 34, 160, 244, 25, 95, 229, 129, 201, 108, 208, 196, 95, 54, 224, 31 }, new byte[] { 159, 242, 240, 60, 29, 241, 40, 147, 174, 220, 165, 123, 86, 239, 212, 66, 251, 69, 76, 102, 203, 218, 121, 212, 91, 134, 95, 172, 131, 169, 49, 255, 181, 85, 138, 140, 189, 229, 94, 205, 2, 136, 88, 104, 119, 114, 248, 205, 206, 149, 104, 139, 228, 79, 255, 35, 247, 183, 28, 255, 159, 84, 150, 78, 145, 2, 32, 83, 168, 138, 249, 135, 228, 98, 76, 35, 136, 4, 85, 228, 40, 233, 138, 116, 122, 226, 251, 187, 60, 227, 120, 143, 167, 57, 231, 113, 23, 16, 98, 98, 234, 177, 134, 73, 121, 118, 226, 136, 242, 254, 10, 23, 0, 127, 162, 33, 112, 138, 30, 129, 133, 7, 253, 103, 49, 184, 37, 209 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ToAccountID",
                table: "Transactions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FromAccountID",
                table: "Transactions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeID",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 235, 33, 145, 53, 47, 141, 149, 167, 147, 99, 89, 24, 252, 138, 9, 52, 103, 146, 255, 142, 72, 114, 165, 55, 196, 227, 148, 56, 1, 81, 223, 193, 134, 50, 182, 111, 107, 223, 68, 210, 67, 35, 186, 176, 49, 128, 69, 164, 82, 111, 65, 102, 73, 60, 71, 114, 181, 131, 144, 115, 35, 186, 84, 33 }, new byte[] { 173, 240, 48, 7, 186, 41, 116, 128, 43, 135, 193, 175, 246, 251, 122, 208, 248, 21, 231, 16, 110, 4, 64, 157, 149, 163, 172, 199, 111, 193, 93, 192, 100, 123, 111, 136, 170, 1, 20, 242, 97, 133, 12, 95, 161, 226, 110, 119, 98, 26, 9, 221, 117, 188, 140, 84, 5, 206, 228, 225, 128, 209, 120, 231, 190, 115, 212, 164, 162, 105, 235, 110, 12, 202, 230, 148, 246, 96, 31, 168, 127, 105, 140, 232, 180, 53, 106, 218, 7, 226, 161, 126, 107, 185, 113, 198, 107, 14, 31, 116, 22, 66, 203, 227, 39, 143, 148, 96, 116, 48, 170, 118, 235, 98, 99, 130, 206, 48, 48, 39, 123, 75, 182, 92, 220, 234, 152, 54 } });
        }
    }
}
