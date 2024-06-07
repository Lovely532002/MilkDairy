﻿// <auto-generated />
using System;
using Data.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240601132614_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Models.Administrators.Admin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Profile")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Administrators");
                });

            modelBuilder.Entity("Domain.Models.Customers.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CustomerType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Milk")
                        .HasColumnType("real");

                    b.Property<float>("MilkRate")
                        .HasColumnType("real");

                    b.Property<long>("Mobile")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Profile")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("UpdatedBy");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Domain.Models.Login.AdminLogin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AdminId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.HasKey("Id");

                    b.ToTable("AdminLogin");
                });

            modelBuilder.Entity("Domain.Models.MilkDeliveries.MilkDelivery", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("DailyDevision")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DeliveryDate")
                        .HasColumnType("datetime2");

                    b.Property<float>("Milk")
                        .HasColumnType("real");

                    b.Property<float>("MilkRate")
                        .HasColumnType("real");

                    b.Property<int>("StoreId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StoreId");

                    b.ToTable("MilkDelivery");
                });

            modelBuilder.Entity("Domain.Models.Stores.MilkStore", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("UpdatedBy");

                    b.ToTable("MilkStores");
                });

            modelBuilder.Entity("Domain.Models.Customers.Customer", b =>
                {
                    b.HasOne("Domain.Models.Administrators.Admin", "CreatedByAdmin")
                        .WithMany("CreatedCustomers")
                        .HasForeignKey("CreatedBy");

                    b.HasOne("Domain.Models.Administrators.Admin", "UpdatedByAdmin")
                        .WithMany("UpdatedCustomers")
                        .HasForeignKey("UpdatedBy");

                    b.Navigation("CreatedByAdmin");

                    b.Navigation("UpdatedByAdmin");
                });

            modelBuilder.Entity("Domain.Models.MilkDeliveries.MilkDelivery", b =>
                {
                    b.HasOne("Domain.Models.Stores.MilkStore", "Store")
                        .WithMany()
                        .HasForeignKey("StoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Store");
                });

            modelBuilder.Entity("Domain.Models.Stores.MilkStore", b =>
                {
                    b.HasOne("Domain.Models.Administrators.Admin", "Created_ByAdmin")
                        .WithMany("CreatedMilkStores")
                        .HasForeignKey("CreatedBy");

                    b.HasOne("Domain.Models.Administrators.Admin", "Updated_ByAdmin")
                        .WithMany("UpdatedMilkStores")
                        .HasForeignKey("UpdatedBy");

                    b.Navigation("Created_ByAdmin");

                    b.Navigation("Updated_ByAdmin");
                });

            modelBuilder.Entity("Domain.Models.Administrators.Admin", b =>
                {
                    b.Navigation("CreatedCustomers");

                    b.Navigation("CreatedMilkStores");

                    b.Navigation("UpdatedCustomers");

                    b.Navigation("UpdatedMilkStores");
                });
#pragma warning restore 612, 618
        }
    }
}
