using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data.Entity;
namespace LibraryBook
{
    public class BookGenreRepository : IEntityRepository<BookGenre>
    {
        BookContext dbContext;
        public BookGenreRepository()
        {
            dbContext = new BookContext();
        }
        public void Insert(BookGenre a)
        {
            //var dbContext = new BookContext();
            dbContext.dbGenre.Add(a);
            dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            //var dbContext = new BookContext();
            BookGenre book = dbContext.dbGenre.Find(id);
            dbContext.dbGenre.Remove(book);
            dbContext.SaveChanges();
        }

        public IDbSet<BookGenre> Load()
        {
            //var dbContext = new BookContext();
            dbContext.dbGenre.Load();
            return dbContext.dbGenre;
        }

        public BookGenre Find(int id)
        {
            //var dbContext = new BookContext();
            BookGenre genre = dbContext.dbGenre.Find(id);
            return genre;
        }
        public void Update(BookGenre a)
        {
           dbContext.SaveChanges();
        }
    }
}
