using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBook
{
    abstract class Type
    {
        public int Id { get; set; }
        public abstract string GetTYPE();
      }
}
