using AntiqueStore.Entities;
using AntiqueStore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AntiqueStore.Repositories
{
    public class FormatRepository : IGenericRepository<Format>
    {
        BookContext database;

        public FormatRepository(BookContext database)
        {
            this.database = database;
        }

        public void Create(Format format)
        {
            database.Formats.Add(format);
            database.SaveChanges();
        }

        public void Delete(Format format)
        {
            database.Formats.Remove(format);
            database.SaveChanges();
        }

        public Format GetRecordById(int id)
        {
            return Read().FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Format> Read()
        {
            return database.Formats
                .ToList();
        }

        public void Update(Format format)
        {
            database.Formats.Update(format);
            database.SaveChanges();
        }
    }
}
