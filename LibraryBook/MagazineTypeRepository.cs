using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data.Entity;

namespace LibraryBook
{
    class MagazineTypeRepository:IEntityRepository<MagazineType>
    {
        public void Insert(object a)
        {
            var dbContext = new MagazineContext();
            dbContext.dbType.Add((MagazineType)a);
            dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var dbContext = new MagazineContext();
            MagazineType type = dbContext.dbType.Find(id);
            dbContext.dbType.Remove(type);
            dbContext.SaveChanges();
        }

        public BindingList<MagazineType> Load()
        {
            var dbContext = new MagazineContext();
            BindingList<MagazineType> genre = new BindingList<MagazineType>();
            dbContext.dbType.Load();

            genre = dbContext.dbType.Local.ToBindingList();
            return genre;
        }

        public object Find(int id)
        {
            var dbContext = new MagazineContext();
            MagazineType type = dbContext.dbType.Find(id);
            return type;
        }

    }

}
