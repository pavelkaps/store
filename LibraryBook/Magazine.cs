using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBook
{
    class Magazine : Entity
    {
        

       public int Edition { get; set; }
       public List<MagazineType> MagazineTypes { get; set; }

        public Magazine(): base()
        {
            Edition = 0;
            MagazineTypes = new List<MagazineType>() ;
        }

        public Magazine(int Id, string title, string desc, string Publisher, int Сirculation,int Edition)
            : base(Id, title, desc, Publisher, Сirculation)
        {
            this.Edition = Edition;
            this.MagazineTypes = new List<MagazineType>();
        }

        public void AddType(MagazineType a)
        {
            MagazineTypes.Add(a);
        }


    }
}
