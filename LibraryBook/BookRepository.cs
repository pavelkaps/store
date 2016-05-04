using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel;
namespace LibraryBook
{
    public class BookRepository : IEntityRepository<IDbSet<Book>>
    {
        BookContext dbContext;
       public BookRepository()
       {
           dbContext = new BookContext();

       }
        public void Insert(object a)
        {
            //var dbContext = new BookContext();
            dbContext.dbBooks.Add((Book)a);
            dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            //var dbContext = new BookContext();
            Book book = dbContext.dbBooks.Find(id);
            dbContext.dbBooks.Remove(book);
            dbContext.SaveChanges();
        }

        public IDbSet<Book> Load()
        {
            //var dbContext = new BookContext();
            dbContext.dbBooks.Load();
            dbContext.dbGenre.Load();
            return dbContext.dbBooks;
        }

        public object Find(int id)
        {
            //var dbContext = new BookContext();
            Book book = dbContext.dbBooks.Find(id);
            return book;
        }

        public void Update(object a){
            //var db = new BookContext();
            ////db.dbBooks.Load();
            ////db.Entry((Book)a).State = EntityState.Modified;
            dbContext.SaveChanges();
        }
    }
}
