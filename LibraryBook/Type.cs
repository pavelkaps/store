using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBook
{
    abstract class Type
    {
        private List<String> TypeList = new List<string>();

        public void AddOneType(string _type) { TypeList.Add(_type); }
        
    }
}
