using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AutoHub.Data.Migrations
{
    /// <inheritdoc />
    public partial class NewMarketEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           
           

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Identifier of the category"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, comment: "Name of the category")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            
           
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Identifier of the product"),
                    ProductName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false, comment: "Name of the product"),
                    Manufacturer = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false, comment: "Name of the manufacturer"),
                    CarsApplication = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false, comment: "Cars that product can be used for"),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false, comment: "Description about the product"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Price of the product"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Image of the product"),
                    SellerId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Identifier of the Seller"),
                    AddedOn = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date the product was added"),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Identifier of the category"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "Bool to check if the product is deleted"),
                    CategoryId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_AspNetUsers_SellerId",
                        column: x => x.SellerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId1",
                        column: x => x.CategoryId1,
                        principalTable: "Categories",
                        principalColumn: "Id");
                });

          

            

            migrationBuilder.CreateTable(
                name: "ProductClients",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Identifier of the product"),
                    ClientId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Identifier of the client"),
                    ProductId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductClients", x => new { x.ProductId, x.ClientId });
                    table.ForeignKey(
                        name: "FK_ProductClients_AspNetUsers_ClientId",
                        column: x => x.ClientId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductClients_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ProductClients_Products_ProductId1",
                        column: x => x.ProductId1,
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("967f1bac-a1a2-430d-a67c-d8d7eb5bc3d1"), "Cooling System" },
                    { new Guid("ae9de431-4065-4c9c-9c41-288979c28f17"), "Filters" },
                    { new Guid("aea2bca6-4344-4e6b-8f8d-1c8473c05d1e"), "Motor Oil" },
                    { new Guid("c291c0c8-0d22-4af7-b515-5b801ca93ece"), "Braking System" },
                    { new Guid("c5277b28-85e5-4523-941e-d7bfc40f6630"), "Steering System" },
                    { new Guid("c91e74d2-220d-40ba-83e3-e257249d9e5e"), "Engine Parts" }
                });

           

           
            
            migrationBuilder.CreateIndex(
                name: "IX_ProductClients_ClientId",
                table: "ProductClients",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductClients_ProductId1",
                table: "ProductClients",
                column: "ProductId1");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId1",
                table: "Products",
                column: "CategoryId1");

            migrationBuilder.CreateIndex(
                name: "IX_Products_SellerId",
                table: "Products",
                column: "SellerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
          
            migrationBuilder.DropTable(
                name: "ProductClients");

            

            migrationBuilder.DropTable(
                name: "Products");



            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
