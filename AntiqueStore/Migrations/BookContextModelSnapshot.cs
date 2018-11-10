﻿// <auto-generated />
using System;
using AntiqueStore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AntiqueStore.Migrations
{
    [DbContext(typeof(BookContext))]
    partial class BookContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AntiqueStore.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Author");

                    b.Property<int>("FormatId");

                    b.Property<string>("Language");

                    b.Property<int>("Page");

                    b.Property<int>("Price");

                    b.Property<DateTime>("PublicationDate");

                    b.Property<int>("QualityId");

                    b.Property<int>("Quantity");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("FormatId");

                    b.HasIndex("QualityId");

                    b.ToTable("Books");

                    b.HasData(
                        new { Id = 1, Author = "Andre Aciman 2", FormatId = 1, Language = "English", Page = 256, Price = 6999, PublicationDate = new DateTime(2018, 11, 10, 0, 0, 0, 0, DateTimeKind.Local), QualityId = 1, Quantity = 2, Title = "Call Me By Your Name" },
                        new { Id = 2, Author = "Stephen King", FormatId = 2, Language = "English", Page = 160, Price = 2399, PublicationDate = new DateTime(2018, 11, 10, 0, 0, 0, 0, DateTimeKind.Local), QualityId = 1, Quantity = 1, Title = "Elevation" }
                    );
                });

            modelBuilder.Entity("AntiqueStore.Models.BookOrder", b =>
                {
                    b.Property<int>("BookId");

                    b.Property<int>("OrderId");

                    b.HasKey("BookId", "OrderId");

                    b.HasIndex("OrderId");

                    b.ToTable("BookOrders");
                });

            modelBuilder.Entity("AntiqueStore.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.HasKey("Id");

                    b.ToTable("Customers");

                    b.HasData(
                        new { Id = 1, CreatedAt = new DateTime(2018, 11, 10, 0, 0, 0, 0, DateTimeKind.Local), Email = "jeno@gmail.com", FirstName = "Bela", LastName = "Kovacs" },
                        new { Id = 2, CreatedAt = new DateTime(2018, 11, 10, 0, 0, 0, 0, DateTimeKind.Local), Email = "bela@gmail.com", FirstName = "Jeno", LastName = "Toth" }
                    );
                });

            modelBuilder.Entity("AntiqueStore.Models.Format", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Binding");

                    b.HasKey("Id");

                    b.ToTable("Formats");

                    b.HasData(
                        new { Id = 1, Binding = "Paperback" },
                        new { Id = 2, Binding = "Hardcover" }
                    );
                });

            modelBuilder.Entity("AntiqueStore.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CustomerId");

                    b.Property<int>("Number");

                    b.Property<DateTime>("OrderedAt");

                    b.Property<int>("ShippingCost");

                    b.Property<int>("TotalPrice");

                    b.Property<int>("TotalQuantity");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Orders");

                    b.HasData(
                        new { Id = 1, CustomerId = 1, Number = 12193913, OrderedAt = new DateTime(2018, 11, 10, 0, 0, 0, 0, DateTimeKind.Local), ShippingCost = 2424, TotalPrice = 5432, TotalQuantity = 2 },
                        new { Id = 2, CustomerId = 2, Number = 94384938, OrderedAt = new DateTime(2018, 11, 10, 0, 0, 0, 0, DateTimeKind.Local), ShippingCost = 123, TotalPrice = 542, TotalQuantity = 1 }
                    );
                });

            modelBuilder.Entity("AntiqueStore.Models.Quality", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Condition");

                    b.HasKey("Id");

                    b.ToTable("Qualities");

                    b.HasData(
                        new { Id = 1, Condition = "Good" },
                        new { Id = 2, Condition = "Bad" }
                    );
                });

            modelBuilder.Entity("AntiqueStore.Models.Book", b =>
                {
                    b.HasOne("AntiqueStore.Models.Format", "Format")
                        .WithMany("Books")
                        .HasForeignKey("FormatId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AntiqueStore.Models.Quality", "Quality")
                        .WithMany("Books")
                        .HasForeignKey("QualityId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AntiqueStore.Models.BookOrder", b =>
                {
                    b.HasOne("AntiqueStore.Models.Book", "Book")
                        .WithMany("BookOrders")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AntiqueStore.Models.Order", "Order")
                        .WithMany("BookOrders")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AntiqueStore.Models.Order", b =>
                {
                    b.HasOne("AntiqueStore.Models.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
