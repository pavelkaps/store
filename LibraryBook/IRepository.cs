using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBook
{
    abstract class IRepository
    {
        public abstract void Insert(object a);
        public abstract void Delete(int id);
        public abstract object Find(int id);
    }
}
