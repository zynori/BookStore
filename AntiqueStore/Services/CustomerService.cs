using AntiqueStore.Models;
using AntiqueStore.Repositories;
using AntiqueStore.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AntiqueStore.Services
{
    public class CustomerService
    {
        private CustomerRepository customerRepository;
        private OrderRepository orderRepository;
        private BookRepository bookRepository;

        public CustomerService(CustomerRepository customerRepository, OrderRepository orderRepository, BookRepository bookRepository)
        {
            this.customerRepository = customerRepository;
            this.orderRepository = orderRepository;
            this.bookRepository = bookRepository;
        }

        public void AddCustomer(Customer customer)
        {
            customerRepository.Create(customer);
        }

        public void DeleteCustomer(int id)
        {
            Customer deletable = GetCustomerById(id);
            customerRepository.Delete(deletable);
        }

        public void EditCustomer(Customer customer)
        {
            customerRepository.Update(customer);
        }

        public Customer GetCustomerById(int id)
        {
            return customerRepository.GetRecordById(id);
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return customerRepository.Read();
        }

        public IEnumerable<Order> GetOrders()
        {
            return orderRepository.Read();
        }

        public IEnumerable<Book> GetBooks()
        {
            return bookRepository.Read();
        }

        public CustomerViewModel GetAllCustomer()
        {
            return new CustomerViewModel()
            {
                Customers = GetCustomers(),
                Orders = GetOrders(),
                Books = GetBooks()
            };
        }
    }
}
