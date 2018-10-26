using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AntiqueStore.Models
{
    public class BookSeries
    {
        public int BookSeriesId { get; set; }
        public string BookSeriesTitle { get; set; }
        public int BookSeriesPart { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
