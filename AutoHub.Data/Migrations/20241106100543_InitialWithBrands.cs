using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AutoHub.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialWithBrands : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Identifier of the brand"),
                    Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false, comment: "Name of the brand"),
                    FoundedBy = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false, comment: "Name of the founder/s"),
                    FoundedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false, comment: "Text for a little info about the company"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Models",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Identifier of the model"),
                    Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false, comment: "Name of the model"),
                    Year = table.Column<int>(type: "int", nullable: false, comment: "Year the model was released"),
                    HorsePower = table.Column<int>(type: "int", nullable: false, comment: "Horsepower of the vehicle"),
                    FuelType = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false, comment: "Fuel type of the vehicle"),
                    GasConsumption = table.Column<decimal>(type: "decimal(5,2)", nullable: false, comment: "Gas consumption per 100km"),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false, comment: "Description about the model"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrandId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Foreign Key to Brand one model can have one brand")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Models", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Models_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Engines",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Identifier of engine"),
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false, comment: "Name of engine"),
                    BrandId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "FK Manufacturer of engine"),
                    ModelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "FK To VehicleModel"),
                    Cylinders = table.Column<int>(type: "int", nullable: false, comment: "Cylinder of engine"),
                    ValvetrainDriveSystem = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false, comment: "Chain"),
                    PowerOutput = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Horsepower of engine"),
                    Torque = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Torque of engine"),
                    Rpm = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Maximum output of engine"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Image of engine"),
                    YearsProduction = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Date started and ended of engine")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Engines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Engines_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Engines_Models_ModelId",
                        column: x => x.ModelId,
                        principalTable: "Models",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "Description", "FoundedBy", "FoundedDate", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { new Guid("148c36a7-5930-4ce3-8bb0-658fd772c423"), "BMW is a German company with activities covering the production and sale of motor vehicles, spare parts and accessories for motor vehicles, engineering products, as well as related services.", "Karl Rapp , Gustav Otto , Camillo Castiglioni , Franz Josef Pop", new DateTime(1916, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://www.carmonkey.co.uk/images/logos/Bmw-logo.svg", "BMW" },
                    { new Guid("60caba99-72aa-421a-a569-7cb41423a3ee"), "Automobili Lamborghini is an Italian manufacturer of luxury sports cars and SUVs based in Sant'Agata Bolognese. The company is owned by the Volkswagen Group through its subsidiary Audi.", "Ferruccio Lamborghini", new DateTime(1963, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://www.brandcrowd.com/blog/wp-content/uploads/2023/05/Lamborghini-logo-1-1024x819.jpg", "Lamborghini" },
                    { new Guid("c6d8e95b-d57f-4b15-bc7d-2f1ad38a17a9"), "Mercedes-Benz is a trademark and a company of the same name - a manufacturer of premium cars, trucks, buses and other vehicles, which is part of the German concern \"Mercedes-Benz Group\". It is one of the most recognizable car brands in the world.", "Karl Benz, Gottlieb Daimler, Wilhelm Maybach and Emil Jellinek", new DateTime(1926, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://1000logos.net/wp-content/uploads/2018/04/Symbol-Mercedes-Benz.png", "Mercedes-Benz" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Engines_BrandId",
                table: "Engines",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Engines_ModelId",
                table: "Engines",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Models_BrandId",
                table: "Models",
                column: "BrandId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Engines");

            migrationBuilder.DropTable(
                name: "Models");

            migrationBuilder.DropTable(
                name: "Brands");
        }
    }
}
