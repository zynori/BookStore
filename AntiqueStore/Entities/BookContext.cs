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
                new { Id = 1, Binding = "Paperback"},
                new { Id = 2, Binding = "Hardcover"}
                );

            modelBuilder.Entity<Quality>().HasData(
                new { Id = 1, Condition = "Good" },
                new { Id = 2, Condition = "Bad" }
                );

            modelBuilder.Entity<Book>().HasData(
                new { Id = 1, Author = "Andre Aciman 2", Title = "Call Me By Your Name", Language = "English", FormatId = 1, Page = 256, PublicationDate = DateTime.Today, QualityId = 1, Quantity = 2, Price = 6999 },
                new { Id = 2, Author = "Stephen King", Title = "Elevation", Language = "English", FormatId = 2, Page = 160, PublicationDate = DateTime.Today, QualityId = 1, Quantity = 1, Price = 2399 }
                );
        }
    }
}
