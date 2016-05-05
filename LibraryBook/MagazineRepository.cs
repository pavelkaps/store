using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel;
namespace LibraryBook
{
    public class MagazineRepository : IEntityRepository<Magazine>
    {
        MagazineContext dbContext;
        public MagazineRepository()
        {
            dbContext = new MagazineContext();
        }
        public void Insert(Magazine a)
        {
            dbContext.dbJournals.Add(a);
            dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            Magazine m = dbContext.dbJournals.Find(id);
            dbContext.dbJournals.Remove(m);
            dbContext.SaveChanges();
        }

        public IDbSet<Magazine> Load()
        {
            dbContext.dbJournals.Load();
            dbContext.dbType.Load();
            return dbContext.dbJournals;
        }
        
        public Magazine Find(int id)
        {
            Magazine m = dbContext.dbJournals.Find(id);
            return m;
        }
        public void Update(Magazine a, int id)
        {
            MagazineType Genre = dbContext.dbType.Find(id);
            a.MagazineType = Genre;
            dbContext.Entry(a).State = EntityState.Modified;
            dbContext.SaveChanges();
        }
        
        public void InsertWithId(Magazine a, int id)
        {
            MagazineType Type = dbContext.dbType.Find(id);
            a.MagazineType = Type;
            dbContext.dbJournals.Add(a);
            dbContext.SaveChanges();
        }
    }
}
