using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;
using PagedList.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BrewApp.ViewModel
{
    public class RecipeReportViewModel
    {
        public IPagedList<vw_Recipe_Report> RecipeReport { get; set; }

        [Display(Name = "Records per Page")]
        public int RecordPerPage { get; set; }

        [Display(Name = "Ref ID")]
        public string RefID { get; set; }

        public RecipeReportViewModel()
        {
            RecordPerPage = 10;
        }
    }
}