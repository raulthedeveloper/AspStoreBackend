using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AspStoreBackend.Models
{
    public class LocationModel
    {
        public int Id { get; set; }
        public string address { get; set; }
    }

    public class HoursModel
    {
        public int Id { get; set; }
        [ForeignKey("Location")]
        public int LocationId { get; set; }

        public LocationModel Location { get; set; }

        public string Sunday { get; set; } 
        public string Monday { get; set; }
        public string Tuesday { get; set; }
        public string Wednesday { get; set; }   
        public string Thursday { get; set; }
        public string Friday { get; set; }
        public string Saturday { get; set; }
    }
}