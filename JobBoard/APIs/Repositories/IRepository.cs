using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIs.Repositories
{
    interface IRepository<T>
    {
        IQueryable<T> Get();
        T Get(long id);
        T Post(T value);
        bool Put(T value, long id);
        T Delete(long id);
    }
}
