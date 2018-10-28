using AntiqueStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AntiqueStore.Services
{
    public interface IGenericService<Object>
    {
        List<Object> ReadAll();
        void Add(Object element);
        void Delete(int id);
        Object GetElementById(int id);
        void Edit(Object element);

        List<Object> Search(string input);
    }
}
