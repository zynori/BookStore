using AntiqueStore.Entities;
using AntiqueStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AntiqueStore.Repositories
{
    public class QualityRepository : IGenericRepository<Quality>
    {
        BookContext database;

        public QualityRepository(BookContext database)
        {
            this.database = database;
        }

        public void Create(Quality quality)
        {
            database.Qualities.Add(quality);
            database.SaveChanges();
        }

        public void Delete(Quality quality)
        {
            database.Qualities.Remove(quality);
            database.SaveChanges();
        }

        public Quality GetRecordById(int id)
        {
            return Read().FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Quality> Read()
        {
            return database.Qualities.ToList();
        }

        public void Update(Quality quality)
        {
            database.Qualities.Update(quality);
            database.SaveChanges();
        }
    }
}
