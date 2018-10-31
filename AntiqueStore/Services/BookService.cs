using AntiqueStore.Models;
using AntiqueStore.Repositories;
using AntiqueStore.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AntiqueStore.Services
{
    public class BookService //: IGenericService<Book>
    {
        private BookRepository bookRepository;
        private QualityRepository qualityRepository;
        private FormatRepository formatRepository;

        public BookService(BookRepository bookRepository, QualityRepository qualityRepository, FormatRepository formatRepository)
        {
            this.bookRepository = bookRepository;
            this.qualityRepository = qualityRepository;
            this.formatRepository = formatRepository;
        }

        public void AddBook(Book book)
        {
            bookRepository.Create(book);
        }
        
        public void DeleteBook(int id)
        {
            Book deletable = bookRepository.GetRecordById(id);
            bookRepository.Delete(deletable);
        }

        public void SellBook(int id)
        {
            bookRepository.GetRecordById(id).Quantity--;
            bookRepository.Update(bookRepository.GetRecordById(id));
        }

        public void EditBook(Book book)
        {
            bookRepository.Update(book);
        }

        public Book GetBookById(int id)
        {
            return bookRepository.GetRecordById(id);
        }

        public IEnumerable<Book> GetBooks()
        {
            return bookRepository.Read();
        }
        
        public IEnumerable<Format> GetFormats()
        {
            return formatRepository.Read();
        }

        public IEnumerable<Quality> GetQualities()
        {
            return qualityRepository.Read();
        }

        public BookViewModel GetAll()
        {
            return new BookViewModel()
            {
                Books = GetBooks(),
                Formats = GetFormats(),
                Qualities = GetQualities()
            };
        }

        public IEnumerable<Book> Search(string input, bool inStock)
        {
            if(input is null && inStock)
            {
                return GetBooks();
            }

            return bookRepository.Read().Where(x => (x.Author.ToLower().Contains(input.ToLower()) || x.Title.ToLower().Contains(input.ToLower())) && (!inStock || x.Quantity > 0)).ToList();
        }

        public void ForSale(Book book)
        {
            int price = 300;

            if (book.Page > 200)
            {
                price += 300;
            }

            bookRepository.Create(book);
        }
    }
}
