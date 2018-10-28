using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AntiqueStore.Repositories
{
    public interface IGenericRepository<Object>
    {
        void Create(Object element);
        List<Object> Read();
        void Update(Object element);
        void Delete(Object element);

        Object GetRecordById(int id);
    }
}
