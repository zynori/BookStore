using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AntiqueStore.Models
{
    public class Book
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public string Language { get; set; }
        public int Page { get; set; }
        public DateTime PublicationDate { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }

        [ForeignKey("Format")]
        public int FormatId { get; set; }
        public virtual Format Format { get; set; }
        [ForeignKey("Quality")]
        public int QualityId { get; set; }
        public virtual Quality Quality { get; set; }
    }
}
