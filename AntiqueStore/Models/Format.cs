using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AntiqueStore.Models
{
    public class Format
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Binding { get; set; }

        [InverseProperty("Format")]
        public virtual ICollection<Book> Books { get; set; }
    }
}
