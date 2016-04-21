using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace LibraryBook
{
    class MagazineContext: DbContext
    {
        public MagazineContext(): base("DbConnection")
        { }
          
        public DbSet<Magazine> dbJournals { get; set; }

    }
}
