using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace LibraryBook
{
    class MagazineRepository:IEntityRepository<Magazine>
    {
        public void Insert(object a)
        {
            var dbContext = new MagazineContext();
            dbContext.Journals.Add((Magazine)a);
            dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var dbContext = new MagazineContext();
            Magazine m = dbContext.Journals.Find(id);
            dbContext.Journals.Remove(m);
            dbContext.SaveChanges();
        }

        public List<Magazine> Load()
        {
            var dbContext = new MagazineContext();
            List<Magazine> m = new List<Magazine>();
            dbContext.Journals.Load();

            m = dbContext.Journals.Local.ToList();
            return m;
        }

        public object Find(int id)
        {
            var dbContext = new MagazineContext();
            Magazine m = dbContext.Journals.Find(id);
            return m;
        }
    }
}
