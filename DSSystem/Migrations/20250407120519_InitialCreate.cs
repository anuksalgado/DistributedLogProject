using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DSSystem.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LoginStruct",
                columns: table => new
                {
                    Username = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    DateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Success = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoginStruct", x => x.Username);
                });

            migrationBuilder.InsertData(
                table: "LoginStruct",
                columns: new[] { "Username", "DateTime", "Password", "Success" },
                values: new object[,]
                {
                    { "Burn", new DateTime(2024, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "1234", true },
                    { "Isak", new DateTime(2024, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "1234", true },
                    { "Wilson", new DateTime(2024, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "1234", true }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LoginStruct");
        }
    }
}
