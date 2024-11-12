﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AutoHub.Data.Migrations
{
    /// <inheritdoc />
    public partial class NewEntities : Migration
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
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "Bool to check if the product is deleted")
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
                });

            migrationBuilder.CreateTable(
                name: "ProductClients",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Identifier of the product"),
                    ClientId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Identifier of the client")
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
                });

          

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("077550e5-d63f-48f7-a5f2-b37207c3735f"), "Braking System" },
                    { new Guid("0c3689e7-6a62-4296-beac-3f81388df7c1"), "Filters" },
                    { new Guid("1cbe1371-212a-4221-ab4a-2cebbb62f917"), "Engine Parts" },
                    { new Guid("2060d6bc-46dc-4e89-a307-8e91682a0410"), "Cooling System" },
                    { new Guid("de2aecbe-f4c3-4f94-914f-bf45e98ff22c"), "Steering System" },
                    { new Guid("ef4bfb65-b43e-43cf-b162-df40afe65f02"), "Motor Oil" }
                });

      

            migrationBuilder.CreateIndex(
                name: "IX_ProductClients_ClientId",
                table: "ProductClients",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

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
