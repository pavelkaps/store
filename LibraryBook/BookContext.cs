using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace LibraryBook
{
    class BookContext : DbContext
    {
        public BookContext():base("DbConnection")
        { }
          
        public DbSet<Book> dbBooks { get; set; }
        public DbSet<BookGenre> dbGenre { get; set; }
    }
}
