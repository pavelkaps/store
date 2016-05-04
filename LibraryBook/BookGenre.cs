using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBook
{
    public class BookGenre:Type
    {

        public string Genre { get; set; }
         
        public virtual List<Book> Books { get; set; }
        
        public override string GetTYPE()
        {
            return Genre;
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