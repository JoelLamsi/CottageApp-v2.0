using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CottageApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CottageItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    PictureUrl = table.Column<string>(type: "TEXT", nullable: true),
                    DateAdded = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Rooms = table.Column<int>(type: "INTEGER", nullable: false),
                    IsSauna = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsElectricity = table.Column<bool>(type: "INTEGER", nullable: false),
                    CostPerDay = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CottageItems", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "CottageItems",
                columns: new[] { "Id", "CostPerDay", "DateAdded", "Description", "IsElectricity", "IsSauna", "PictureUrl", "Rooms", "Title" },
                values: new object[,]
                {
                    { 1, 0m, new DateTime(2022, 11, 18, 20, 28, 4, 38, DateTimeKind.Local).AddTicks(938), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.", false, false, "img/log-cabin-1886620_1920.jpg", 0, "Foo" },
                    { 2, 0m, new DateTime(2020, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, false, "img/cabin-1082063__340.webp", 0, "Bar" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CottageItems");
        }
    }
}
