using AntiqueStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AntiqueStore.ViewModel
{
    public class CustomerViewModel
    {
        public IEnumerable<Book> Books { get; set; }
        public Customer SelectedCustomer { get; set; }
        public IEnumerable<Order> Orders { get; set; }
        public IEnumerable<Customer> Customers { get; set; }
    }
}
