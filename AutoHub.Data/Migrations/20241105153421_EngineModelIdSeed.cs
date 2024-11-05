using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoHub.Data.Migrations
{
    /// <inheritdoc />
    public partial class EngineModelIdSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Deleting existing seed data
            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("21a8df08-1b29-4419-a541-8fb7aca3daa8"));

            migrationBuilder.DeleteData(
                table: "Engines",
                keyColumn: "Id",
                keyValue: new Guid("0ac19290-486f-41d5-9d78-c4953dc37ec4"));

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: new Guid("db8d32aa-5814-4755-b257-856a086e2974"));

            // Adding ModelId column without a default value
            migrationBuilder.AddColumn<Guid>(
                name: "ModelId",
                table: "Engines",
                type: "uniqueidentifier",
                nullable: false,
                comment: "FK To VehicleModel");

            // Inserting Brands first
            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "Description", "FoundedBy", "FoundedDate", "ImageUrl", "Name" },
                values: new object[] { new Guid("8b1c8b74-e13b-4dd6-ac6e-8692c57e6fe0"), "Automobili Lamborghini is an Italian manufacturer of luxury sports cars and SUVs based in Sant'Agata Bolognese. The company is owned by the Volkswagen Group through its subsidiary Audi.", "Ferruccio Lamborghini", new DateTime(1963, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://www.brandcrowd.com/blog/wp-content/uploads/2023/05/Lamborghini-logo-1-1024x819.jpg", "Lamborghini" });

            // Inserting Models second
            migrationBuilder.InsertData(
                table: "Models",
                columns: new[] { "Id", "BrandId", "Description", "FuelType", "GasConsumption", "HorsePower", "ImageUrl", "Name", "Year" },
                values: new object[] { new Guid("348de990-d33a-4271-a79e-2820bf517459"), new Guid("8b1c8b74-e13b-4dd6-ac6e-8692c57e6fe0"), "The BMW 340i Sedan offers a powerful engine, refined handling, and luxury features.", "Petrol", 7.2m, 320, "https://i.pinimg.com/736x/ef/06/9e/ef069ec0aecb59c7858a19508b691b85.jpg", "BMW 340i Sedan", 2016 });

            // Inserting Engines third, with a valid ModelId
            migrationBuilder.InsertData(
                table: "Engines",
                columns: new[] { "Id", "BrandId", "Cylinders", "ImageUrl", "ModelId", "Name", "PowerOutput", "Rpm", "Torque", "ValvetrainDriveSystem", "YearsProduction" },
                values: new object[] { new Guid("8f228c64-39b2-4f28-824a-4aacec167362"), new Guid("8b1c8b74-e13b-4dd6-ac6e-8692c57e6fe0"), 6, "https://fsc.codes/cdn/shop/articles/BMW-B58.jpg?v=1703197166", new Guid("348de990-d33a-4271-a79e-2820bf517459"), "B58", "322-385hp", "7000", "450-500Nm", "Chain", "2015-Present" });

            // Adding index and foreign key after data insertion
            migrationBuilder.CreateIndex(
                name: "IX_Engines_ModelId",
                table: "Engines",
                column: "ModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Engines_Models_ModelId",
                table: "Engines",
                column: "ModelId",
                principalTable: "Models",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Engines_Models_ModelId",
                table: "Engines");

            migrationBuilder.DropIndex(
                name: "IX_Engines_ModelId",
                table: "Engines");

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("8b1c8b74-e13b-4dd6-ac6e-8692c57e6fe0"));

            migrationBuilder.DeleteData(
                table: "Engines",
                keyColumn: "Id",
                keyValue: new Guid("8f228c64-39b2-4f28-824a-4aacec167362"));

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: new Guid("9ab813d3-f098-4c7d-b821-c7f972dcee7a"));

            migrationBuilder.DropColumn(
                name: "ModelId",
                table: "Engines");

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
        }
    }
}
