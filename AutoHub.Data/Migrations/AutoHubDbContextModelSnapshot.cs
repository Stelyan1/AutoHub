﻿// <auto-generated />
using System;
using AutoHub.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AutoHub.Data.Migrations
{
    [DbContext(typeof(AutoHubDbContext))]
    partial class AutoHubDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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
                            Id = new Guid("e7192d7a-2ecd-46f9-be8c-1768765e7166"),
                            Description = "Automobili Lamborghini is an Italian manufacturer of luxury sports cars and SUVs based in Sant'Agata Bolognese. The company is owned by the Volkswagen Group through its subsidiary Audi.",
                            FoundedBy = "Ferruccio Lamborghini",
                            FoundedDate = new DateTime(1963, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ImageUrl = "https://www.brandcrowd.com/blog/wp-content/uploads/2023/05/Lamborghini-logo-1-1024x819.jpg",
                            Name = "Lamborghini"
                        },
                        new
                        {
                            Id = new Guid("8b0004fe-3acf-487c-84e1-0c53d5d105ec"),
                            Description = "BMW is a German company with activities covering the production and sale of motor vehicles, spare parts and accessories for motor vehicles, engineering products, as well as related services.",
                            FoundedBy = "Karl Rapp , Gustav Otto , Camillo Castiglioni , Franz Josef Pop",
                            FoundedDate = new DateTime(1916, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ImageUrl = "https://www.carmonkey.co.uk/images/logos/Bmw-logo.svg",
                            Name = "BMW"
                        },
                        new
                        {
                            Id = new Guid("a819fa84-8ca3-4ea3-bf8d-705894f2e103"),
                            Description = "Mercedes-Benz is a trademark and a company of the same name - a manufacturer of premium cars, trucks, buses and other vehicles, which is part of the German concern \"Mercedes-Benz Group\". It is one of the most recognizable car brands in the world.",
                            FoundedBy = "Karl Benz, Gottlieb Daimler, Wilhelm Maybach and Emil Jellinek",
                            FoundedDate = new DateTime(1926, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ImageUrl = "https://1000logos.net/wp-content/uploads/2018/04/Symbol-Mercedes-Benz.png",
                            Name = "Mercedes-Benz"
                        });
                });

            modelBuilder.Entity("AutoHub.Data.Models.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Identifier of the category");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasComment("Name of the category");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = new Guid("bf89cb63-1711-4dd1-ae44-c62997eaaa0e"),
                            Name = "Motor Oil"
                        },
                        new
                        {
                            Id = new Guid("41bb5b72-836b-4165-a9b7-b00a8a63c2db"),
                            Name = "Filters"
                        },
                        new
                        {
                            Id = new Guid("d117a9c6-8348-4dd1-ac1d-f21752746574"),
                            Name = "Steering System"
                        },
                        new
                        {
                            Id = new Guid("bcc33741-cdff-4c71-928c-bc2ee260612c"),
                            Name = "Braking System"
                        },
                        new
                        {
                            Id = new Guid("9210ed14-573b-4300-9cb8-69935044196e"),
                            Name = "Engine Parts"
                        },
                        new
                        {
                            Id = new Guid("23f37403-bc44-462c-85b4-435528bd0cb1"),
                            Name = "Cooling System"
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
                            Id = new Guid("e8877832-cf2e-402a-8595-80f4386849b5"),
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

            modelBuilder.Entity("AutoHub.Data.Models.Gearbox", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Identification of the gearbox");

                    b.Property<Guid>("Application")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Model vehicle that has it");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasComment("Description about the gearbox");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasComment("Image of the gearbox");

                    b.Property<string>("Manufacturer")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)")
                        .HasComment("Manufacturer of the gearbox");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)")
                        .HasComment("Name of the gearbox");

                    b.Property<int>("Speeds")
                        .HasColumnType("int")
                        .HasComment("How much speeds does it have from 5 to 8");

                    b.Property<string>("TransmissionType")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasComment("Type of the transmission manual or automatic");

                    b.Property<string>("YearsProduced")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasComment("Years produced");

                    b.HasKey("Id");

                    b.HasIndex("Application");

                    b.ToTable("Gearboxes");

                    b.HasData(
                        new
                        {
                            Id = new Guid("d2825469-a972-46d1-8ca2-622538802ad2"),
                            Application = new Guid("79a4d785-273d-488d-b7fe-f9ab58c405bf"),
                            Description = "The ZF 8HP transmission is ZF Friedrichshafen AG's trademark name for its 8-speed automatic transmission models for longitudinal engine applications. The name is short for 8-speed transmission with hydraulic converter and planetary gearsets. Designed and first built by ZF's subsidiary in Saarbrücken, Germany, it debuted in 2008 on the BMW 7 Series (F01) 760Li sedan fitted with the V12 engine. BMW remains a major customer for the transmission.",
                            ImageUrl = "https://hips.hearstapps.com/hmg-prod/images/zf-8-speed-trans-1538511984.jpg",
                            Manufacturer = "ZF Friedrichshafen",
                            Name = "ZF 8HP Transmission",
                            Speeds = 8,
                            TransmissionType = "Automatic",
                            YearsProduced = "2008-Present"
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
                            Id = new Guid("1819df5b-bf5c-4365-ad43-f6891ef6484e"),
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
                            Id = new Guid("a9ac624d-6cf5-4d9f-8a96-3d77519a9bda"),
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
                            Id = new Guid("1ae6fe9a-a1e1-4f1c-9a8d-2cdb789e6a04"),
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

            modelBuilder.Entity("AutoHub.Data.Models.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Identifier of the product");

                    b.Property<DateTime>("AddedOn")
                        .HasColumnType("datetime2")
                        .HasComment("Date the product was added");

                    b.Property<string>("CarsApplication")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)")
                        .HasComment("Cars that product can be used for");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Identifier of the category");

                    b.Property<Guid?>("CategoryId1")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasComment("Description about the product");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasComment("Image of the product");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit")
                        .HasComment("Bool to check if the product is deleted");

                    b.Property<string>("Manufacturer")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)")
                        .HasComment("Name of the manufacturer");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)")
                        .HasComment("Price of the product");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)")
                        .HasComment("Name of the product");

                    b.Property<string>("SellerId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasComment("Identifier of the Seller");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("CategoryId1");

                    b.HasIndex("SellerId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("AutoHub.Data.Models.ProductClient", b =>
                {
                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Identifier of the product");

                    b.Property<string>("ClientId")
                        .HasColumnType("nvarchar(450)")
                        .HasComment("Identifier of the client");

                    b.Property<Guid?>("ProductId1")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ProductId", "ClientId");

                    b.HasIndex("ClientId");

                    b.HasIndex("ProductId1");

                    b.ToTable("ProductClients");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
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

            modelBuilder.Entity("AutoHub.Data.Models.Gearbox", b =>
                {
                    b.HasOne("AutoHub.Data.Models.Model", "Model")
                        .WithMany("Gearboxes")
                        .HasForeignKey("Application")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

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

            modelBuilder.Entity("AutoHub.Data.Models.Product", b =>
                {
                    b.HasOne("AutoHub.Data.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AutoHub.Data.Models.Category", null)
                        .WithMany("Products")
                        .HasForeignKey("CategoryId1");

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "Seller")
                        .WithMany()
                        .HasForeignKey("SellerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Seller");
                });

            modelBuilder.Entity("AutoHub.Data.Models.ProductClient", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AutoHub.Data.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AutoHub.Data.Models.Product", null)
                        .WithMany("ProductsClients")
                        .HasForeignKey("ProductId1");

                    b.Navigation("Client");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AutoHub.Data.Models.Brand", b =>
                {
                    b.Navigation("Engines");

                    b.Navigation("Models");
                });

            modelBuilder.Entity("AutoHub.Data.Models.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("AutoHub.Data.Models.Model", b =>
                {
                    b.Navigation("Engines");

                    b.Navigation("Gearboxes");
                });

            modelBuilder.Entity("AutoHub.Data.Models.Product", b =>
                {
                    b.Navigation("ProductsClients");
                });
#pragma warning restore 612, 618
        }
    }
}
