﻿// <auto-generated />
using System;
using CrudOperationInNetCore.Context;
using CrudOperationInNetCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CrudOperationInNetCore.Migrations
{
    [DbContext(typeof(BrandContext))]
    partial class BrandContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CrudOperationInNetCore.Models.Brand", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int");

                SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                b.Property<string>("Category")
                    .HasColumnType("nvarchar(max)");

                b.Property<int?>("IsActive")
                    .HasColumnType("int");

                b.Property<string>("Name")
                    .HasColumnType("nvarchar(max)");

                b.HasKey("Id");

                b.ToTable("Brands");
            });

            modelBuilder.Entity("CrudOperationInNetCore.Models.Order", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int");

                SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                b.Property<int>("BrandId")
                    .HasColumnType("int");

                b.Property<string>("Name")
                    .HasColumnType("nvarchar(max)");

                b.HasKey("Id");

                b.HasIndex("BrandId");

                b.ToTable("Orders");
            });

            modelBuilder.Entity("CrudOperationInNetCore.Models.Order", b =>
            {
                b.HasOne("CrudOperationInNetCore.Models.Brand", "Brand")
                    .WithMany("Orders")
                    .HasForeignKey("BrandId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.Navigation("Brand");
            });

            modelBuilder.Entity("CrudOperationInNetCore.Models.Brand", b =>
            {
                b.Navigation("Orders");
            });
#pragma warning restore 612, 618
        }
    }
}