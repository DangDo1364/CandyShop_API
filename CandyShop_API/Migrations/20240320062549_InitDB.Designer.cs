﻿// <auto-generated />
using System;
using CandyShop_API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CandyShop_API.Migrations
{
    [DbContext(typeof(MyDBContext))]
    [Migration("20240320062549_InitDB")]
    partial class InitDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CandyShop_API.Model.Category", b =>
                {
                    b.Property<int>("idCate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("idCate");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("CandyShop_API.Model.Image", b =>
                {
                    b.Property<Guid>("idImg")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("idPro")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("path")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("idImg");

                    b.HasIndex("idPro");

                    b.ToTable("Image");
                });

            modelBuilder.Entity("CandyShop_API.Model.Product", b =>
                {
                    b.Property<Guid>("idPro")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("discount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("idCate")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("idPro");

                    b.HasIndex("idCate");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("CandyShop_API.Model.Image", b =>
                {
                    b.HasOne("CandyShop_API.Model.Product", "product")
                        .WithMany("images")
                        .HasForeignKey("idPro")
                        .HasConstraintName("FK_Images_Product")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("product");
                });

            modelBuilder.Entity("CandyShop_API.Model.Product", b =>
                {
                    b.HasOne("CandyShop_API.Model.Category", "category")
                        .WithMany("products")
                        .HasForeignKey("idCate")
                        .HasConstraintName("FK_Products_Category")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("category");
                });

            modelBuilder.Entity("CandyShop_API.Model.Category", b =>
                {
                    b.Navigation("products");
                });

            modelBuilder.Entity("CandyShop_API.Model.Product", b =>
                {
                    b.Navigation("images");
                });
#pragma warning restore 612, 618
        }
    }
}
