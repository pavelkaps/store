﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBook
{
    public class Magazine : Entity
    {
        

       public int Edition { get; set; }
       public int MagazineTypeId { get; set; }
       public virtual MagazineType MagazineType { get; set; }
        

        public Magazine(): base()
        {
            Edition = 0;
        }

        public Magazine(int Id, string title, string desc, string Publisher, int Сirculation,int Edition, int Rating)
            : base(Id, title, desc, Publisher, Сirculation, Rating)
        {
            this.Edition = Edition;
        }



    }
}
