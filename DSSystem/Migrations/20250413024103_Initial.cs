using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DSSystem.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
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

            migrationBuilder.CreateTable(
                name: "receiptStruct",
                columns: table => new
                {
                    ReceiptID = table.Column<string>(type: "TEXT", nullable: false),
                    puchaseDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    cusName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_receiptStruct", x => x.ReceiptID);
                });

            migrationBuilder.CreateTable(
                name: "itemStruct",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    itemName = table.Column<string>(type: "TEXT", nullable: false),
                    price = table.Column<int>(type: "INTEGER", nullable: false),
                    MFD = table.Column<DateTime>(type: "TEXT", nullable: false),
                    quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    ReceiptStructReceiptID = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_itemStruct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_itemStruct_receiptStruct_ReceiptStructReceiptID",
                        column: x => x.ReceiptStructReceiptID,
                        principalTable: "receiptStruct",
                        principalColumn: "ReceiptID",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.InsertData(
                table: "receiptStruct",
                columns: new[] { "ReceiptID", "cusName", "puchaseDate" },
                values: new object[,]
                {
                    { "R001", "Anuk", new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "R002", "Palmer", new DateTime(2024, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "R003", "Jokovic", new DateTime(2024, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "R004", "Hazard", new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "R005", "Enzo", new DateTime(2024, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "R006", "Caicedo", new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "R007", "Lavia", new DateTime(2024, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "R008", "Cech", new DateTime(2024, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "R009", "Drogba", new DateTime(2024, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "R010", "Lamps", new DateTime(2024, 2, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "R011", "Mount", new DateTime(2024, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "R012", "Kante", new DateTime(2024, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "R013", "Silva", new DateTime(2024, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "R014", "Sterling", new DateTime(2024, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "R015", "Nkunku", new DateTime(2024, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "itemStruct",
                columns: new[] { "Id", "MFD", "ReceiptStructReceiptID", "itemName", "price", "quantity" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "R001", "Tomato", 12, 2 },
                    { 2, new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "R002", "Onion", 10, 1 },
                    { 3, new DateTime(2023, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "R003", "Cat Food", 124, 1 },
                    { 4, new DateTime(2023, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "R004", "Coca Cola", 13, 3 },
                    { 5, new DateTime(2023, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "R005", "Chicken", 134, 2 },
                    { 6, new DateTime(2023, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "R006", "Onion", 10, 4 },
                    { 7, new DateTime(2023, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "R007", "Chillies", 3, 1 },
                    { 8, new DateTime(2023, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "R008", "Tomato", 12, 3 },
                    { 9, new DateTime(2023, 8, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "R009", "Chicken", 134, 1 },
                    { 10, new DateTime(2023, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "R010", "Coca Cola", 13, 2 },
                    { 11, new DateTime(2023, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "R011", "Cat Food", 124, 5 },
                    { 12, new DateTime(2023, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "R012", "Chillies", 3, 2 },
                    { 13, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "R013", "Tomato", 12, 1 },
                    { 14, new DateTime(2023, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "R014", "Onion", 10, 2 },
                    { 15, new DateTime(2023, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "R015", "Coca Cola", 13, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_itemStruct_ReceiptStructReceiptID",
                table: "itemStruct",
                column: "ReceiptStructReceiptID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "itemStruct");

            migrationBuilder.DropTable(
                name: "LoginStruct");

            migrationBuilder.DropTable(
                name: "receiptStruct");
        }
    }
}
