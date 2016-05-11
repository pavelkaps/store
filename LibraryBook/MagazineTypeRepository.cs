using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data.Entity;

namespace LibraryBook
{
    public class MagazineTypeRepository : IEntityRepository<MagazineType>
    {
        LibraryContext dbContext;
        public MagazineTypeRepository(LibraryContext a)
        {
            dbContext = a;
        }
        public void Insert(MagazineType a)
        {
            
            dbContext.dbType.Add(a);
            dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            
            MagazineType type = dbContext.dbType.Find(id);
            dbContext.dbType.Remove(type);
            dbContext.SaveChanges();
        }

        public IDbSet<MagazineType> Load()
        {
            dbContext.dbType.Load();
            return dbContext.dbType;
        }

        public MagazineType Find(int id)
        {
            MagazineType type = dbContext.dbType.Find(id);
            return type;
        }

        public void Update()
        {
            dbContext.SaveChanges();
        }

    }

}
