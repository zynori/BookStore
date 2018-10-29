using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AntiqueStore.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public string Language { get; set; }
        public int Page { get; set; }
        public string PublicationDate { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }

        public int? FormatId { get; set; }
        public int? QualityId { get; set; }

        public Format Formats { get; set; }
        public Quality Qualities { get; set; }
    }
}
