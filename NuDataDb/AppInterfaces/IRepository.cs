using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NuDataDb.AppInterfaces
{
    public interface IRepository<T>
    {
        IEnumerable<T> Get();
        IQueryable<T> GetAsQueryable();
        T GetSingle(int id);
        T GetSingle(Guid id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(int id);
        void Delete(Guid id);
        int Save();


    }
}
