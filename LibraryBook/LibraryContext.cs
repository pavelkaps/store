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
          
        public DbSet<Magazine> dbJournals { get; set; }
        public DbSet<MagazineType> dbType { get; set; }
        public DbSet<Book> dbBooks { get; set; }
        public DbSet<BookGenre> dbGenre { get; set; }
    }
}
