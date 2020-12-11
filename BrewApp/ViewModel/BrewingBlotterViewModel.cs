using BrewApp.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using PagedList;
using PagedList.Mvc;
using System.ComponentModel;

namespace BrewApp.ViewModel
{
    public class BrewingBlotterViewModel
    {
        public IPagedList<vw_Brewing_Blotter> BrewingBlotter { get; set; }

        [Display(Name = "Ref ID")]
        public string RefID { get; set; }

        [Display(Name = "Records per Page")]
        public int RecordPerPage { get; set; }

        [Display(Name = "Processed YN")]
        public string ProcessedYN { get; set; }

        public BrewingBlotterViewModel()
        {
            RecordPerPage = 10;
        }
    }

    public enum ProcessedYN
    {
        All,
        Y,
        N
    }
}