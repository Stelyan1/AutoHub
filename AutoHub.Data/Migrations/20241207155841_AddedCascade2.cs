using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AutoHub.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedCascade2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("48e20c6a-afe4-4a84-a494-eda36861cf87"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("c8444b83-9e61-4ef0-ba0f-6eebaa6587f8"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("f5d5808b-ba9d-4b12-a51d-2ffaf41aef1a"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("0399a682-9132-4eea-87d8-b6fd871b5cb7"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("0b18aac8-77ba-481e-afef-dfde25ba2670"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("1fb8d4d2-bfe2-4829-a979-b1734a16a12d"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("9ea49f09-1b99-40df-9111-c26c4b75375e"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("a5f27ad4-0853-4964-9a92-3cd0a484c67e"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("f01c293e-8a02-459e-bd90-9c9d7cc72fda"));

            migrationBuilder.DeleteData(
                table: "Engines",
                keyColumn: "Id",
                keyValue: new Guid("a60c39b6-f643-4172-9cd1-9f204ce77710"));

            migrationBuilder.DeleteData(
                table: "Gearboxes",
                keyColumn: "Id",
                keyValue: new Guid("857acc2b-b773-47e5-a876-99ffc5ef75ea"));

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: new Guid("2c167f42-63c4-4920-b74e-43613df316ce"));

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: new Guid("939861c1-c5c5-48d8-9b87-7867d617ecd9"));

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: new Guid("b358132c-24a2-44f6-a163-1e8cd77a2e85"));

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "Description", "FoundedBy", "FoundedDate", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { new Guid("515c6372-444b-4b0a-a332-2c7804baf968"), "Automobili Lamborghini is an Italian manufacturer of luxury sports cars and SUVs based in Sant'Agata Bolognese. The company is owned by the Volkswagen Group through its subsidiary Audi.", "Ferruccio Lamborghini", new DateTime(1963, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://www.brandcrowd.com/blog/wp-content/uploads/2023/05/Lamborghini-logo-1-1024x819.jpg", "Lamborghini" },
                    { new Guid("c88242b0-f3bf-45fc-84be-6befaec48e1a"), "BMW is a German company with activities covering the production and sale of motor vehicles, spare parts and accessories for motor vehicles, engineering products, as well as related services.", "Karl Rapp , Gustav Otto , Camillo Castiglioni , Franz Josef Pop", new DateTime(1916, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://www.carmonkey.co.uk/images/logos/Bmw-logo.svg", "BMW" },
                    { new Guid("ea9a3a81-ab02-43f6-8ea0-7fee139c2c7d"), "Mercedes-Benz is a trademark and a company of the same name - a manufacturer of premium cars, trucks, buses and other vehicles, which is part of the German concern \"Mercedes-Benz Group\". It is one of the most recognizable car brands in the world.", "Karl Benz, Gottlieb Daimler, Wilhelm Maybach and Emil Jellinek", new DateTime(1926, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://1000logos.net/wp-content/uploads/2018/04/Symbol-Mercedes-Benz.png", "Mercedes-Benz" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("792ae4f2-59ad-4120-9bd3-378da0de9944"), "Cooling System" },
                    { new Guid("bb17bdef-4f17-4c72-b25b-a3c70f7d791e"), "Steering System" },
                    { new Guid("ce003550-422a-4232-baa5-347e45a706d2"), "Braking System" },
                    { new Guid("df348489-d50b-40bb-8957-506a319fcb38"), "Motor Oil" },
                    { new Guid("f01df750-b081-4465-a4ec-20f5454fb651"), "Engine Parts" },
                    { new Guid("fadb416a-82d4-4bf4-ac1d-d5cec4eaf9a8"), "Filters" }
                });

            migrationBuilder.InsertData(
                table: "Models",
                columns: new[] { "Id", "BrandId", "Description", "FuelType", "GasConsumption", "HorsePower", "ImageUrl", "Name", "Year" },
                values: new object[,]
                {
                    { new Guid("505c5660-28d3-4ad5-a681-f78b6ef9d037"), new Guid("c88242b0-f3bf-45fc-84be-6befaec48e1a"), "The BMW 340i Sedan offers a powerful engine, refined handling, and luxury features.", "Petrol", 7.2m, 320, "https://i.pinimg.com/736x/ef/06/9e/ef069ec0aecb59c7858a19508b691b85.jpg", "BMW 340i Sedan", 2016 },
                    { new Guid("ba99a3d8-1616-4f6f-805b-5a84f9b7052a"), new Guid("515c6372-444b-4b0a-a332-2c7804baf968"), "Lamborghini created the Aventador SVJ to embrace challenges head-on, combining cutting-edge technology with extraordinary design, while always refusing to compromise. In a future driven by technology, it’s easy to lose the genuine thrill of driving. But in the future shaped by Lamborghini, this won’t be left behind, because there will always be a driver behind the wheel. ", "Petrol", 15.1m, 770, "https://supercars.bg/wp-content/uploads/2018/08/Lamborghini-Aventador-SV-R-Nurburgring21.jpg", "Lamborghini Aventador ", 2016 },
                    { new Guid("e8c2bf05-8806-4734-bec2-3fe35c9a82ce"), new Guid("ea9a3a81-ab02-43f6-8ea0-7fee139c2c7d"), "The output of the AMG 6.3-litre V8 engine is unchanged at 336 kW (457 hp) and can be increased to a maximum of 358 kW (487 hp) with the optional AMG Performance package. Agility, grip and ride comfort have been enhanced as a result of numerous measures to optimise the AMG sports suspension.", "Petrol", 13.2m, 487, "https://cdn.dealeraccelerate.com/bagauction/1/11/153/1920x1440/2012-mercedes-benz-c63-amg-black-series", "Mercedes-Benz C63 AMG", 2012 }
                });

            migrationBuilder.InsertData(
                table: "Engines",
                columns: new[] { "Id", "BrandId", "Cylinders", "ImageUrl", "ModelId", "Name", "PowerOutput", "Rpm", "Torque", "ValvetrainDriveSystem", "YearsProduction" },
                values: new object[] { new Guid("00b3f16f-a46a-447f-95f1-41d4037fce20"), new Guid("c88242b0-f3bf-45fc-84be-6befaec48e1a"), 6, "https://fsc.codes/cdn/shop/articles/BMW-B58.jpg?v=1703197166", new Guid("79a4d785-273d-488d-b7fe-f9ab58c405bf"), "B58", "322-385hp", "7000", "450-500Nm", "Chain", "2015-Present" });

            migrationBuilder.InsertData(
                table: "Gearboxes",
                columns: new[] { "Id", "Application", "Description", "ImageUrl", "Manufacturer", "Name", "Speeds", "TransmissionType", "YearsProduced" },
                values: new object[] { new Guid("5ffae977-47d8-4dc2-8d9a-64c560fe426a"), new Guid("505c5660-28d3-4ad5-a681-f78b6ef9d037"), "The ZF 8HP transmission is ZF Friedrichshafen AG's trademark name for its 8-speed automatic transmission models for longitudinal engine applications. The name is short for 8-speed transmission with hydraulic converter and planetary gearsets. Designed and first built by ZF's subsidiary in Saarbrücken, Germany, it debuted in 2008 on the BMW 7 Series (F01) 760Li sedan fitted with the V12 engine. BMW remains a major customer for the transmission.", "https://hips.hearstapps.com/hmg-prod/images/zf-8-speed-trans-1538511984.jpg", "ZF Friedrichshafen", "ZF 8HP Transmission", 8, "Automatic", "2008-Present" });

            
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("515c6372-444b-4b0a-a332-2c7804baf968"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("c88242b0-f3bf-45fc-84be-6befaec48e1a"));

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("ea9a3a81-ab02-43f6-8ea0-7fee139c2c7d"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("792ae4f2-59ad-4120-9bd3-378da0de9944"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("bb17bdef-4f17-4c72-b25b-a3c70f7d791e"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("ce003550-422a-4232-baa5-347e45a706d2"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("df348489-d50b-40bb-8957-506a319fcb38"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("f01df750-b081-4465-a4ec-20f5454fb651"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("fadb416a-82d4-4bf4-ac1d-d5cec4eaf9a8"));

            migrationBuilder.DeleteData(
                table: "Engines",
                keyColumn: "Id",
                keyValue: new Guid("00b3f16f-a46a-447f-95f1-41d4037fce20"));

            migrationBuilder.DeleteData(
                table: "Gearboxes",
                keyColumn: "Id",
                keyValue: new Guid("5ffae977-47d8-4dc2-8d9a-64c560fe426a"));

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: new Guid("505c5660-28d3-4ad5-a681-f78b6ef9d037"));

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: new Guid("ba99a3d8-1616-4f6f-805b-5a84f9b7052a"));

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: new Guid("e8c2bf05-8806-4734-bec2-3fe35c9a82ce"));

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "Description", "FoundedBy", "FoundedDate", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { new Guid("48e20c6a-afe4-4a84-a494-eda36861cf87"), "BMW is a German company with activities covering the production and sale of motor vehicles, spare parts and accessories for motor vehicles, engineering products, as well as related services.", "Karl Rapp , Gustav Otto , Camillo Castiglioni , Franz Josef Pop", new DateTime(1916, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://www.carmonkey.co.uk/images/logos/Bmw-logo.svg", "BMW" },
                    { new Guid("c8444b83-9e61-4ef0-ba0f-6eebaa6587f8"), "Mercedes-Benz is a trademark and a company of the same name - a manufacturer of premium cars, trucks, buses and other vehicles, which is part of the German concern \"Mercedes-Benz Group\". It is one of the most recognizable car brands in the world.", "Karl Benz, Gottlieb Daimler, Wilhelm Maybach and Emil Jellinek", new DateTime(1926, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://1000logos.net/wp-content/uploads/2018/04/Symbol-Mercedes-Benz.png", "Mercedes-Benz" },
                    { new Guid("f5d5808b-ba9d-4b12-a51d-2ffaf41aef1a"), "Automobili Lamborghini is an Italian manufacturer of luxury sports cars and SUVs based in Sant'Agata Bolognese. The company is owned by the Volkswagen Group through its subsidiary Audi.", "Ferruccio Lamborghini", new DateTime(1963, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://www.brandcrowd.com/blog/wp-content/uploads/2023/05/Lamborghini-logo-1-1024x819.jpg", "Lamborghini" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0399a682-9132-4eea-87d8-b6fd871b5cb7"), "Braking System" },
                    { new Guid("0b18aac8-77ba-481e-afef-dfde25ba2670"), "Cooling System" },
                    { new Guid("1fb8d4d2-bfe2-4829-a979-b1734a16a12d"), "Filters" },
                    { new Guid("9ea49f09-1b99-40df-9111-c26c4b75375e"), "Steering System" },
                    { new Guid("a5f27ad4-0853-4964-9a92-3cd0a484c67e"), "Engine Parts" },
                    { new Guid("f01c293e-8a02-459e-bd90-9c9d7cc72fda"), "Motor Oil" }
                });

            migrationBuilder.InsertData(
                table: "Engines",
                columns: new[] { "Id", "BrandId", "Cylinders", "ImageUrl", "ModelId", "Name", "PowerOutput", "Rpm", "Torque", "ValvetrainDriveSystem", "YearsProduction" },
                values: new object[] { new Guid("a60c39b6-f643-4172-9cd1-9f204ce77710"), new Guid("148c36a7-5930-4ce3-8bb0-658fd772c423"), 6, "https://fsc.codes/cdn/shop/articles/BMW-B58.jpg?v=1703197166", new Guid("79a4d785-273d-488d-b7fe-f9ab58c405bf"), "B58", "322-385hp", "7000", "450-500Nm", "Chain", "2015-Present" });

            migrationBuilder.InsertData(
                table: "Gearboxes",
                columns: new[] { "Id", "Application", "Description", "ImageUrl", "Manufacturer", "Name", "Speeds", "TransmissionType", "YearsProduced" },
                values: new object[] { new Guid("857acc2b-b773-47e5-a876-99ffc5ef75ea"), new Guid("79a4d785-273d-488d-b7fe-f9ab58c405bf"), "The ZF 8HP transmission is ZF Friedrichshafen AG's trademark name for its 8-speed automatic transmission models for longitudinal engine applications. The name is short for 8-speed transmission with hydraulic converter and planetary gearsets. Designed and first built by ZF's subsidiary in Saarbrücken, Germany, it debuted in 2008 on the BMW 7 Series (F01) 760Li sedan fitted with the V12 engine. BMW remains a major customer for the transmission.", "https://hips.hearstapps.com/hmg-prod/images/zf-8-speed-trans-1538511984.jpg", "ZF Friedrichshafen", "ZF 8HP Transmission", 8, "Automatic", "2008-Present" });

            migrationBuilder.InsertData(
                table: "Models",
                columns: new[] { "Id", "BrandId", "Description", "FuelType", "GasConsumption", "HorsePower", "ImageUrl", "Name", "Year" },
                values: new object[,]
                {
                    { new Guid("2c167f42-63c4-4920-b74e-43613df316ce"), new Guid("148c36a7-5930-4ce3-8bb0-658fd772c423"), "The BMW 340i Sedan offers a powerful engine, refined handling, and luxury features.", "Petrol", 7.2m, 320, "https://i.pinimg.com/736x/ef/06/9e/ef069ec0aecb59c7858a19508b691b85.jpg", "BMW 340i Sedan", 2016 },
                    { new Guid("939861c1-c5c5-48d8-9b87-7867d617ecd9"), new Guid("60caba99-72aa-421a-a569-7cb41423a3ee"), "Lamborghini created the Aventador SVJ to embrace challenges head-on, combining cutting-edge technology with extraordinary design, while always refusing to compromise. In a future driven by technology, it’s easy to lose the genuine thrill of driving. But in the future shaped by Lamborghini, this won’t be left behind, because there will always be a driver behind the wheel. ", "Petrol", 15.1m, 770, "https://supercars.bg/wp-content/uploads/2018/08/Lamborghini-Aventador-SV-R-Nurburgring21.jpg", "Lamborghini Aventador ", 2016 },
                    { new Guid("b358132c-24a2-44f6-a163-1e8cd77a2e85"), new Guid("c6d8e95b-d57f-4b15-bc7d-2f1ad38a17a9"), "The output of the AMG 6.3-litre V8 engine is unchanged at 336 kW (457 hp) and can be increased to a maximum of 358 kW (487 hp) with the optional AMG Performance package. Agility, grip and ride comfort have been enhanced as a result of numerous measures to optimise the AMG sports suspension.", "Petrol", 13.2m, 487, "https://cdn.dealeraccelerate.com/bagauction/1/11/153/1920x1440/2012-mercedes-benz-c63-amg-black-series", "Mercedes-Benz C63 AMG", 2012 }
                });
        }
    }
}
