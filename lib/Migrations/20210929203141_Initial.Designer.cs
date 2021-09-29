﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using lib;

namespace lib.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20210929203141_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.10");

            modelBuilder.Entity("lib.Flight", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Aircraft")
                        .HasColumnType("TEXT");

                    b.Property<string>("Arrival")
                        .HasColumnType("TEXT");

                    b.Property<int>("BusinessClass")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Departure")
                        .HasColumnType("TEXT");

                    b.Property<int>("EconomyClass")
                        .HasColumnType("INTEGER");

                    b.Property<int>("FirstClass")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.ToTable("Flights");
                });

            modelBuilder.Entity("lib.Seat", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Class")
                        .HasColumnType("TEXT");

                    b.Property<int>("Cost")
                        .HasColumnType("INTEGER");

                    b.Property<string>("CustomerType")
                        .HasColumnType("TEXT");

                    b.Property<int?>("FlightID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("Occupied")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("FlightID");

                    b.ToTable("Seats");
                });

            modelBuilder.Entity("lib.Seat", b =>
                {
                    b.HasOne("lib.Flight", "Flight")
                        .WithMany()
                        .HasForeignKey("FlightID");

                    b.Navigation("Flight");
                });
#pragma warning restore 612, 618
        }
    }
}
