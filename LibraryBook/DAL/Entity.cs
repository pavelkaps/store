using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBook
{
    public class Entity 
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Publisher { get; set; }
        public string Description { get; set; }
        public int Сirculation { get; set; }
        public int Rating {get; set;}
        public bool Availability { get; set; }
        public string AvailabilityToString { get; set; }

        public Entity()
        {
        Id = 0;
        Title = "N/A";
        Publisher = "N/A";
        Description = "N/A";
        Сirculation = 0;
        Rating = 0;
        Availability = false;
        SetAvailability();
        }

        public Entity(int Id, string title, string desc, string Publisher, int Сirculation, int Rating)
        {
        this.Id = Id;
        this.Title = title;
        this.Publisher = 
        this.Description = desc;
        this.Сirculation = Сirculation;
        this.Rating = Rating;
        }

        public void SetAvailability()
        {
            if (Availability == true) { AvailabilityToString = "В наличии"; } else { AvailabilityToString = "-"; }

        }
        

    }
}
