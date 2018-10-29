using AntiqueStore.Entities;
using AntiqueStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AntiqueStore.Repositories
{
    public class BookRepository : IGenericRepository<Book>
    {
        BookContext database;

        public BookRepository(BookContext database)
        {
            this.database = database;
        }

        public void Create(Book book)
        {
            database.Books.Add(book);
            database.SaveChanges();
        }

        public void Delete(Book book)
        {
            database.Books.Remove(book);
            database.SaveChanges();
        }

        public Book GetRecordById(int id)
        {
            return database.Books.ToList().FirstOrDefault(x => x.BookId == id);
        }

        public IEnumerable<Book> Read()
        {
            return database.Books.ToList();
        }

        public void Update(Book book)
        {
            database.Books.Update(book);
            database.SaveChanges();
        }
    }
}
