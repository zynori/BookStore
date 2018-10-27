using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AntiqueStore.Models
{
    public class Book
    {
        public long Id { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int PublicationDate { get; set; }
        public string Publisher { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }

        public virtual List<Dimension> Dimensions { get; set; }
        public virtual List<Format> Formats { get; set; }
    }
}
