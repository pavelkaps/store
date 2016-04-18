using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBook
{
    class Item
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Publisher { get; set; }
        public string Description { get; set; }
        public int Сirculation { get; set; }

        public Item()
        {
        Id = 0;
        Title = "N/A";
        Publisher = "N/A";
        Description = "N/A";
        Сirculation = 0;
        }

        public Item(int Id, string title, string desc, string Publisher, int Сirculation)
        {
        this.Id = Id;
        this.Title = title;
        this.Publisher = 
        this.Description = desc;
        this.Сirculation = Сirculation;
        }

    }
}
