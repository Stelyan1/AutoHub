using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AutoHub.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

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
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                        onDelete: ReferentialAction.Cascade);
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
                table: "Brands",
                columns: new[] { "Id", "Description", "FoundedBy", "FoundedDate", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { new Guid("3b8c377c-e11c-4db3-be77-94e81003d144"), "Automobili Lamborghini is an Italian manufacturer of luxury sports cars and SUVs based in Sant'Agata Bolognese. The company is owned by the Volkswagen Group through its subsidiary Audi.", "Ferruccio Lamborghini", new DateTime(1963, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://www.brandcrowd.com/blog/wp-content/uploads/2023/05/Lamborghini-logo-1-1024x819.jpg", "Lamborghini" },
                    { new Guid("ab9cbdf6-ec2f-4fed-bf77-fe08e0c691e4"), "Mercedes-Benz is a trademark and a company of the same name - a manufacturer of premium cars, trucks, buses and other vehicles, which is part of the German concern \"Mercedes-Benz Group\". It is one of the most recognizable car brands in the world.", "Karl Benz, Gottlieb Daimler, Wilhelm Maybach and Emil Jellinek", new DateTime(1926, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://1000logos.net/wp-content/uploads/2018/04/Symbol-Mercedes-Benz.png", "Mercedes-Benz" },
                    { new Guid("bcd65fac-8a51-4847-aeda-8f5e69c61ea5"), "BMW is a German company with activities covering the production and sale of motor vehicles, spare parts and accessories for motor vehicles, engineering products, as well as related services.", "Karl Rapp , Gustav Otto , Camillo Castiglioni , Franz Josef Pop", new DateTime(1916, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://www.carmonkey.co.uk/images/logos/Bmw-logo.svg", "BMW" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("203cc880-da60-4009-917a-3bf12c835708"), "Steering System" },
                    { new Guid("33e08547-94b6-49f6-915e-8ca799814ba7"), "Filters" },
                    { new Guid("3b37ddc8-8d17-47ac-8dc6-4c183e94f8bc"), "Motor Oil" },
                    { new Guid("429adbc4-55f2-44d8-b54c-7a6a1e3c4a09"), "Cooling System" },
                    { new Guid("8ce92c95-f3c2-4fd0-816c-7a949ef1f6b7"), "Braking System" },
                    { new Guid("c60229d8-9448-450e-9b1a-0c7d037fa501"), "Engine Parts" }
                });

            migrationBuilder.InsertData(
                table: "Models",
                columns: new[] { "Id", "BrandId", "Description", "FuelType", "GasConsumption", "HorsePower", "ImageUrl", "Name", "Year" },
                values: new object[,]
                {
                    { new Guid("19b20918-c614-43cd-90fe-a4d07e4a20e3"), new Guid("bcd65fac-8a51-4847-aeda-8f5e69c61ea5"), "The BMW 340i Sedan offers a powerful engine, refined handling, and luxury features.", "Petrol", 7.2m, 320, "https://i.pinimg.com/736x/ef/06/9e/ef069ec0aecb59c7858a19508b691b85.jpg", "BMW 340i Sedan", 2016 },
                    { new Guid("a42260fc-1c1f-4fea-92d9-700049abd87e"), new Guid("ab9cbdf6-ec2f-4fed-bf77-fe08e0c691e4"), "The output of the AMG 6.3-litre V8 engine is unchanged at 336 kW (457 hp) and can be increased to a maximum of 358 kW (487 hp) with the optional AMG Performance package. Agility, grip and ride comfort have been enhanced as a result of numerous measures to optimise the AMG sports suspension.", "Petrol", 13.2m, 487, "https://cdn.dealeraccelerate.com/bagauction/1/11/153/1920x1440/2012-mercedes-benz-c63-amg-black-series", "Mercedes-Benz C63 AMG", 2012 },
                    { new Guid("f3d1721b-0472-4c63-8952-5319697c7a33"), new Guid("3b8c377c-e11c-4db3-be77-94e81003d144"), "Lamborghini created the Aventador SVJ to embrace challenges head-on, combining cutting-edge technology with extraordinary design, while always refusing to compromise. In a future driven by technology, it’s easy to lose the genuine thrill of driving. But in the future shaped by Lamborghini, this won’t be left behind, because there will always be a driver behind the wheel. ", "Petrol", 15.1m, 770, "https://supercars.bg/wp-content/uploads/2018/08/Lamborghini-Aventador-SV-R-Nurburgring21.jpg", "Lamborghini Aventador ", 2016 }
                });

            migrationBuilder.InsertData(
                table: "Engines",
                columns: new[] { "Id", "BrandId", "Cylinders", "ImageUrl", "ModelId", "Name", "PowerOutput", "Rpm", "Torque", "ValvetrainDriveSystem", "YearsProduction" },
                values: new object[] { new Guid("f9eebc76-754c-48a3-b0c3-d064cab8637b"), new Guid("bcd65fac-8a51-4847-aeda-8f5e69c61ea5"), 6, "https://fsc.codes/cdn/shop/articles/BMW-B58.jpg?v=1703197166", new Guid("19b20918-c614-43cd-90fe-a4d07e4a20e3"), "B58", "322-385hp", "7000", "450-500Nm", "Chain", "2015-Present" });

            migrationBuilder.InsertData(
                table: "Gearboxes",
                columns: new[] { "Id", "Application", "Description", "ImageUrl", "Manufacturer", "Name", "Speeds", "TransmissionType", "YearsProduced" },
                values: new object[] { new Guid("796cac38-f3e9-429d-b0ab-e1042f879c7a"), new Guid("19b20918-c614-43cd-90fe-a4d07e4a20e3"), "The ZF 8HP transmission is ZF Friedrichshafen AG's trademark name for its 8-speed automatic transmission models for longitudinal engine applications. The name is short for 8-speed transmission with hydraulic converter and planetary gearsets. Designed and first built by ZF's subsidiary in Saarbrücken, Germany, it debuted in 2008 on the BMW 7 Series (F01) 760Li sedan fitted with the V12 engine. BMW remains a major customer for the transmission.", "https://hips.hearstapps.com/hmg-prod/images/zf-8-speed-trans-1538511984.jpg", "ZF Friedrichshafen", "ZF 8HP Transmission", 8, "Automatic", "2008-Present" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Engines_BrandId",
                table: "Engines",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Engines_ModelId",
                table: "Engines",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Gearboxes_Application",
                table: "Gearboxes",
                column: "Application");

            migrationBuilder.CreateIndex(
                name: "IX_Models_BrandId",
                table: "Models",
                column: "BrandId");

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
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Engines");

            migrationBuilder.DropTable(
                name: "Gearboxes");

            migrationBuilder.DropTable(
                name: "ProductClients");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Models");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
