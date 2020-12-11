using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BrewApp.Models
{
    public class Keg
    {
        public int KegID { get; set; }

        public string KegNumber { get; set; }

        public string CurrentLocation { get; set; }

        public string PreviousLocation { get; set; }

        public DateTime LastUpdatedAt { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}