using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FinancialTips.Server.Migrations
{
    public partial class AddedDefaultDataandUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "bd2bcf0c-20db-474f-8407-5a6b159518bb", "40589f50-6bcc-428e-b73e-f7ea3a7c67d8", "User", "USER" },
                    { "ad2bcf0c-20db-474f-8407-5a6b159518ba", "afad947e-58b6-4f7b-9d9e-349670d4b261", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "3781efa7-66dc-47f0-860f-e506d04102e4", 0, "d5fc13c4-d354-49be-a8ba-e789441c0498", "admin@localhost.com", false, "Admin", "User", false, null, "ADMIN@LOCALHOST.COM", "ADMIN", "AQAAAAEAACcQAAAAEFMJ4Jioo+IkPNhwL2aAUgLTKOP1FFNs7zNAv9PmDNzqfVLarlHLbNNot4rkDkU/Rw==", null, false, "5c01d569-c6d4-46fa-90e7-787748843019", false, "Admin" });

            migrationBuilder.InsertData(
                table: "Blogs",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { 3, "System", new DateTime(2023, 1, 29, 21, 4, 56, 429, DateTimeKind.Local).AddTicks(4650), new DateTime(2023, 1, 29, 21, 4, 56, 429, DateTimeKind.Local).AddTicks(4651), "Property", "System" },
                    { 4, "System", new DateTime(2023, 1, 29, 21, 4, 56, 429, DateTimeKind.Local).AddTicks(4652), new DateTime(2023, 1, 29, 21, 4, 56, 429, DateTimeKind.Local).AddTicks(4653), "Savings Bond", "System" },
                    { 1, "System", new DateTime(2023, 1, 29, 21, 4, 56, 427, DateTimeKind.Local).AddTicks(140), new DateTime(2023, 1, 29, 21, 4, 56, 429, DateTimeKind.Local).AddTicks(4012), "Loans", "System" },
                    { 2, "System", new DateTime(2023, 1, 29, 21, 4, 56, 429, DateTimeKind.Local).AddTicks(4644), new DateTime(2023, 1, 29, 21, 4, 56, 429, DateTimeKind.Local).AddTicks(4647), "Lifestyle", "System" }
                });

            migrationBuilder.InsertData(
                table: "Charts",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, "System", new DateTime(2023, 1, 29, 21, 4, 56, 430, DateTimeKind.Local).AddTicks(5412), new DateTime(2023, 1, 29, 21, 4, 56, 430, DateTimeKind.Local).AddTicks(5420), "Monthly Savings", "System" },
                    { 2, "System", new DateTime(2023, 1, 29, 21, 4, 56, 430, DateTimeKind.Local).AddTicks(5423), new DateTime(2023, 1, 29, 21, 4, 56, 430, DateTimeKind.Local).AddTicks(5424), "Yearly Savings", "System" }
                });

            migrationBuilder.InsertData(
                table: "Communities",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Name", "TipId", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, "System", new DateTime(2023, 1, 29, 21, 4, 56, 430, DateTimeKind.Local).AddTicks(7791), new DateTime(2023, 1, 29, 21, 4, 56, 430, DateTimeKind.Local).AddTicks(7796), "Investing 101", 0, "System" },
                    { 2, "System", new DateTime(2023, 1, 29, 21, 4, 56, 430, DateTimeKind.Local).AddTicks(7798), new DateTime(2023, 1, 29, 21, 4, 56, 430, DateTimeKind.Local).AddTicks(7798), "Budgeting 101", 0, "System" },
                    { 3, "System", new DateTime(2023, 1, 29, 21, 4, 56, 430, DateTimeKind.Local).AddTicks(7800), new DateTime(2023, 1, 29, 21, 4, 56, 430, DateTimeKind.Local).AddTicks(7801), "Promo Codes", 0, "System" },
                    { 4, "System", new DateTime(2023, 1, 29, 21, 4, 56, 430, DateTimeKind.Local).AddTicks(7802), new DateTime(2023, 1, 29, 21, 4, 56, 430, DateTimeKind.Local).AddTicks(7803), "Saving Hacks", 0, "System" }
                });

            migrationBuilder.InsertData(
                table: "FinancialPlannings",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { 7, "System", new DateTime(2023, 1, 29, 21, 4, 56, 431, DateTimeKind.Local).AddTicks(623), new DateTime(2023, 1, 29, 21, 4, 56, 431, DateTimeKind.Local).AddTicks(624), "CPF", "System" },
                    { 6, "System", new DateTime(2023, 1, 29, 21, 4, 56, 431, DateTimeKind.Local).AddTicks(622), new DateTime(2023, 1, 29, 21, 4, 56, 431, DateTimeKind.Local).AddTicks(622), "Student Loan", "System" },
                    { 3, "System", new DateTime(2023, 1, 29, 21, 4, 56, 431, DateTimeKind.Local).AddTicks(616), new DateTime(2023, 1, 29, 21, 4, 56, 431, DateTimeKind.Local).AddTicks(617), "Insurance", "System" },
                    { 4, "System", new DateTime(2023, 1, 29, 21, 4, 56, 431, DateTimeKind.Local).AddTicks(618), new DateTime(2023, 1, 29, 21, 4, 56, 431, DateTimeKind.Local).AddTicks(619), "Property", "System" },
                    { 2, "System", new DateTime(2023, 1, 29, 21, 4, 56, 431, DateTimeKind.Local).AddTicks(614), new DateTime(2023, 1, 29, 21, 4, 56, 431, DateTimeKind.Local).AddTicks(614), "Medisave", "System" },
                    { 5, "System", new DateTime(2023, 1, 29, 21, 4, 56, 431, DateTimeKind.Local).AddTicks(620), new DateTime(2023, 1, 29, 21, 4, 56, 431, DateTimeKind.Local).AddTicks(621), "Tax", "System" },
                    { 1, "System", new DateTime(2023, 1, 29, 21, 4, 56, 431, DateTimeKind.Local).AddTicks(608), new DateTime(2023, 1, 29, 21, 4, 56, 431, DateTimeKind.Local).AddTicks(612), "Budget", "System" }
                });

            migrationBuilder.InsertData(
                table: "Insights",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, "System", new DateTime(2023, 1, 29, 21, 4, 56, 431, DateTimeKind.Local).AddTicks(3648), new DateTime(2023, 1, 29, 21, 4, 56, 431, DateTimeKind.Local).AddTicks(3655), "Utilities", "System" },
                    { 2, "System", new DateTime(2023, 1, 29, 21, 4, 56, 431, DateTimeKind.Local).AddTicks(3657), new DateTime(2023, 1, 29, 21, 4, 56, 431, DateTimeKind.Local).AddTicks(3658), "Bills", "System" },
                    { 3, "System", new DateTime(2023, 1, 29, 21, 4, 56, 431, DateTimeKind.Local).AddTicks(3660), new DateTime(2023, 1, 29, 21, 4, 56, 431, DateTimeKind.Local).AddTicks(3660), "Cards", "System" },
                    { 4, "System", new DateTime(2023, 1, 29, 21, 4, 56, 431, DateTimeKind.Local).AddTicks(3662), new DateTime(2023, 1, 29, 21, 4, 56, 431, DateTimeKind.Local).AddTicks(3663), "Insurance Tips", "System" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "ad2bcf0c-20db-474f-8407-5a6b159518ba", "3781efa7-66dc-47f0-860f-e506d04102e4" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bd2bcf0c-20db-474f-8407-5a6b159518bb");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ad2bcf0c-20db-474f-8407-5a6b159518ba", "3781efa7-66dc-47f0-860f-e506d04102e4" });

            migrationBuilder.DeleteData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Charts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Charts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Communities",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Communities",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Communities",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Communities",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "FinancialPlannings",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "FinancialPlannings",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "FinancialPlannings",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "FinancialPlannings",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "FinancialPlannings",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "FinancialPlannings",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "FinancialPlannings",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Insights",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Insights",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Insights",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Insights",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ad2bcf0c-20db-474f-8407-5a6b159518ba");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3781efa7-66dc-47f0-860f-e506d04102e4");
        }
    }
}
