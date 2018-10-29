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
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Author");

                    b.Property<int?>("FormatId");

                    b.Property<string>("Language");

                    b.Property<int>("Page");

                    b.Property<int>("Price");

                    b.Property<string>("PublicationDate");

                    b.Property<int?>("QualityId");

                    b.Property<int>("Quantity");

                    b.Property<string>("Title");

                    b.HasKey("BookId");

                    b.HasIndex("FormatId");

                    b.HasIndex("QualityId");

                    b.ToTable("Books");

                    b.HasData(
                        new { BookId = 1, Author = "Andre Aciman", FormatId = 2, Language = "English", Page = 256, Price = 6999, PublicationDate = "03/Apr/2018", QualityId = 1, Quantity = 2, Title = "Call Me By Your Name" },
                        new { BookId = 2, Author = "Stephen King", FormatId = 1, Language = "English", Page = 160, Price = 2399, PublicationDate = "30/Oct/2018", QualityId = 2, Quantity = 1, Title = "Elevation" }
                    );
                });

            modelBuilder.Entity("AntiqueStore.Models.Format", b =>
                {
                    b.Property<int>("FormatId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Binding");

                    b.HasKey("FormatId");

                    b.ToTable("Formats");

                    b.HasData(
                        new { FormatId = 1, Binding = "Paperback" },
                        new { FormatId = 2, Binding = "Hardcover" }
                    );
                });

            modelBuilder.Entity("AntiqueStore.Models.Quality", b =>
                {
                    b.Property<int>("QualityId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Condition");

                    b.HasKey("QualityId");

                    b.ToTable("Qualities");

                    b.HasData(
                        new { QualityId = 1 },
                        new { QualityId = 2 }
                    );
                });

            modelBuilder.Entity("AntiqueStore.Models.Book", b =>
                {
                    b.HasOne("AntiqueStore.Models.Format", "Formats")
                        .WithMany("Books")
                        .HasForeignKey("FormatId");

                    b.HasOne("AntiqueStore.Models.Quality", "Qualities")
                        .WithMany("Books")
                        .HasForeignKey("QualityId");
                });
#pragma warning restore 612, 618
        }
    }
}
