using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AutoHub.Data.Migrations
{
    /// <inheritdoc />
    public partial class NewBoolAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "HasBought",
                table: "ProductClients",
                type: "bit",
                nullable: false,
                defaultValue: false,
                comment: "To check if product is bought");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasBought",
                table: "ProductClients");
        }
    }
}
