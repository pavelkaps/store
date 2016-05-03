using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBook
{
   public class Book : Entity
    {

        public string Author { get; set; }
        public int Year { get; set; }
        
        public int BookGenreId { get; set; }
        public virtual BookGenre BookGenre { get; set; }

        public Book()
            : base()
        {
            Author = "N/A";
            Year = 0;
        }

        public Book(int Id, string title, string desc, string Publisher, int Сirculation, string Author, int Year, int Rating)
            : base(Id, title, desc, Publisher, Сirculation, Rating)
        {
            this.Author = Author;
            this.Year = Year;
        }

    }
}
