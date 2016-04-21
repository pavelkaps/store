using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace LibraryBook
{
    class MagazineTypeContext : DbContext
    {
      
            public MagazineTypeContext() : base("DbConnection")
            { }

            public DbSet<MagazineType> DBMagazineType { get; set; }
     }
}
