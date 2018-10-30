using AntiqueStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AntiqueStore.ViewModel
{
    public class BookViewModel
    {
        public List<Book> Books { get; set; }
        public Book SelectedBook { get; set; }
        public double Price { get; set; }

        public List<string> Formats { get; set; }
        public List<string> Qualities { get; set; }
    }
}
