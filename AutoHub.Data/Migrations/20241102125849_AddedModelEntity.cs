using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoHub.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedModelEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("c58fd1d3-2b19-45de-8543-ef03ad3e416b"));

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
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "Description", "FoundedBy", "FoundedDate", "ImageUrl", "Name" },
                values: new object[] { new Guid("9850d167-91f4-4a59-af0d-5055c6310507"), "Automobili Lamborghini is an Italian manufacturer of luxury sports cars and SUVs based in Sant'Agata Bolognese. The company is owned by the Volkswagen Group through its subsidiary Audi.", "Ferruccio Lamborghini", new DateTime(1963, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://www.google.com/url?sa=i&url=https%3A%2F%2Fen.wikipedia.org%2Fwiki%2FLamborghini&psig=AOvVaw3CXwortwq3tXlmsmsiEvwG&ust=1730511694438000&source=images&cd=vfe&opi=89978449&ved=0CBQQjRxqFwoTCJDv_MiAuokDFQAAAAAdAAAAABAE", "Lamborghini" });

            migrationBuilder.InsertData(
                table: "Models",
                columns: new[] { "Id", "BrandId", "Description", "FuelType", "GasConsumption", "HorsePower", "ImageUrl", "Name", "Year" },
                values: new object[] { new Guid("348de990-d33a-4271-a79e-2820bf517459"), new Guid("c5bff384-4440-480a-b62f-e544ea4b8b05"), "The BMW 340i Sedan offers a powerful engine, refined handling, and luxury features.", "Petrol", 7.2m, 320, "https://i.pinimg.com/736x/ef/06/9e/ef069ec0aecb59c7858a19508b691b85.jpg", "BMW 340i Sedan", 2016 });

            migrationBuilder.CreateIndex(
                name: "IX_Models_BrandId",
                table: "Models",
                column: "BrandId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Models");

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("9850d167-91f4-4a59-af0d-5055c6310507"));

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "Description", "FoundedBy", "FoundedDate", "ImageUrl", "Name" },
                values: new object[] { new Guid("c58fd1d3-2b19-45de-8543-ef03ad3e416b"), "Automobili Lamborghini is an Italian manufacturer of luxury sports cars and SUVs based in Sant'Agata Bolognese. The company is owned by the Volkswagen Group through its subsidiary Audi.", "Ferruccio Lamborghini", new DateTime(1963, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://www.google.com/url?sa=i&url=https%3A%2F%2Fen.wikipedia.org%2Fwiki%2FLamborghini&psig=AOvVaw3CXwortwq3tXlmsmsiEvwG&ust=1730511694438000&source=images&cd=vfe&opi=89978449&ved=0CBQQjRxqFwoTCJDv_MiAuokDFQAAAAAdAAAAABAE", "Lamborghini" });
        }
    }
}
