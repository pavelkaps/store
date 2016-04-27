using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data.Entity;
namespace LibraryBook
{
    class BookGenreRepository:IEntityRepository<BookGenre>
    {
        public void Insert(object a)
        {
            var dbContext = new BookContext();
            dbContext.dbGenre.Add((BookGenre)a);
            dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var dbContext = new BookContext();
            BookGenre book = dbContext.dbGenre.Find(id);
            dbContext.dbGenre.Remove(book);
            dbContext.SaveChanges();
        }

        public BindingList<BookGenre> Load()
        {
            var dbContext = new BookContext();
            BindingList<BookGenre> genre = new BindingList<BookGenre>();
            dbContext.dbGenre.Load();

            genre = dbContext.dbGenre.Local.ToBindingList();
            return genre;
        }

        public object Find(int id)
        {
            var dbContext = new BookContext();
            BookGenre genre = dbContext.dbGenre.Find(id);
            return genre;
        }
    }
}
