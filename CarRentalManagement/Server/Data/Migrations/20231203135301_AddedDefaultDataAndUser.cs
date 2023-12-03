using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CarRentalManagement.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedDefaultDataAndUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "ad2bcf0c-20db-474f-8407-5a6b159518ba", null, "Administrator", "ADMINISTRATOR" },
                    { "bd2bcf0c-20db-474f-8407-5a6b159518bb", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "3781efa7-66dc-47f0-860f-e506d04102e4", 0, "4f5e6f44-8bd6-4e24-8370-c6009c53f32a", "admin@localhost.com", false, "Admin", "User", false, null, "ADMIN@LOCALHOST.COM", "ADMIN@LOCALHOST.COM", "AQAAAAIAAYagAAAAEEhZ2U4TUF7g/ilBDeAkZ6w7PfucywZD2ek9ueFfyfZkVw1ycDtqU9GVcGAXZIwkjg==", null, false, "ddb2a4ba-78f8-4dd0-888e-bf386378c4a1", false, "admin@localhost.com" });

            migrationBuilder.InsertData(
                table: "Colours",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, "System", new DateTime(2023, 12, 3, 21, 53, 1, 288, DateTimeKind.Local).AddTicks(212), new DateTime(2023, 12, 3, 21, 53, 1, 288, DateTimeKind.Local).AddTicks(226), "Black", "System" },
                    { 2, "System", new DateTime(2023, 12, 3, 21, 53, 1, 288, DateTimeKind.Local).AddTicks(229), new DateTime(2023, 12, 3, 21, 53, 1, 288, DateTimeKind.Local).AddTicks(230), "Blue", "System" }
                });

            migrationBuilder.InsertData(
                table: "Makes",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, "System", new DateTime(2023, 12, 3, 21, 53, 1, 288, DateTimeKind.Local).AddTicks(546), new DateTime(2023, 12, 3, 21, 53, 1, 288, DateTimeKind.Local).AddTicks(547), "BMW", "System" },
                    { 2, "System", new DateTime(2023, 12, 3, 21, 53, 1, 288, DateTimeKind.Local).AddTicks(549), new DateTime(2023, 12, 3, 21, 53, 1, 288, DateTimeKind.Local).AddTicks(549), "Toyota", "System" }
                });

            migrationBuilder.InsertData(
                table: "Models",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, "System", new DateTime(2023, 12, 3, 21, 53, 1, 288, DateTimeKind.Local).AddTicks(868), new DateTime(2023, 12, 3, 21, 53, 1, 288, DateTimeKind.Local).AddTicks(869), "3 Series", "System" },
                    { 2, "System", new DateTime(2023, 12, 3, 21, 53, 1, 288, DateTimeKind.Local).AddTicks(870), new DateTime(2023, 12, 3, 21, 53, 1, 288, DateTimeKind.Local).AddTicks(871), "X5", "System" },
                    { 3, "System", new DateTime(2023, 12, 3, 21, 53, 1, 288, DateTimeKind.Local).AddTicks(872), new DateTime(2023, 12, 3, 21, 53, 1, 288, DateTimeKind.Local).AddTicks(872), "Prius", "System" },
                    { 4, "System", new DateTime(2023, 12, 3, 21, 53, 1, 288, DateTimeKind.Local).AddTicks(873), new DateTime(2023, 12, 3, 21, 53, 1, 288, DateTimeKind.Local).AddTicks(874), "Rav4", "System" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "ad2bcf0c-20db-474f-8407-5a6b159518ba", "3781efa7-66dc-47f0-860f-e506d04102e4" });
        }

        /// <inheritdoc />
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
                table: "Colours",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Colours",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Makes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Makes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Models",
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
