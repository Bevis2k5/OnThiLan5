﻿// <auto-generated />
using System;
using AppAPI.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AppAPI.Migrations
{
    [DbContext(typeof(Duong_PH52967))]
    [Migration("20250306003729_f")]
    partial class f
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AppAPI.Model.KhachHang", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DiaChi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LoaiKhachHang")
                        .HasColumnType("int");

                    b.Property<string>("SoDienThoai")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ten")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Tuoi")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("KhachHangs");
                });
#pragma warning restore 612, 618
        }
    }
}
