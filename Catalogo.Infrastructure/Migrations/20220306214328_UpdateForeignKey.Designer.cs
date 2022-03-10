﻿// <auto-generated />
using System;
using Catalogo.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Catalogo.Infrastructure.Migrations
{
    [DbContext(typeof(CatalogoContext))]
    [Migration("20220306214328_UpdateForeignKey")]
    partial class UpdateForeignKey
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Catalogo.Domain.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("DATETIME");

                    b.Property<string>("ImageURL")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("VARCHAR(250)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("VARCHAR(50)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("DATETIME");

                    b.HasKey("Id");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("Catalogo.Domain.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId")
                        .HasColumnType("INT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("DATETIME");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("VARCHAR(200)");

                    b.Property<string>("ImageURL")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("VARCHAR(250)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("VARCHAR(50)");

                    b.Property<decimal>("Price")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)");

                    b.Property<int>("Stock")
                        .HasColumnType("INT");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("DATETIME");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("Catalogo.Domain.Entities.Product", b =>
                {
                    b.HasOne("Catalogo.Domain.Entities.Category", null)
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}