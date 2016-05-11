using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel;
namespace LibraryBook
{
    public class BookRepository : IEntityRepository<Book>
    {
       LibraryContext dbContext;

       public BookRepository(LibraryContext a)
       {
           dbContext = a;

       }
        public void Insert(Book a)
        {
            dbContext.dbBooks.Add(a);
            dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            Book book = dbContext.dbBooks.Find(id);
            dbContext.dbBooks.Remove(book);
            dbContext.SaveChanges();
        }

        public IDbSet<Book> Load()
        {
            dbContext.dbBooks.Load();
            dbContext.dbGenre.Load();
            return dbContext.dbBooks;
        }

        public Book Find(int id)
        {
            Book book = dbContext.dbBooks.Find(id);
            return book;
        }

        public void Update(){
            dbContext.SaveChanges();
        }

    }
}
