using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoHub.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb : Migration
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

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "Description", "FoundedBy", "FoundedDate", "ImageUrl", "Name" },
                values: new object[] { new Guid("c58fd1d3-2b19-45de-8543-ef03ad3e416b"), "Automobili Lamborghini is an Italian manufacturer of luxury sports cars and SUVs based in Sant'Agata Bolognese. The company is owned by the Volkswagen Group through its subsidiary Audi.", "Ferruccio Lamborghini", new DateTime(1963, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://www.google.com/url?sa=i&url=https%3A%2F%2Fen.wikipedia.org%2Fwiki%2FLamborghini&psig=AOvVaw3CXwortwq3tXlmsmsiEvwG&ust=1730511694438000&source=images&cd=vfe&opi=89978449&ved=0CBQQjRxqFwoTCJDv_MiAuokDFQAAAAAdAAAAABAE", "Lamborghini" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Brands");
        }
    }
}
