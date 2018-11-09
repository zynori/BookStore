using AntiqueStore.Models;
using AntiqueStore.Repositories;
using AntiqueStore.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AntiqueStore.Services
{
    public class BookService
    {
        private BookRepository bookRepository;
        private QualityRepository qualityRepository;
        private FormatRepository formatRepository;
        private int allSpace = 5000;
        private double price = 150;

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
            Book deletable = GetBookById(id);
            bookRepository.Delete(deletable);
        }

        public void SellBook(int id)
        {
            GetBookById(id).Quantity--;
            bookRepository.Update(GetBookById(id));
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

        public BookViewModel Search(string input = "", bool inStock = false)
        {
            if (input is null)
            {
                input = "";
            }

            BookViewModel viewModel = this.GetAll();

            if (input == "" && !inStock)
            {
                return viewModel;
            }

            viewModel.Books = viewModel.Books.Where(
                x => (x.Author.ToLower().Contains(input.ToLower()) || x.Title.ToLower().Contains(input.ToLower())) && (!inStock || x.Quantity > 0)
            );

            return viewModel;
        }

        public int CalculateSalePrice(Book book)
        {
            int previousPrice = GetPreviousPrice(book);

            if (previousPrice != 0)
            {
                return (int)Math.Round(previousPrice * 0.5);
            }

            for (int i = 200; i < book.Page; i += 200)
            {
                price *= 1.25;
            }

            if (book.PublicationDate.Year < 1900)
            {
                price *= 1.85;
            }
            else if (book.PublicationDate.Year < 1945)
            {
                price *= 1.25;
            }

            if (GetFreeSpaceLeft() < allSpace * 0.1)
            {
                price *= 0.6;
            }
            else if (GetFreeSpaceLeft() < allSpace * 0.5)
            {
                price *= 0.8;
            }
            
            return (int)Math.Round(price);
        }

        public int GetPreviousPrice(Book book)
        {
            bool bookInStock = true;

            bookInStock = bookRepository.Read().Where(x => x.Author.Equals(book.Author) && x.Title.Equals(book.Title) && x.PublicationDate.Equals(book.PublicationDate)).Any();

            if (!bookInStock)
            {
                return 0;
            }

            return book.Price;
        }

        public int GetFreeSpaceLeft()
        {
            int booksIn = 0;

            foreach (Book book in bookRepository.Read())
            {
                booksIn += book.Quantity;
            }

            int freeSpace = allSpace - booksIn;

            return freeSpace;
        }
    }
}
