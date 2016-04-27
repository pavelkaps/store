using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBook
{
    class BookGenre:Type
    {

         public string genre { get; set; }

         public ICollection<Book> books { get; set; }
         public BookGenre()
         {
         books = new List<Book>();
         }
        //public BookGenre()
        //{
        //    genre = "N/A";
        //}
        //public BookGenre(string _genre)
        //{
        //    genre = _genre;
        //}

        public override string GetTYPE()
        {
            return genre;
        }
    }
}

//AddOneType("Вестерн");
//AddOneType("Драма");
//AddOneType("Исторический");
//AddOneType("Роман");
//AddOneType("Поэма");
//AddOneType("Приключения");
//AddOneType("Триллер");
//AddOneType("Ужасы");
//AddOneType("Фэнтези");