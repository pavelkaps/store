using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBook
{
    class Book : Entity
    {

        public string Author { get; set; }
        public int Year { get; set; }
        public List<BookGenre> Genre { get; set; }

        public Book()
            : base()
        {
            Author = "N/A";
            Year = 0;
            Genre = new List<BookGenre>(); ;
        }

        public Book(int Id, string title, string desc, string Publisher, int Сirculation, string Author, int Year)
            : base(Id, title, desc, Publisher, Сirculation)
        {
            this.Author = Author;
            this.Year = Year;
            this.Genre = new List<BookGenre>();

        }

        public void AddType(BookGenre a)
        {
            Genre.Add(a);
        }
    }
}
