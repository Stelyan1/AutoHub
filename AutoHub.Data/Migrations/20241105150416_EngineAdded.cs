using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoHub.Data.Migrations
{
    /// <inheritdoc />
    public partial class EngineAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("9850d167-91f4-4a59-af0d-5055c6310507"));

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: new Guid("348de990-d33a-4271-a79e-2820bf517459"));

            migrationBuilder.CreateTable(
                name: "Engines",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Identifier of engine"),
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false, comment: "Name of engine"),
                    BrandId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "FK Manufacturer of engine"),
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
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "Description", "FoundedBy", "FoundedDate", "ImageUrl", "Name" },
                values: new object[] { new Guid("21a8df08-1b29-4419-a541-8fb7aca3daa8"), "Automobili Lamborghini is an Italian manufacturer of luxury sports cars and SUVs based in Sant'Agata Bolognese. The company is owned by the Volkswagen Group through its subsidiary Audi.", "Ferruccio Lamborghini", new DateTime(1963, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://www.brandcrowd.com/blog/wp-content/uploads/2023/05/Lamborghini-logo-1-1024x819.jpg", "Lamborghini" });

            migrationBuilder.InsertData(
                table: "Engines",
                columns: new[] { "Id", "BrandId", "Cylinders", "ImageUrl", "Name", "PowerOutput", "Rpm", "Torque", "ValvetrainDriveSystem", "YearsProduction" },
                values: new object[] { new Guid("0ac19290-486f-41d5-9d78-c4953dc37ec4"), new Guid("c5bff384-4440-480a-b62f-e544ea4b8b05"), 6, "https://fsc.codes/cdn/shop/articles/BMW-B58.jpg?v=1703197166", "B58", "322-385hp", "7000", "450-500Nm", "Chain", "2015-Present" });

            migrationBuilder.InsertData(
                table: "Models",
                columns: new[] { "Id", "BrandId", "Description", "FuelType", "GasConsumption", "HorsePower", "ImageUrl", "Name", "Year" },
                values: new object[] { new Guid("db8d32aa-5814-4755-b257-856a086e2974"), new Guid("c5bff384-4440-480a-b62f-e544ea4b8b05"), "The BMW 340i Sedan offers a powerful engine, refined handling, and luxury features.", "Petrol", 7.2m, 320, "https://i.pinimg.com/736x/ef/06/9e/ef069ec0aecb59c7858a19508b691b85.jpg", "BMW 340i Sedan", 2016 });

            migrationBuilder.CreateIndex(
                name: "IX_Engines_BrandId",
                table: "Engines",
                column: "BrandId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Engines");

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("21a8df08-1b29-4419-a541-8fb7aca3daa8"));

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: new Guid("db8d32aa-5814-4755-b257-856a086e2974"));

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "Description", "FoundedBy", "FoundedDate", "ImageUrl", "Name" },
                values: new object[] { new Guid("9850d167-91f4-4a59-af0d-5055c6310507"), "Automobili Lamborghini is an Italian manufacturer of luxury sports cars and SUVs based in Sant'Agata Bolognese. The company is owned by the Volkswagen Group through its subsidiary Audi.", "Ferruccio Lamborghini", new DateTime(1963, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://www.google.com/url?sa=i&url=https%3A%2F%2Fen.wikipedia.org%2Fwiki%2FLamborghini&psig=AOvVaw3CXwortwq3tXlmsmsiEvwG&ust=1730511694438000&source=images&cd=vfe&opi=89978449&ved=0CBQQjRxqFwoTCJDv_MiAuokDFQAAAAAdAAAAABAE", "Lamborghini" });

            migrationBuilder.InsertData(
                table: "Models",
                columns: new[] { "Id", "BrandId", "Description", "FuelType", "GasConsumption", "HorsePower", "ImageUrl", "Name", "Year" },
                values: new object[] { new Guid("348de990-d33a-4271-a79e-2820bf517459"), new Guid("c5bff384-4440-480a-b62f-e544ea4b8b05"), "The BMW 340i Sedan offers a powerful engine, refined handling, and luxury features.", "Petrol", 7.2m, 320, "https://i.pinimg.com/736x/ef/06/9e/ef069ec0aecb59c7858a19508b691b85.jpg", "BMW 340i Sedan", 2016 });
        }
    }
}
