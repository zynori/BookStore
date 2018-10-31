using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AntiqueStore.Models
{
    public class Quality
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Condition { get; set; }

        [InverseProperty("Quality")]
        public virtual ICollection<Book> Books { get; set; }
    }
}
