﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AutoHub.Data.Migrations
{
    /// <inheritdoc />
    public partial class Intitial : Migration
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
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Engines_Models_ModelId",
                        column: x => x.ModelId,
                        principalTable: "Models",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

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
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false, comment: "Description about the gearbox"),
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
                table: "Brands",
                columns: new[] { "Id", "Description", "FoundedBy", "FoundedDate", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { new Guid("15bb0aa4-68e4-4825-b7c7-be2bd81486cf"), "BMW is a German company with activities covering the production and sale of motor vehicles, spare parts and accessories for motor vehicles, engineering products, as well as related services.", "Karl Rapp , Gustav Otto , Camillo Castiglioni , Franz Josef Pop", new DateTime(1916, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://www.carmonkey.co.uk/images/logos/Bmw-logo.svg", "BMW" },
                    { new Guid("23f400ca-e9b8-464f-88be-c779f52d58fd"), "Mercedes-Benz is a trademark and a company of the same name - a manufacturer of premium cars, trucks, buses and other vehicles, which is part of the German concern \"Mercedes-Benz Group\". It is one of the most recognizable car brands in the world.", "Karl Benz, Gottlieb Daimler, Wilhelm Maybach and Emil Jellinek", new DateTime(1926, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://1000logos.net/wp-content/uploads/2018/04/Symbol-Mercedes-Benz.png", "Mercedes-Benz" },
                    { new Guid("fe35bc43-0785-48b6-95bd-f65c129bea9d"), "Automobili Lamborghini is an Italian manufacturer of luxury sports cars and SUVs based in Sant'Agata Bolognese. The company is owned by the Volkswagen Group through its subsidiary Audi.", "Ferruccio Lamborghini", new DateTime(1963, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://www.brandcrowd.com/blog/wp-content/uploads/2023/05/Lamborghini-logo-1-1024x819.jpg", "Lamborghini" }
                });

            migrationBuilder.InsertData(
            table: "Models",
            columns: new[] { "Id", "BrandId", "Description", "FuelType", "GasConsumption", "HorsePower", "ImageUrl", "Name", "Year" },
            values: new object[,]
            {
               { new Guid("6a4f1abb-937f-470d-a3f5-728efd64cc86"), new Guid("15bb0aa4-68e4-4825-b7c7-be2bd81486cf"), "The BMW 340i Sedan offers a powerful engine, refined handling, and luxury features.", "Petrol", 7.2m, 320, "https://i.pinimg.com/736x/ef/06/9e/ef069ec0aecb59c7858a19508b691b85.jpg", "BMW 340i Sedan", 2016 },
               { new Guid("6f76acbf-6b27-4581-8753-2352f9132b60"), new Guid("23f400ca-e9b8-464f-88be-c779f52d58fd"), "The output of the AMG 6.3-litre V8 engine is unchanged at 336 kW (457 hp) and can be increased to a maximum of 358 kW (487 hp) with the optional AMG Performance package. Agility, grip and ride comfort have been enhanced as a result of numerous measures to optimise the AMG sports suspension.", "Petrol", 13.2m, 487, "https://cdn.dealeraccelerate.com/bagauction/1/11/153/1920x1440/2012-mercedes-benz-c63-amg-black-series", "Mercedes-Benz C63 AMG", 2012 },
               { new Guid("ceeb3fb1-0cc4-46ee-9bdd-87044f9b462b"), new Guid("fe35bc43-0785-48b6-95bd-f65c129bea9d"), "Lamborghini created the Aventador SVJ to embrace challenges head-on, combining cutting-edge technology with extraordinary design, while always refusing to compromise. In a future driven by technology, it’s easy to lose the genuine thrill of driving. But in the future shaped by Lamborghini, this won’t be left behind, because there will always be a driver behind the wheel. ", "Petrol", 15.1m, 770, "https://supercars.bg/wp-content/uploads/2018/08/Lamborghini-Aventador-SV-R-Nurburgring21.jpg", "Lamborghini Aventador ", 2016 }
            });

            migrationBuilder.InsertData(
                table: "Engines",
                columns: new[] { "Id", "BrandId", "Cylinders", "ImageUrl", "ModelId", "Name", "PowerOutput", "Rpm", "Torque", "ValvetrainDriveSystem", "YearsProduction" },
                values: new object[] { new Guid("b41f7cb3-e208-4649-b8d6-800f377b6a98"), new Guid("15bb0aa4-68e4-4825-b7c7-be2bd81486cf"), 6, "https://fsc.codes/cdn/shop/articles/BMW-B58.jpg?v=1703197166", new Guid("6a4f1abb-937f-470d-a3f5-728efd64cc86"), "B58", "322-385hp", "7000", "450-500Nm", "Chain", "2015-Present" });


            migrationBuilder.InsertData(
                table: "Gearboxes",
                columns: new[] { "Id", "Application", "Description", "ImageUrl", "Manufacturer", "Name", "Speeds", "TransmissionType", "YearsProduced" },
                values: new object[] { new Guid("fb352ab0-07df-4147-a14d-67e5b13b857f"), new Guid("6a4f1abb-937f-470d-a3f5-728efd64cc86"), "The ZF 8HP transmission is ZF Friedrichshafen AG's trademark name for its 8-speed automatic transmission models for longitudinal engine applications. The name is short for 8-speed transmission with hydraulic converter and planetary gearsets. Designed and first built by ZF's subsidiary in Saarbrücken, Germany, it debuted in 2008 on the BMW 7 Series (F01) 760Li sedan fitted with the V12 engine. BMW remains a major customer for the transmission.", "https://hips.hearstapps.com/hmg-prod/images/zf-8-speed-trans-1538511984.jpg", "ZF Friedrichshafen", "ZF 8HP Transmission", 8, "Automatic", "2008-Present" });

           

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

            migrationBuilder.CreateIndex(
                name: "IX_Gearboxes_Application",
                table: "Gearboxes",
                column: "Application");

            
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Engines");

            migrationBuilder.DropTable(
                name: "Gearboxes");

            migrationBuilder.DropTable(
                name: "Models");

            migrationBuilder.DropTable(
                name: "Brands");
        }
    }
}