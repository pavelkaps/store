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
        LibraryContext dbContext;
        public BookGenreRepository(LibraryContext a)
        {
            dbContext = a;
        }
        public void Insert(BookGenre a)
        {
            
            dbContext.dbGenre.Add(a);
            dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            
            BookGenre book = dbContext.dbGenre.Find(id);
            dbContext.dbGenre.Remove(book);
            dbContext.SaveChanges();
        }

        public IDbSet<BookGenre> Load()
        {
            
            dbContext.dbGenre.Load();
            return dbContext.dbGenre;
        }

        public BookGenre Find(int id)
        {
            
            BookGenre genre = dbContext.dbGenre.Find(id);
            return genre;
        }
        public void Update()
        {
           dbContext.SaveChanges();
        }
    }
}
