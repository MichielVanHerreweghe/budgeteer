﻿// <auto-generated />
using System;
using Budgeteer.Services.BudgeteerApi.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Budgeteer.Services.BudgeteerApi.Persistence.Migrations
{
    [DbContext(typeof(BudgeteerDbContext))]
    partial class BudgeteerDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Budgeteer.Services.BudgeteerApi.Domain.Books.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.Property<bool>("IsEnabled")
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(4000)
                        .HasColumnType("nvarchar(4000)");

                    b.Property<DateTime>("UpdatedAt")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.HasKey("Id");

                    b.ToTable("Book", (string)null);
                });

            modelBuilder.Entity("Budgeteer.Services.BudgeteerApi.Domain.Documents.Document", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.Property<bool>("IsEnabled")
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(4000)
                        .HasColumnType("nvarchar(4000)");

                    b.Property<int?>("TransactionId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasMaxLength(4000)
                        .HasColumnType("nvarchar(4000)");

                    b.HasKey("Id");

                    b.HasIndex("TransactionId");

                    b.ToTable("Document", (string)null);
                });

            modelBuilder.Entity("Budgeteer.Services.BudgeteerApi.Domain.Tags.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.Property<bool>("IsEnabled")
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(4000)
                        .HasColumnType("nvarchar(4000)");

                    b.Property<DateTime>("UpdatedAt")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.HasKey("Id");

                    b.ToTable("Tag", (string)null);
                });

            modelBuilder.Entity("Budgeteer.Services.BudgeteerApi.Domain.Transactions.Transaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Amount")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("BookId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.Property<DateTime>("DateOfTransaction")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsEnabled")
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(4000)
                        .HasColumnType("nvarchar(4000)");

                    b.Property<int>("TransactionType")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.ToTable("Transaction", (string)null);

                    b.HasDiscriminator<int>("TransactionType").HasValue(0);

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("TagTransaction", b =>
                {
                    b.Property<int>("TagsId")
                        .HasColumnType("int");

                    b.Property<int>("TransactionId")
                        .HasColumnType("int");

                    b.HasKey("TagsId", "TransactionId");

                    b.HasIndex("TransactionId");

                    b.ToTable("TagTransaction");
                });

            modelBuilder.Entity("Budgeteer.Services.BudgeteerApi.Domain.Transactions.Expense", b =>
                {
                    b.HasBaseType("Budgeteer.Services.BudgeteerApi.Domain.Transactions.Transaction");

                    b.HasDiscriminator().HasValue(2);
                });

            modelBuilder.Entity("Budgeteer.Services.BudgeteerApi.Domain.Transactions.Revenue", b =>
                {
                    b.HasBaseType("Budgeteer.Services.BudgeteerApi.Domain.Transactions.Transaction");

                    b.HasDiscriminator().HasValue(1);
                });

            modelBuilder.Entity("Budgeteer.Services.BudgeteerApi.Domain.Documents.Document", b =>
                {
                    b.HasOne("Budgeteer.Services.BudgeteerApi.Domain.Transactions.Transaction", null)
                        .WithMany("EnclosedDocuments")
                        .HasForeignKey("TransactionId");
                });

            modelBuilder.Entity("Budgeteer.Services.BudgeteerApi.Domain.Transactions.Transaction", b =>
                {
                    b.HasOne("Budgeteer.Services.BudgeteerApi.Domain.Books.Book", null)
                        .WithMany("Transactions")
                        .HasForeignKey("BookId");
                });

            modelBuilder.Entity("TagTransaction", b =>
                {
                    b.HasOne("Budgeteer.Services.BudgeteerApi.Domain.Tags.Tag", null)
                        .WithMany()
                        .HasForeignKey("TagsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Budgeteer.Services.BudgeteerApi.Domain.Transactions.Transaction", null)
                        .WithMany()
                        .HasForeignKey("TransactionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Budgeteer.Services.BudgeteerApi.Domain.Books.Book", b =>
                {
                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("Budgeteer.Services.BudgeteerApi.Domain.Transactions.Transaction", b =>
                {
                    b.Navigation("EnclosedDocuments");
                });
#pragma warning restore 612, 618
        }
    }
}