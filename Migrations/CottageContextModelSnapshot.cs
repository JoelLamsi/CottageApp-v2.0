﻿// <auto-generated />
using System;
using CottageApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CottageApp.Migrations
{
    [DbContext(typeof(CottageContext))]
    partial class CottageContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.0");

            modelBuilder.Entity("CottageApp.Models.CottageItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("CostPerDay")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateAdded")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsElectricity")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsSauna")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PictureUrl")
                        .HasColumnType("TEXT");

                    b.Property<int>("Rooms")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("CottageItems");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CostPerDay = 0m,
                            DateAdded = new DateTime(2022, 11, 18, 20, 28, 4, 38, DateTimeKind.Local).AddTicks(938),
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                            IsElectricity = false,
                            IsSauna = false,
                            PictureUrl = "img/log-cabin-1886620_1920.jpg",
                            Rooms = 0,
                            Title = "Foo"
                        },
                        new
                        {
                            Id = 2,
                            CostPerDay = 0m,
                            DateAdded = new DateTime(2020, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsElectricity = false,
                            IsSauna = false,
                            PictureUrl = "img/cabin-1082063__340.webp",
                            Rooms = 0,
                            Title = "Bar"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
