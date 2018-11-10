using AntiqueStore.Entities;
using AntiqueStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AntiqueStore.Repositories
{
    public class OrderRepository : IGenericRepository<Order>
    {
        BookContext database;

        public OrderRepository(BookContext database)
        {
            this.database = database;
        }

        public void Create(Order order)
        {
            database.Orders.Add(order);
            database.SaveChanges();
        }

        public void Delete(Order order)
        {
            database.Orders.Remove(order);
            database.SaveChanges();
        }

        public Order GetRecordById(int id)
        {
            return Read().FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Order> Read()
        {
            return database.Orders.ToList();
        }

        public void Update(Order order)
        {
            database.Orders.Update(order);
            database.SaveChanges();
        }
    }
}
