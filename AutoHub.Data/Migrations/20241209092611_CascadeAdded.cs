using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AutoHub.Data.Migrations
{
    /// <inheritdoc />
    public partial class CascadeAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("8b0004fe-3acf-487c-84e1-0c53d5d105ec"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("a819fa84-8ca3-4ea3-bf8d-705894f2e103"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("e7192d7a-2ecd-46f9-be8c-1768765e7166"));

            migrationBuilder.DeleteData(
                table: "Engines",
                keyColumn: "Id",
                keyValue: new Guid("e8877832-cf2e-402a-8595-80f4386849b5"));

            migrationBuilder.DeleteData(
                table: "Gearboxes",
                keyColumn: "Id",
                keyValue: new Guid("d2825469-a972-46d1-8ca2-622538802ad2"));

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: new Guid("1819df5b-bf5c-4365-ad43-f6891ef6484e"));

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: new Guid("1ae6fe9a-a1e1-4f1c-9a8d-2cdb789e6a04"));

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: new Guid("a9ac624d-6cf5-4d9f-8a96-3d77519a9bda"));

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "Description", "FoundedBy", "FoundedDate", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { new Guid("13dcf9bf-f6ee-4da2-a734-30efd1c83ecc"), "Automobili Lamborghini is an Italian manufacturer of luxury sports cars and SUVs based in Sant'Agata Bolognese. The company is owned by the Volkswagen Group through its subsidiary Audi.", "Ferruccio Lamborghini", new DateTime(1963, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://www.brandcrowd.com/blog/wp-content/uploads/2023/05/Lamborghini-logo-1-1024x819.jpg", "Lamborghini" },
                    { new Guid("9aaa1db2-5e63-434f-898f-9ee91b0fd978"), "BMW is a German company with activities covering the production and sale of motor vehicles, spare parts and accessories for motor vehicles, engineering products, as well as related services.", "Karl Rapp , Gustav Otto , Camillo Castiglioni , Franz Josef Pop", new DateTime(1916, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://www.carmonkey.co.uk/images/logos/Bmw-logo.svg", "BMW" },
                    { new Guid("d8f02672-ea8f-4cbf-88a7-9c9e43777681"), "Mercedes-Benz is a trademark and a company of the same name - a manufacturer of premium cars, trucks, buses and other vehicles, which is part of the German concern \"Mercedes-Benz Group\". It is one of the most recognizable car brands in the world.", "Karl Benz, Gottlieb Daimler, Wilhelm Maybach and Emil Jellinek", new DateTime(1926, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://1000logos.net/wp-content/uploads/2018/04/Symbol-Mercedes-Benz.png", "Mercedes-Benz" }
                });

           

            migrationBuilder.InsertData(
               table: "Models",
               columns: new[] { "Id", "BrandId", "Description", "FuelType", "GasConsumption", "HorsePower", "ImageUrl", "Name", "Year" },
               values: new object[,]
               {
                    { new Guid("b17cd3a8-95b3-4c46-8b99-d143a0ddbe20"), new Guid("9aaa1db2-5e63-434f-898f-9ee91b0fd978"), "The BMW 340i Sedan offers a powerful engine, refined handling, and luxury features.", "Petrol", 7.2m, 320, "https://i.pinimg.com/736x/ef/06/9e/ef069ec0aecb59c7858a19508b691b85.jpg", "BMW 340i Sedan", 2016 },
                    { new Guid("dca9518d-8f81-41d0-a8ba-472536d04514"), new Guid("d8f02672-ea8f-4cbf-88a7-9c9e43777681"), "The output of the AMG 6.3-litre V8 engine is unchanged at 336 kW (457 hp) and can be increased to a maximum of 358 kW (487 hp) with the optional AMG Performance package. Agility, grip and ride comfort have been enhanced as a result of numerous measures to optimise the AMG sports suspension.", "Petrol", 13.2m, 487, "https://cdn.dealeraccelerate.com/bagauction/1/11/153/1920x1440/2012-mercedes-benz-c63-amg-black-series", "Mercedes-Benz C63 AMG", 2012 },
                    { new Guid("dd1703e4-2e45-48e3-a48e-a73521725206"), new Guid("13dcf9bf-f6ee-4da2-a734-30efd1c83ecc"), "Lamborghini created the Aventador SVJ to embrace challenges head-on, combining cutting-edge technology with extraordinary design, while always refusing to compromise. In a future driven by technology, it’s easy to lose the genuine thrill of driving. But in the future shaped by Lamborghini, this won’t be left behind, because there will always be a driver behind the wheel. ", "Petrol", 15.1m, 770, "https://supercars.bg/wp-content/uploads/2018/08/Lamborghini-Aventador-SV-R-Nurburgring21.jpg", "Lamborghini Aventador ", 2016 }
               });

            migrationBuilder.InsertData(
                table: "Engines",
                columns: new[] { "Id", "BrandId", "Cylinders", "ImageUrl", "ModelId", "Name", "PowerOutput", "Rpm", "Torque", "ValvetrainDriveSystem", "YearsProduction" },
                values: new object[] { new Guid("1ab9f9b6-2cc3-415b-8718-6776815bcbf9"), new Guid("9aaa1db2-5e63-434f-898f-9ee91b0fd978"), 6, "https://fsc.codes/cdn/shop/articles/BMW-B58.jpg?v=1703197166", new Guid("b17cd3a8-95b3-4c46-8b99-d143a0ddbe20"), "B58", "322-385hp", "7000", "450-500Nm", "Chain", "2015-Present" });

            migrationBuilder.InsertData(
                table: "Gearboxes",
                columns: new[] { "Id", "Application", "Description", "ImageUrl", "Manufacturer", "Name", "Speeds", "TransmissionType", "YearsProduced" },
                values: new object[] { new Guid("611d4e13-9568-4c10-9178-656131e3a2d4"), new Guid("b17cd3a8-95b3-4c46-8b99-d143a0ddbe20"), "The ZF 8HP transmission is ZF Friedrichshafen AG's trademark name for its 8-speed automatic transmission models for longitudinal engine applications. The name is short for 8-speed transmission with hydraulic converter and planetary gearsets. Designed and first built by ZF's subsidiary in Saarbrücken, Germany, it debuted in 2008 on the BMW 7 Series (F01) 760Li sedan fitted with the V12 engine. BMW remains a major customer for the transmission.", "https://hips.hearstapps.com/hmg-prod/images/zf-8-speed-trans-1538511984.jpg", "ZF Friedrichshafen", "ZF 8HP Transmission", 8, "Automatic", "2008-Present" });

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("13dcf9bf-f6ee-4da2-a734-30efd1c83ecc"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("9aaa1db2-5e63-434f-898f-9ee91b0fd978"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("d8f02672-ea8f-4cbf-88a7-9c9e43777681"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("26ebe960-2d8c-486f-8dde-912946bb1981"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("67db8a84-6942-4484-83e1-74dbb28e8a45"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("6f7f81a9-a4cb-4d01-a000-4b516d4fc3a8"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("89f32ac1-c092-42cc-af5d-bccae0fc7e11"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("cc72aecd-7d36-4123-9d1e-10535c7091df"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("f13d9b3f-0e0d-4307-9eb4-fe2f2f7ac35f"));

            migrationBuilder.DeleteData(
                table: "Engines",
                keyColumn: "Id",
                keyValue: new Guid("1ab9f9b6-2cc3-415b-8718-6776815bcbf9"));

            migrationBuilder.DeleteData(
                table: "Gearboxes",
                keyColumn: "Id",
                keyValue: new Guid("611d4e13-9568-4c10-9178-656131e3a2d4"));

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: new Guid("b17cd3a8-95b3-4c46-8b99-d143a0ddbe20"));

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: new Guid("dca9518d-8f81-41d0-a8ba-472536d04514"));

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: new Guid("dd1703e4-2e45-48e3-a48e-a73521725206"));
        }
    }
}
