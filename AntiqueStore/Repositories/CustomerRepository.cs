using AntiqueStore.Entities;
using AntiqueStore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AntiqueStore.Repositories
{
    public class CustomerRepository : IGenericRepository<Customer>
    {
        BookContext database;

        public CustomerRepository(BookContext database)
        {
            this.database = database;
        }

        public void Create(Customer customer)
        {
            database.Customers.Add(customer);
            database.SaveChanges();
        }

        public void Delete(Customer customer)
        {
            database.Customers.Remove(customer);
            database.SaveChanges();
        }

        public Customer GetRecordById(int id)
        {
            return Read().FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Customer> Read()
        {
            return database.Customers
                .Include(x => x.Orders)
                .ToList();
        }

        public void Update(Customer customer)
        {
            database.Customers.Update(customer);
            database.SaveChanges();
        }
    }
}
