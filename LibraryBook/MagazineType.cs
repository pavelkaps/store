using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBook
{
    class MagazineType:Type
    {
        public MagazineType(){
            AddOneType("Экономика");
            AddOneType("Наука и техника");
            AddOneType("Недвижимость");
            AddOneType("Авто");
            AddOneType("Туризм");
            AddOneType("Спорт");
            AddOneType("Музыка");
            AddOneType("Кино");
            AddOneType("Мода");
        }
         
    }
}
