using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace LibraryBook
{
    public class MagazineType:Dictionary
    {
        public virtual List<Magazine> Magazines { get; set; }
     }
}

 //AddOneType("Экономика");
 //           AddOneType("Наука и техника");
 //           AddOneType("Недвижимость");
 //           AddOneType("Авто");
 //           AddOneType("Туризм");
 //           AddOneType("Спорт");
 //           AddOneType("Музыка");
 //           AddOneType("Кино");
 //           AddOneType("Мода");