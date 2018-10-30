using AntiqueStore.Models;
using AntiqueStore.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AntiqueStore.Services
{
    public class BookService : IGenericService<Book>
    {
        private BookRepository bookRepository;

        public BookService(BookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        public void Add(Book book)
        {
            bookRepository.Create(book);
        }

        public void Delete(int id)
        {
            Book deletable = bookRepository.GetRecordById(id);
            bookRepository.Delete(deletable);
        }

        public void Edit(Book book)
        {
            bookRepository.Update(book);
        }

        public Book GetElementById(int id)
        {
            return bookRepository.GetRecordById(id);
        }

        public IEnumerable<Book> ReadAll()
        {
            return bookRepository.Read();
        }
        
        public IEnumerable<Book> Search(string input, bool inStock)
        {
            if(input is null)
            {
                return ReadAll();
            }

            return bookRepository.Read().Where(x => x.Title.ToLower().Contains(input.ToLower()) && (!inStock || x.Quantity > 0 )).ToList();
        }
    }
}
