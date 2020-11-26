using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoardMVC.Services
{
    interface IRestService<T>
    {
        List<T> Get();
        T Get(long id);
        T Post(T value);
        bool Put(T value);
        T Delete(long id);
    }
}
