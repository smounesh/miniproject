﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankingSystem.Migrations
{
    public partial class AllowNullInTransactionFromAccountIDAndToAccountID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeID",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 232, 54, 206, 239, 79, 207, 130, 83, 83, 54, 119, 77, 86, 139, 103, 127, 1, 3, 3, 90, 87, 11, 232, 238, 54, 167, 17, 65, 103, 199, 83, 127, 128, 210, 11, 58, 3, 95, 50, 213, 248, 42, 250, 64, 110, 52, 222, 126, 228, 69, 50, 194, 54, 57, 224, 85, 94, 105, 37, 63, 171, 158, 161, 33 }, new byte[] { 89, 178, 212, 154, 84, 18, 30, 102, 23, 79, 238, 55, 224, 86, 15, 18, 82, 243, 74, 229, 113, 245, 215, 145, 167, 2, 111, 163, 215, 114, 162, 37, 116, 252, 38, 47, 129, 56, 16, 125, 102, 253, 163, 251, 50, 62, 83, 207, 243, 142, 238, 151, 109, 12, 178, 64, 134, 217, 62, 163, 19, 166, 142, 43, 53, 196, 239, 17, 126, 231, 250, 189, 153, 185, 250, 125, 12, 106, 85, 192, 95, 17, 60, 167, 143, 52, 81, 51, 143, 199, 241, 121, 150, 111, 223, 94, 214, 34, 29, 244, 219, 41, 125, 60, 93, 205, 172, 255, 172, 219, 9, 110, 168, 37, 80, 185, 97, 88, 106, 223, 167, 155, 169, 139, 255, 235, 179, 88 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeID",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 155, 181, 71, 171, 231, 152, 249, 5, 15, 11, 189, 82, 125, 212, 16, 54, 154, 131, 18, 244, 252, 229, 174, 210, 42, 1, 219, 244, 226, 152, 184, 139, 74, 208, 120, 182, 250, 195, 5, 65, 242, 249, 109, 1, 136, 213, 28, 111, 81, 75, 149, 159, 57, 158, 204, 248, 23, 134, 236, 153, 48, 147, 11, 6 }, new byte[] { 37, 141, 63, 169, 91, 157, 39, 185, 252, 92, 240, 187, 187, 16, 46, 48, 164, 74, 88, 6, 61, 113, 23, 107, 58, 57, 154, 242, 141, 169, 255, 9, 251, 53, 228, 186, 218, 9, 150, 176, 168, 37, 24, 18, 93, 148, 131, 130, 101, 220, 237, 66, 195, 193, 241, 217, 22, 155, 156, 106, 54, 140, 7, 117, 65, 99, 2, 48, 227, 105, 109, 198, 125, 163, 125, 73, 3, 233, 176, 10, 163, 197, 29, 58, 78, 48, 116, 134, 44, 69, 68, 147, 71, 249, 66, 220, 142, 207, 219, 14, 32, 206, 7, 191, 67, 88, 95, 25, 160, 144, 24, 42, 31, 17, 207, 87, 21, 64, 99, 96, 57, 72, 240, 225, 255, 228, 159, 151 } });
        }
    }
}