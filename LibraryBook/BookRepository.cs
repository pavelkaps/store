using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace LibraryBook
{
    class BookRepository : IEntityRepository<Book>
    {
        public void Insert(object a)
        {
            var dbContext = new BookContext();
            dbContext.dbBooks.Add((Book)a);
            dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var dbContext = new BookContext();
            Book book = dbContext.dbBooks.Find(id);
            dbContext.dbBooks.Remove(book);
            dbContext.SaveChanges();
        }

        public List<Book> Load()
        {
            var dbContext = new BookContext();
            List<Book> books = new List<Book>();
            dbContext.dbBooks.Load();

            books = dbContext.dbBooks.Local.ToList();
            return books;
        }

        public object Find(int id)
        {
            var dbContext = new BookContext();
            Book book = dbContext.dbBooks.Find(id);
            return book;
        }
    }
}
