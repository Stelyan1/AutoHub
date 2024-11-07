using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AutoHub.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddGearbox : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Gearboxes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Identification of the gearbox"),
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false, comment: "Name of the gearbox"),
                    TransmissionType = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false, comment: "Type of the transmission manual or automatic"),
                    Speeds = table.Column<int>(type: "int", nullable: false, comment: "How much speeds does it have from 5 to 8"),
                    YearsProduced = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Years produced"),
                    Manufacturer = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false, comment: "Manufacturer of the gearbox"),
                    Descritpion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false, comment: "Description about the gearbox"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Image of the gearbox"),
                    Application = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Model vehicle that has it")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gearboxes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Gearboxes_Models_Application",
                        column: x => x.Application,
                        principalTable: "Models",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Gearboxes",
                columns: new[] { "Id", "Application", "Descritpion", "ImageUrl", "Manufacturer", "Name", "Speeds", "TransmissionType", "YearsProduced" },
                values: new object[] { new Guid("c0148c8d-e787-411c-aab8-dc53545fcad4"), new Guid("79a4d785-273d-488d-b7fe-f9ab58c405bf"), "The ZF 8HP transmission is ZF Friedrichshafen AG's trademark name for its 8-speed automatic transmission models for longitudinal engine applications. The name is short for 8-speed transmission with hydraulic converter and planetary gearsets. Designed and first built by ZF's subsidiary in Saarbrücken, Germany, it debuted in 2008 on the BMW 7 Series (F01) 760Li sedan fitted with the V12 engine. BMW remains a major customer for the transmission.", "https://hips.hearstapps.com/hmg-prod/images/zf-8-speed-trans-1538511984.jpg", "ZF Friedrichshafen", "ZF 8HP Transmission", 8, "Automatic", "2008-Present" });

            

            migrationBuilder.CreateIndex(
                name: "IX_Gearboxes_Application",
                table: "Gearboxes",
                column: "Application");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Gearboxes");
        }
    }
}
