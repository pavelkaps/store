using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace LibraryBook
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(): base("DbConnection")
        { }
          
        public DbSet<Magazine> Magazines { get; set; }
        public DbSet<MagazineType> Types { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookGenre> Genres { get; set; }
    }
}
