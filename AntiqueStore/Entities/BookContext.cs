using AntiqueStore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AntiqueStore.Entities
{
    public class BookContext : DbContext
    {
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Format> Formats { get; set; }
        public virtual DbSet<Quality> Qualities { get; set; }

        public BookContext(DbContextOptions<BookContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Format>().HasData(
                new { FormatId = 1, Binding = "Paperback"},
                new { FormatId = 2, Binding = "Hardcover"}
                );

            modelBuilder.Entity<Quality>().HasData(
                new { QualityId = 1, Qualities = "Good" },
                new { QualityId = 2, Qualities = "Bad" }
                );

            modelBuilder.Entity<Book>().HasData(
                new { BookId = 1, Author = "Andre Aciman", Title = "Call Me By Your Name", Language = "English", Page = 256, PublicationDate = "03/Apr/2018", Quantity = 2, Price = 6999, FormatId = 2, QualityId = 1 },
                new { BookId = 2, Author = "Stephen King", Title = "Elevation", Language = "English", Page = 160, PublicationDate = "30/Oct/2018", Quantity = 1, Price = 2399, FormatId = 1, QualityId = 2 }
                );
        }
    }
}
