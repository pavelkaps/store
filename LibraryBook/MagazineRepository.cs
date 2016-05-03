using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel;
namespace LibraryBook
{
    public class MagazineRepository : IEntityRepository<IDbSet<Magazine>>
    {
        public void Insert(object a)
        {
            var dbContext = new MagazineContext();
            dbContext.dbJournals.Add((Magazine)a);
            dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var dbContext = new MagazineContext();
            Magazine m = dbContext.dbJournals.Find(id);
            dbContext.dbJournals.Remove(m);
            dbContext.SaveChanges();
        }

        public IDbSet<Magazine> Load()
        {
            var dbContext = new MagazineContext();
            dbContext.dbJournals.Load();
            dbContext.dbType.Load();
            return dbContext.dbJournals;
        }
        


        public object Find(int id)
        {
            var dbContext = new MagazineContext();
            Magazine m = dbContext.dbJournals.Find(id);
            return m;
        }
    }
}
