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
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<BookOrder> BookOrders { get; set; }

        public BookContext(DbContextOptions<BookContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookOrder>().HasKey(sc => new { sc.BookId, sc.OrderId });

            modelBuilder.Entity<BookOrder>()
                .HasOne<Book>(sc => sc.Book)
                .WithMany(s => s.BookOrders)
                .HasForeignKey(sc => sc.BookId);

            modelBuilder.Entity<BookOrder>()
                .HasOne<Order>(sc => sc.Order)
                .WithMany(s => s.BookOrders)
                .HasForeignKey(sc => sc.OrderId);

            modelBuilder.Entity<Format>().HasData(
                new { Id = 1, Binding = "Paperback" },
                new { Id = 2, Binding = "Hardcover" }
                );

            modelBuilder.Entity<Quality>().HasData(
                new { Id = 1, Condition = "Good" },
                new { Id = 2, Condition = "Bad" }
                );

            modelBuilder.Entity<Book>().HasData(
                new { Id = 1, Author = "Andre Aciman 2", Title = "Call Me By Your Name", Language = "English", FormatId = 1, Page = 256, PublicationDate = DateTime.Today, QualityId = 1, Quantity = 2, Price = 6999 },
                new { Id = 2, Author = "Stephen King", Title = "Elevation", Language = "English", FormatId = 2, Page = 160, PublicationDate = DateTime.Today, QualityId = 1, Quantity = 1, Price = 2399 }
                );

            modelBuilder.Entity<Customer>().HasData(
                new { Id = 1, CreatedAt = DateTime.Today, LastName = "Kovacs", FirstName = "Bela", Email = "jeno@gmail.com" },
                new { Id = 2, CreatedAt = DateTime.Today, LastName = "Toth", FirstName = "Jeno", Email = "bela@gmail.com" }
                );

            //modelBuilder.Entity<Order>().HasData(
            //    new { Id = 1, Number = 12193913, TotalQuantity = 2, ShippingCost = 2424, TotalPrice = 5432, OrderedAt = DateTime.Today, CustomerId = 1, Books = 1},
            //    new { Id = 2, Number = 94384938, TotalQuantity = 1, ShippingCost = 123, TotalPrice = 542, OrderedAt = DateTime.Today, CustomerId = 2, Books = 2 }
            //    );
        }
    }
}
