using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AntiqueStore.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public string Language { get; set; }
        public int Page { get; set; }
        public string PublicationDate { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }

        public Format Format { get; set; }
        public Quality Quality { get; set; }
    }
}
