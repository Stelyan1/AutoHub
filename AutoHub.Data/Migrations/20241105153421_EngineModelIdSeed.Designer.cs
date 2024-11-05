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
    [Migration("20241105153421_EngineModelIdSeed")]
    partial class EngineModelIdSeed
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
                            Id = new Guid("8b1c8b74-e13b-4dd6-ac6e-8692c57e6fe0"),
                            Description = "Automobili Lamborghini is an Italian manufacturer of luxury sports cars and SUVs based in Sant'Agata Bolognese. The company is owned by the Volkswagen Group through its subsidiary Audi.",
                            FoundedBy = "Ferruccio Lamborghini",
                            FoundedDate = new DateTime(1963, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ImageUrl = "https://www.brandcrowd.com/blog/wp-content/uploads/2023/05/Lamborghini-logo-1-1024x819.jpg",
                            Name = "Lamborghini"
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
                            Id = new Guid("8f228c64-39b2-4f28-824a-4aacec167362"),
                            BrandId = new Guid("c5bff384-4440-480a-b62f-e544ea4b8b05"),
                            Cylinders = 6,
                            ImageUrl = "https://fsc.codes/cdn/shop/articles/BMW-B58.jpg?v=1703197166",
                            ModelId = new Guid("348de990-d33a-4271-a79e-2820bf517459"),
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
                            Id = new Guid("9ab813d3-f098-4c7d-b821-c7f972dcee7a"),
                            BrandId = new Guid("c5bff384-4440-480a-b62f-e544ea4b8b05"),
                            Description = "The BMW 340i Sedan offers a powerful engine, refined handling, and luxury features.",
                            FuelType = "Petrol",
                            GasConsumption = 7.2m,
                            HorsePower = 320,
                            ImageUrl = "https://i.pinimg.com/736x/ef/06/9e/ef069ec0aecb59c7858a19508b691b85.jpg",
                            Name = "BMW 340i Sedan",
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
