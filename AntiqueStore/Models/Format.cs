﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AntiqueStore.Models
{
    public partial class Format
    {
        public int FormatId { get; set; }
        public string Binding { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
