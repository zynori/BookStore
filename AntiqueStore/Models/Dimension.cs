using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AntiqueStore.Models
{
    public class Dimension
    {
        public int Id { get; set; }
        public string Size { get; set; }
        public double Weight { get; set; }

        public int BookId { get; set; }
    }
}
