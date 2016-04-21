using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBook
{
    interface IEntityRepository<T>
    {
        public void Insert(object a);
        public void Delete(int id);
        public object Find(int id);
        public List<T> Load();
    }
}
