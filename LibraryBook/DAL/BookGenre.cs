﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBook
{
    public class BookGenre:Dictionary
    {
        public virtual List<Book> Books { get; set; }
        
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