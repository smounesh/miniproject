using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankingSystem.Migrations
{
    public partial class removeduseruserdetailrelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_UserDetailID",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeID",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 22, 231, 37, 4, 66, 183, 153, 201, 74, 33, 226, 67, 165, 159, 78, 166, 39, 130, 92, 107, 211, 8, 154, 4, 47, 113, 221, 242, 248, 44, 18, 198, 242, 88, 47, 241, 48, 135, 217, 222, 252, 230, 233, 215, 224, 37, 112, 155, 49, 183, 239, 56, 67, 228, 248, 92, 170, 45, 181, 70, 129, 241, 145, 98 }, new byte[] { 145, 102, 8, 40, 121, 174, 231, 238, 32, 214, 247, 94, 149, 234, 139, 231, 146, 164, 139, 230, 76, 73, 142, 38, 36, 110, 16, 245, 93, 234, 6, 123, 75, 201, 163, 18, 109, 157, 107, 190, 211, 109, 101, 221, 85, 1, 194, 201, 86, 212, 146, 57, 0, 27, 250, 230, 66, 136, 245, 214, 228, 81, 14, 37, 115, 20, 179, 198, 59, 23, 112, 135, 74, 58, 156, 21, 14, 112, 55, 146, 46, 109, 176, 177, 58, 142, 146, 204, 140, 20, 33, 121, 122, 75, 189, 105, 228, 96, 10, 163, 155, 63, 193, 24, 87, 60, 145, 183, 61, 212, 154, 141, 177, 2, 126, 71, 14, 110, 249, 21, 157, 26, 91, 136, 226, 240, 125, 252 } });

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserDetailID",
                table: "Users",
                column: "UserDetailID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_UserDetailID",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeID",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 173, 55, 213, 157, 63, 6, 110, 196, 106, 34, 15, 183, 15, 53, 12, 185, 165, 18, 19, 230, 187, 86, 248, 82, 105, 214, 153, 181, 186, 112, 214, 80, 12, 206, 21, 74, 99, 50, 162, 165, 224, 52, 76, 233, 109, 57, 151, 155, 42, 54, 14, 146, 90, 118, 216, 145, 219, 136, 188, 200, 31, 233, 117, 253 }, new byte[] { 65, 192, 109, 175, 25, 143, 67, 192, 48, 216, 122, 255, 81, 134, 79, 39, 10, 92, 9, 181, 225, 50, 153, 68, 73, 93, 232, 105, 151, 109, 80, 230, 182, 87, 25, 156, 166, 104, 194, 27, 101, 126, 247, 114, 45, 22, 183, 101, 249, 204, 15, 242, 37, 9, 93, 100, 126, 201, 92, 224, 154, 21, 171, 95, 134, 58, 11, 1, 61, 78, 3, 101, 57, 222, 198, 78, 108, 186, 166, 66, 169, 254, 153, 162, 124, 88, 114, 28, 47, 237, 218, 2, 220, 86, 80, 61, 107, 233, 76, 63, 16, 251, 37, 225, 172, 26, 181, 182, 142, 34, 35, 206, 70, 65, 125, 192, 46, 83, 206, 165, 187, 0, 131, 100, 221, 134, 176, 231 } });

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserDetailID",
                table: "Users",
                column: "UserDetailID",
                unique: true);
        }
    }
}
