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
    public class StockReportViewModel
    {
        public IPagedList<vw_Stock_Report> StockReport { get; set; }

        [Display(Name = "Records per Page")]
        public int RecordPerPage { get; set; }

        [Display(Name = "Ref ID")]
        public string RefID { get; set; }

        public StockReportViewModel()
        {
            RecordPerPage = 10;
        }
    }
}