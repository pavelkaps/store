﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace LibraryBook
{
    public interface IEntityRepository<T>
    {
        void Insert(object a);
        void Delete(int id);
        object Find(int id);
        T Load();
       
    }
}
