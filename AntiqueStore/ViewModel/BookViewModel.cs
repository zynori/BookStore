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
        public List<Format> Formats { get; set; }
        public List<Quality> Qualities { get; set; }

        public BookViewModel()
        {
            Books = new List<Book>();
            Formats = new List<Format>();
            Qualities = new List<Quality>();
        }
    }
}
