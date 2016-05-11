using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace LibraryBook
{
    public class MagazineType:Type
    {
        public string type { get; set; }
        
        public virtual List<Magazine> journals { get; set; }
        public MagazineType()
        {
            journals = new List<Magazine>();
        }
        public override string ToString()
        {
            return type;
        }
        //public MagazineType()
        //{
        //    type = "N/A";
        //}
        //public MagazineType(string _type){
        //    type = _type;
        //}

        public override string GetTYPE()
        {
            return type;
        }
         
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