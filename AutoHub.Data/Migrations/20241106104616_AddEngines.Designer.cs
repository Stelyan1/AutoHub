﻿// <auto-generated />
using System;
using AutoHub.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AutoHub.Data.Migrations
{
    [DbContext(typeof(AutoHubDbContext))]
    [Migration("20241106104616_AddEngines")]
    partial class AddEngines
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AutoHub.Data.Models.Brand", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Identifier of the brand");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasComment("Text for a little info about the company");

                    b.Property<string>("FoundedBy")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)")
                        .HasComment("Name of the founder/s");

                    b.Property<DateTime>("FoundedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)")
                        .HasComment("Name of the brand");

                    b.HasKey("Id");

                    b.ToTable("Brands");

                    b.HasData(
                        new
                        {
                            Id = new Guid("8040eadf-4452-4920-b282-b9dd83d4300a"),
                            Description = "Automobili Lamborghini is an Italian manufacturer of luxury sports cars and SUVs based in Sant'Agata Bolognese. The company is owned by the Volkswagen Group through its subsidiary Audi.",
                            FoundedBy = "Ferruccio Lamborghini",
                            FoundedDate = new DateTime(1963, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ImageUrl = "https://www.brandcrowd.com/blog/wp-content/uploads/2023/05/Lamborghini-logo-1-1024x819.jpg",
                            Name = "Lamborghini"
                        },
                        new
                        {
                            Id = new Guid("f65f0613-ea00-4a8a-9fff-23a564819251"),
                            Description = "BMW is a German company with activities covering the production and sale of motor vehicles, spare parts and accessories for motor vehicles, engineering products, as well as related services.",
                            FoundedBy = "Karl Rapp , Gustav Otto , Camillo Castiglioni , Franz Josef Pop",
                            FoundedDate = new DateTime(1916, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ImageUrl = "https://www.carmonkey.co.uk/images/logos/Bmw-logo.svg",
                            Name = "BMW"
                        },
                        new
                        {
                            Id = new Guid("ed1aacf0-b0df-4999-83e2-a797be506a13"),
                            Description = "Mercedes-Benz is a trademark and a company of the same name - a manufacturer of premium cars, trucks, buses and other vehicles, which is part of the German concern \"Mercedes-Benz Group\". It is one of the most recognizable car brands in the world.",
                            FoundedBy = "Karl Benz, Gottlieb Daimler, Wilhelm Maybach and Emil Jellinek",
                            FoundedDate = new DateTime(1926, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ImageUrl = "https://1000logos.net/wp-content/uploads/2018/04/Symbol-Mercedes-Benz.png",
                            Name = "Mercedes-Benz"
                        });
                });

            modelBuilder.Entity("AutoHub.Data.Models.Engine", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Identifier of engine");

                    b.Property<Guid>("BrandId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("FK Manufacturer of engine");

                    b.Property<int>("Cylinders")
                        .HasColumnType("int")
                        .HasComment("Cylinder of engine");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasComment("Image of engine");

                    b.Property<Guid>("ModelId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("FK To VehicleModel");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)")
                        .HasComment("Name of engine");

                    b.Property<string>("PowerOutput")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasComment("Horsepower of engine");

                    b.Property<string>("Rpm")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasComment("Maximum output of engine");

                    b.Property<string>("Torque")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasComment("Torque of engine");

                    b.Property<string>("ValvetrainDriveSystem")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)")
                        .HasComment("Chain");

                    b.Property<string>("YearsProduction")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasComment("Date started and ended of engine");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.HasIndex("ModelId");

                    b.ToTable("Engines");

                    b.HasData(
                        new
                        {
                            Id = new Guid("fa4a1b22-b08f-4d62-a05a-2a615a24a435"),
                            BrandId = new Guid("148c36a7-5930-4ce3-8bb0-658fd772c423"),
                            Cylinders = 6,
                            ImageUrl = "https://fsc.codes/cdn/shop/articles/BMW-B58.jpg?v=1703197166",
                            ModelId = new Guid("79a4d785-273d-488d-b7fe-f9ab58c405bf"),
                            Name = "B58",
                            PowerOutput = "322-385hp",
                            Rpm = "7000",
                            Torque = "450-500Nm",
                            ValvetrainDriveSystem = "Chain",
                            YearsProduction = "2015-Present"
                        });
                });

            modelBuilder.Entity("AutoHub.Data.Models.Model", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Identifier of the model");

                    b.Property<Guid>("BrandId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Foreign Key to Brand one model can have one brand");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasComment("Description about the model");

                    b.Property<string>("FuelType")
                        .IsRequired()
                        .HasMaxLength(6)
                        .HasColumnType("nvarchar(6)")
                        .HasComment("Fuel type of the vehicle");

                    b.Property<decimal>("GasConsumption")
                        .HasColumnType("decimal(5, 2)")
                        .HasComment("Gas consumption per 100km");

                    b.Property<int>("HorsePower")
                        .HasColumnType("int")
                        .HasComment("Horsepower of the vehicle");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)")
                        .HasComment("Name of the model");

                    b.Property<int>("Year")
                        .HasColumnType("int")
                        .HasComment("Year the model was released");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.ToTable("Models");

                    b.HasData(
                        new
                        {
                            Id = new Guid("f128ebea-c90b-476d-ad71-a82e20812f31"),
                            BrandId = new Guid("148c36a7-5930-4ce3-8bb0-658fd772c423"),
                            Description = "The BMW 340i Sedan offers a powerful engine, refined handling, and luxury features.",
                            FuelType = "Petrol",
                            GasConsumption = 7.2m,
                            HorsePower = 320,
                            ImageUrl = "https://i.pinimg.com/736x/ef/06/9e/ef069ec0aecb59c7858a19508b691b85.jpg",
                            Name = "BMW 340i Sedan",
                            Year = 2016
                        },
                        new
                        {
                            Id = new Guid("a4748b31-ad2a-4017-b4c8-04c357a7c970"),
                            BrandId = new Guid("c6d8e95b-d57f-4b15-bc7d-2f1ad38a17a9"),
                            Description = "The output of the AMG 6.3-litre V8 engine is unchanged at 336 kW (457 hp) and can be increased to a maximum of 358 kW (487 hp) with the optional AMG Performance package. Agility, grip and ride comfort have been enhanced as a result of numerous measures to optimise the AMG sports suspension.",
                            FuelType = "Petrol",
                            GasConsumption = 13.2m,
                            HorsePower = 487,
                            ImageUrl = "https://cdn.dealeraccelerate.com/bagauction/1/11/153/1920x1440/2012-mercedes-benz-c63-amg-black-series",
                            Name = "Mercedes-Benz C63 AMG",
                            Year = 2012
                        },
                        new
                        {
                            Id = new Guid("b6b85877-189e-4e31-97d0-9fc4692d25f3"),
                            BrandId = new Guid("60caba99-72aa-421a-a569-7cb41423a3ee"),
                            Description = "Lamborghini created the Aventador SVJ to embrace challenges head-on, combining cutting-edge technology with extraordinary design, while always refusing to compromise. In a future driven by technology, it’s easy to lose the genuine thrill of driving. But in the future shaped by Lamborghini, this won’t be left behind, because there will always be a driver behind the wheel. ",
                            FuelType = "Petrol",
                            GasConsumption = 15.1m,
                            HorsePower = 770,
                            ImageUrl = "https://supercars.bg/wp-content/uploads/2018/08/Lamborghini-Aventador-SV-R-Nurburgring21.jpg",
                            Name = "Lamborghini Aventador ",
                            Year = 2016
                        });
                });

            modelBuilder.Entity("AutoHub.Data.Models.Engine", b =>
                {
                    b.HasOne("AutoHub.Data.Models.Brand", "Brand")
                        .WithMany("Engines")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AutoHub.Data.Models.Model", "Model")
                        .WithMany("Engines")
                        .HasForeignKey("ModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");

                    b.Navigation("Model");
                });

            modelBuilder.Entity("AutoHub.Data.Models.Model", b =>
                {
                    b.HasOne("AutoHub.Data.Models.Brand", "Brand")
                        .WithMany("Models")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");
                });

            modelBuilder.Entity("AutoHub.Data.Models.Brand", b =>
                {
                    b.Navigation("Engines");

                    b.Navigation("Models");
                });

            modelBuilder.Entity("AutoHub.Data.Models.Model", b =>
                {
                    b.Navigation("Engines");
                });
#pragma warning restore 612, 618
        }
    }
}
