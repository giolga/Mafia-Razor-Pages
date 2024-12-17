﻿// <auto-generated />
using System;
using Mafia_Razor_Pages.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Mafia_Razor_Pages.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241217103556_init8_LoseColumn_Added")]
    partial class init8_LoseColumn_Added
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.35");

            modelBuilder.Entity("Mafia_Razor_Pages.Models.GameAction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Character")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("TargetSeatNumber")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("GameActions");
                });

            modelBuilder.Entity("Mafia_Razor_Pages.Models.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<byte?>("Age")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Character")
                        .HasColumnType("TEXT");

                    b.Property<string>("Gmail")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsFirstLose")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Lose")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("NumberOfFouls")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<byte>("SeatNumber")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Players");
                });
#pragma warning restore 612, 618
        }
    }
}
