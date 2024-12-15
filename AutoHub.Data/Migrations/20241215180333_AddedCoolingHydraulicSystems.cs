using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AutoHub.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedCoolingHydraulicSystems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.CreateTable(
                name: "HydraulicSystemParts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Identifier of the part"),
                    partName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Name of the part"),
                    Description = table.Column<string>(type: "nvarchar(800)", maxLength: 800, nullable: false, comment: "Description of the part"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Image of the part")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HydraulicSystemParts", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropTable(
                name: "HydraulicSystemParts");
        }
    }
}
