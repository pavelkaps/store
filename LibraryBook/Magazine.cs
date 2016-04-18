using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBook
{
    class Magazine : Item
    {
        

       public int Edition { get; set; }
       public string MagazineTypes { get; set; }

        public Magazine(): base()
        {
            Edition = 0;
            MagazineTypes = "N/A";
        }

        public Magazine(int Id, string title, string desc, string Publisher, int Сirculation,int Edition, string MagazineTypes)
            : base(Id, title, desc, Publisher, Сirculation)
        {
            this.Edition = Edition;
            this.MagazineTypes = MagazineTypes;
        }
    }
}
