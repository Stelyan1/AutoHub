using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AutoHub.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddEngines : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           

     
            migrationBuilder.InsertData(
                table: "Engines",
                columns: new[] { "Id", "BrandId", "Cylinders", "ImageUrl", "ModelId", "Name", "PowerOutput", "Rpm", "Torque", "ValvetrainDriveSystem", "YearsProduction" },
                values: new object[] { new Guid("fa4a1b22-b08f-4d62-a05a-2a615a24a435"), new Guid("148c36a7-5930-4ce3-8bb0-658fd772c423"), 6, "https://fsc.codes/cdn/shop/articles/BMW-B58.jpg?v=1703197166", new Guid("79a4d785-273d-488d-b7fe-f9ab58c405bf"), "B58", "322-385hp", "7000", "450-500Nm", "Chain", "2015-Present" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("8040eadf-4452-4920-b282-b9dd83d4300a"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("ed1aacf0-b0df-4999-83e2-a797be506a13"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("f65f0613-ea00-4a8a-9fff-23a564819251"));

            migrationBuilder.DeleteData(
                table: "Engines",
                keyColumn: "Id",
                keyValue: new Guid("fa4a1b22-b08f-4d62-a05a-2a615a24a435"));

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: new Guid("a4748b31-ad2a-4017-b4c8-04c357a7c970"));

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: new Guid("b6b85877-189e-4e31-97d0-9fc4692d25f3"));

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: new Guid("f128ebea-c90b-476d-ad71-a82e20812f31"));

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "Description", "FoundedBy", "FoundedDate", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { new Guid("1f76e638-ec34-4a65-adff-b7b214660e91"), "Mercedes-Benz is a trademark and a company of the same name - a manufacturer of premium cars, trucks, buses and other vehicles, which is part of the German concern \"Mercedes-Benz Group\". It is one of the most recognizable car brands in the world.", "Karl Benz, Gottlieb Daimler, Wilhelm Maybach and Emil Jellinek", new DateTime(1926, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://1000logos.net/wp-content/uploads/2018/04/Symbol-Mercedes-Benz.png", "Mercedes-Benz" },
                    { new Guid("2eb5c446-1134-438c-9ddf-6ad443b93bb9"), "Automobili Lamborghini is an Italian manufacturer of luxury sports cars and SUVs based in Sant'Agata Bolognese. The company is owned by the Volkswagen Group through its subsidiary Audi.", "Ferruccio Lamborghini", new DateTime(1963, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://www.brandcrowd.com/blog/wp-content/uploads/2023/05/Lamborghini-logo-1-1024x819.jpg", "Lamborghini" },
                    { new Guid("b10c5b3b-f669-4907-a333-c1069400e28e"), "BMW is a German company with activities covering the production and sale of motor vehicles, spare parts and accessories for motor vehicles, engineering products, as well as related services.", "Karl Rapp , Gustav Otto , Camillo Castiglioni , Franz Josef Pop", new DateTime(1916, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://www.carmonkey.co.uk/images/logos/Bmw-logo.svg", "BMW" }
                });

            migrationBuilder.InsertData(
                table: "Models",
                columns: new[] { "Id", "BrandId", "Description", "FuelType", "GasConsumption", "HorsePower", "ImageUrl", "Name", "Year" },
                values: new object[,]
                {
                    { new Guid("03672b2f-f248-415b-9e00-1f10181523ce"), new Guid("60caba99-72aa-421a-a569-7cb41423a3ee"), "Lamborghini created the Aventador SVJ to embrace challenges head-on, combining cutting-edge technology with extraordinary design, while always refusing to compromise. In a future driven by technology, it’s easy to lose the genuine thrill of driving. But in the future shaped by Lamborghini, this won’t be left behind, because there will always be a driver behind the wheel. ", "Petrol", 15.1m, 770, "https://www.lamborghini.com/sites/it-en/files/DAM/lamborghini/facelift_2019/model_detail/aventador/svj/2021/03_19/aventador_svj_s2.jpg", "Lamborghini Aventador ", 2016 },
                    { new Guid("79a4d785-273d-488d-b7fe-f9ab58c405bf"), new Guid("148c36a7-5930-4ce3-8bb0-658fd772c423"), "The BMW 340i Sedan offers a powerful engine, refined handling, and luxury features.", "Petrol", 7.2m, 320, "https://i.pinimg.com/736x/ef/06/9e/ef069ec0aecb59c7858a19508b691b85.jpg", "BMW 340i Sedan", 2016 },
                    { new Guid("a8a0b50a-c87a-41bc-a5d7-cb8339ab605a"), new Guid("c6d8e95b-d57f-4b15-bc7d-2f1ad38a17a9"), "The output of the AMG 6.3-litre V8 engine is unchanged at 336 kW (457 hp) and can be increased to a maximum of 358 kW (487 hp) with the optional AMG Performance package. Agility, grip and ride comfort have been enhanced as a result of numerous measures to optimise the AMG sports suspension.", "Petrol", 13.2m, 487, "https://cdn.dealeraccelerate.com/bagauction/1/11/153/1920x1440/2012-mercedes-benz-c63-amg-black-series", "Mercedes-Benz C63 AMG", 2012 }
                });
        }
    }
}
