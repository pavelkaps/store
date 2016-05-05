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
       BookContext dbContext;

       public BookRepository()
       {
           dbContext = new BookContext();

       }
        public void Insert(Book a)
        {
            //var dbContext = new BookContext();
            dbContext.dbBooks.Add(a);
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

        public Book Find(int id)
        {
            //var dbContext = new BookContext();
            Book book = dbContext.dbBooks.Find(id);
            return book;
        }

        public void Update(Book a,int id){
            BookGenre Genre = dbContext.dbGenre.Find(id);
            a.BookGenre = Genre;
            
            dbContext.Entry(a).State = EntityState.Modified;
            
            dbContext.SaveChanges();
        }

        public void InsertWithId(Book a, int id)
        {
            BookGenre Genre = dbContext.dbGenre.Find(id);
            a.BookGenre = Genre;
            dbContext.dbBooks.Add(a);
            dbContext.SaveChanges();
        }
    }
}
