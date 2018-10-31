using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AntiqueStore.Models
{
    public class Format
    {
        public int Id { get; set; }
        public string Binding { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
