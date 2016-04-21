using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBook
{
    interface IEntityRepository<T>
    {
        void Insert(object a);
        void Delete(int id);
        object Find(int id);
        List<T> Load();
    }
}
