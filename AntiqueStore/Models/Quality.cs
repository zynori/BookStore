using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AntiqueStore.Models
{
    public partial class Quality
    {
        public int QualityId { get; set; }
        public string Condition { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
