﻿// <auto-generated />
using System;
using MVCBudget.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MVCBudget.Migrations
{
    [DbContext(typeof(BudgetContext))]
    [Migration("20240122204740_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MVCBudget.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Car parts",
                            Name = "Car Parts"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Electronic devices",
                            Name = "Electronic"
                        });
                });

            modelBuilder.Entity("MVCBudget.Models.Transaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Transactions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Amount = 2500m,
                            CategoryId = 1,
                            Date = new DateTime(2023, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Induction Kit"
                        },
                        new
                        {
                            Id = 2,
                            Amount = 22500m,
                            CategoryId = 1,
                            Date = new DateTime(2022, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Milltek Exhaust"
                        },
                        new
                        {
                            Id = 3,
                            Amount = 10000m,
                            CategoryId = 2,
                            Date = new DateTime(2021, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Samsung TV"
                        });
                });

            modelBuilder.Entity("MVCBudget.Models.Transaction", b =>
                {
                    b.HasOne("MVCBudget.Models.Category", "Category")
                        .WithMany("Transactions")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("MVCBudget.Models.Category", b =>
                {
                    b.Navigation("Transactions");
                });
#pragma warning restore 612, 618
        }
    }
}