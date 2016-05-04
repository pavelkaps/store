using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data.Entity;

namespace LibraryBook
{
    public class MagazineTypeRepository : IEntityRepository<IDbSet<MagazineType>>
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

        public IDbSet<MagazineType> Load()
        {
            var dbContext = new MagazineContext();
            dbContext.dbType.Load();
            return dbContext.dbType;
        }

        public object Find(int id)
        {
            var dbContext = new MagazineContext();
            MagazineType type = dbContext.dbType.Find(id);
            return type;
        }

        public void Update(object a)
        {
            var db = new MagazineContext();
            db.dbType.Load();
            db.Entry((MagazineType)a).State = EntityState.Modified;
            db.SaveChanges();
        }

    }

}
