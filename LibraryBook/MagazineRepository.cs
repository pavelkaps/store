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
        LibraryContext dbContext;
        public MagazineRepository(LibraryContext a)
        {
            dbContext = a;
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
        public void Update()
        {
            dbContext.SaveChanges();
        }
        
       
    }
}
