﻿using AntiqueStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AntiqueStore.ViewModel
{
    public class BookViewModel
    {
        public IEnumerable<Book> Books { get; set; }
        public Book SelectedBook { get; set; }
        public IEnumerable<Format> Formats { get; set; }
        public IEnumerable<Quality> Qualities { get; set; }
    }
}
