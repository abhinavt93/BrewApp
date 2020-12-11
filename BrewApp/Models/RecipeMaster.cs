using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BrewApp.Models
{
    public class RecipeMaster
    {
        public int id { get; set; }

        public string RecipeName { get; set; }

        public string Malt { get; set; }

        public string Hops { get; set; }

        public string Yeast { get; set; }

        public double Water { get; set; }

        public double OrangePeels { get; set; }

        public double Coriander { get; set; }

        public double FilterSheets { get; set; }

        public double CleaningChemicals { get; set; }

        public double Iodine { get; set; }

        public double Enzymes { get; set; }
    }
}