﻿// <auto-generated />
using System;
using BlueModas_WebAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace BlueModas_WebAPI.Migrations
{
    [DbContext(typeof(APIContext))]
    [Migration("20210713021410_initCreate")]
    partial class initCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("BlueModas_WebAPI.Models.TabClient", b =>
                {
                    b.Property<int>("tclID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("tclEmail")
                        .HasColumnType("text");

                    b.Property<string>("tclName")
                        .HasColumnType("text");

                    b.Property<string>("tclPhone")
                        .HasColumnType("text");

                    b.HasKey("tclID");

                    b.HasIndex("tclEmail")
                        .IsUnique();

                    b.ToTable("TabClient");
                });

            modelBuilder.Entity("BlueModas_WebAPI.Models.TabOrder", b =>
                {
                    b.Property<int>("torID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("torDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("tortclID")
                        .HasColumnType("integer");

                    b.HasKey("torID");

                    b.ToTable("TabOrder");
                });

            modelBuilder.Entity("BlueModas_WebAPI.Models.TabProduct", b =>
                {
                    b.Property<int>("tprID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("tprImage")
                        .HasColumnType("text");

                    b.Property<string>("tprName")
                        .HasColumnType("text");

                    b.Property<double>("tprPrice")
                        .HasColumnType("double precision");

                    b.HasKey("tprID");

                    b.ToTable("TabProduct");
                });

            modelBuilder.Entity("BlueModas_WebAPI.Models.TabProductBasket", b =>
                {
                    b.Property<int>("tpbID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<double>("tpbPriceUnity")
                        .HasColumnType("double precision");

                    b.Property<int>("tpbQuantity")
                        .HasColumnType("integer");

                    b.Property<int>("tpbtorID")
                        .HasColumnType("integer");

                    b.Property<int>("tpbtprID")
                        .HasColumnType("integer");

                    b.HasKey("tpbID");

                    b.HasIndex("tpbtprID");

                    b.ToTable("TabProductBasket");
                });

            modelBuilder.Entity("BlueModas_WebAPI.Models.TabProductBasket", b =>
                {
                    b.HasOne("BlueModas_WebAPI.Models.TabProduct", "TabProduct")
                        .WithMany()
                        .HasForeignKey("tpbtprID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TabProduct");
                });
#pragma warning restore 612, 618
        }
    }
}
