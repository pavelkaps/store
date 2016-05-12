using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace LibraryBook
{
    public class EntityRepository<T> : IEntityRepository<T> where T : class
    {
        LibraryContext dbContext;

        public EntityRepository(LibraryContext context)
        {
            dbContext = context;

        }
        public void Insert(T entity)
        {
            dbContext.Set<T>().Add(entity);
            dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            T entity = dbContext.Set<T>().Find(id);
            dbContext.Set<T>().Remove(entity);
            dbContext.SaveChanges();
        }

        public List<T> Load()
        {
            //dbContext.dbBooks.Load();
            //dbContext.dbGenre.Load();
            return dbContext.Set<T>().ToList();
        }

        public T Find(int id)
        {
            return dbContext.Set<T>().Find(id);
        }

        public void Update()
        {
            dbContext.SaveChanges();
        }
    }
}
