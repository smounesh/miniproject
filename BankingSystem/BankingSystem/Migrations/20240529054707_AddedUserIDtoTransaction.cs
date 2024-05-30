using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankingSystem.Migrations
{
    public partial class AddedUserIDtoTransaction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "Transactions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeID",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 235, 33, 145, 53, 47, 141, 149, 167, 147, 99, 89, 24, 252, 138, 9, 52, 103, 146, 255, 142, 72, 114, 165, 55, 196, 227, 148, 56, 1, 81, 223, 193, 134, 50, 182, 111, 107, 223, 68, 210, 67, 35, 186, 176, 49, 128, 69, 164, 82, 111, 65, 102, 73, 60, 71, 114, 181, 131, 144, 115, 35, 186, 84, 33 }, new byte[] { 173, 240, 48, 7, 186, 41, 116, 128, 43, 135, 193, 175, 246, 251, 122, 208, 248, 21, 231, 16, 110, 4, 64, 157, 149, 163, 172, 199, 111, 193, 93, 192, 100, 123, 111, 136, 170, 1, 20, 242, 97, 133, 12, 95, 161, 226, 110, 119, 98, 26, 9, 221, 117, 188, 140, 84, 5, 206, 228, 225, 128, 209, 120, 231, 190, 115, 212, 164, 162, 105, 235, 110, 12, 202, 230, 148, 246, 96, 31, 168, 127, 105, 140, 232, 180, 53, 106, 218, 7, 226, 161, 126, 107, 185, 113, 198, 107, 14, 31, 116, 22, 66, 203, 227, 39, 143, 148, 96, 116, 48, 170, 118, 235, 98, 99, 130, 206, 48, 48, 39, 123, 75, 182, 92, 220, 234, 152, 54 } });

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_UserID",
                table: "Transactions",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_UserDetails_UserID",
                table: "Transactions",
                column: "UserID",
                principalTable: "UserDetails",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_UserDetails_UserID",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_UserID",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Transactions");

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeID",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 232, 54, 206, 239, 79, 207, 130, 83, 83, 54, 119, 77, 86, 139, 103, 127, 1, 3, 3, 90, 87, 11, 232, 238, 54, 167, 17, 65, 103, 199, 83, 127, 128, 210, 11, 58, 3, 95, 50, 213, 248, 42, 250, 64, 110, 52, 222, 126, 228, 69, 50, 194, 54, 57, 224, 85, 94, 105, 37, 63, 171, 158, 161, 33 }, new byte[] { 89, 178, 212, 154, 84, 18, 30, 102, 23, 79, 238, 55, 224, 86, 15, 18, 82, 243, 74, 229, 113, 245, 215, 145, 167, 2, 111, 163, 215, 114, 162, 37, 116, 252, 38, 47, 129, 56, 16, 125, 102, 253, 163, 251, 50, 62, 83, 207, 243, 142, 238, 151, 109, 12, 178, 64, 134, 217, 62, 163, 19, 166, 142, 43, 53, 196, 239, 17, 126, 231, 250, 189, 153, 185, 250, 125, 12, 106, 85, 192, 95, 17, 60, 167, 143, 52, 81, 51, 143, 199, 241, 121, 150, 111, 223, 94, 214, 34, 29, 244, 219, 41, 125, 60, 93, 205, 172, 255, 172, 219, 9, 110, 168, 37, 80, 185, 97, 88, 106, 223, 167, 155, 169, 139, 255, 235, 179, 88 } });
        }
    }
}
