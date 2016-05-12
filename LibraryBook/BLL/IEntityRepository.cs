using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data.Entity;
namespace LibraryBook
{
    public interface IEntityRepository<T>
    {
        void Insert(T a);
        void Delete(int id);
        T Find(int id);
        void Update();
        List<T> Load();  
    }
}
