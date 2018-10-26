using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AntiqueStore.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string BookAuthor { get; set; }
        public string BookTitle { get; set; }
        public int BookQuantity { get; set; }
        public int BookReleased { get; set; }
        public string BookPublisher { get; set; }
        public int BookPages { get; set; }
        public int? BookSeries { get; set; } 

        public BookSeries BookSeries { get; set; }
    }
}
