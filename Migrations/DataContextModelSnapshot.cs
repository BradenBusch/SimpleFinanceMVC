﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SimpleFinance.Data;

#nullable disable

namespace SimpleFinance.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SimpleFinance.Models.AccountDetail", b =>
                {
                    b.Property<Guid>("AccountDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AccountHeaderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("AccountValue")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("AccountDetailId");

                    b.ToTable("AccountDetail");
                });

            modelBuilder.Entity("SimpleFinance.Models.AccountHeader", b =>
                {
                    b.Property<Guid>("AccountHeaderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AccountDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AccountName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AccountType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("AccountValue")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("AccountHeaderId");

                    b.ToTable("AccountHeader");
                });

            modelBuilder.Entity("SimpleFinance.Models.ExpenseDetail", b =>
                {
                    b.Property<Guid>("ExpenseDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ExpenseHeaderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("ExpenseValue")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ExpenseDetailId");

                    b.ToTable("ExpenseDetail");
                });

            modelBuilder.Entity("SimpleFinance.Models.ExpenseHeader", b =>
                {
                    b.Property<Guid>("ExpenseHeaderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ExpenseName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ExpenseType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("ExpenseValue")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ExpenseHeaderId");

                    b.ToTable("ExpenseHeader");
                });
#pragma warning restore 612, 618
        }
    }
}
