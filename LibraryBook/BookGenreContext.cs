using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace LibraryBook
{
    class BookGenreContext : DbContext
    {
       public BookGenreContext(): base("DbConnection")
            { }

            public DbSet<BookGenre> dbBookgGenre { get; set; }

        }
    
}
