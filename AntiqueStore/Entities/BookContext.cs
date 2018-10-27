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
        public virtual DbSet<Dimension> Dimensions { get; set; }
        public virtual DbSet<Format> Formats { get; set; }

        public BookContext(DbContextOptions<BookContext> options) : base(options)
        {

        }
    }
}
