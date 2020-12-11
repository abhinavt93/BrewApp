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
    public class WorkflowViewModel
    {
        public IPagedList<vw_Order_Blotter> OrderBlotter { get; set; }

        public IPagedList<vw_Brewing_Blotter> BrewingBlotter { get; set; }

        public Blotter Blotter { get; set; }

        [Display(Name = "Ref ID")]
        public string RefID { get; set; }

        [Display(Name = "Records per Page")]
        public int RecordPerPage { get; set; }

        [Display(Name = "Processed YN")]
        public string ProcessedYN { get; set; }

        public WorkflowViewModel()
        {
            RecordPerPage = 10;
            Blotter = Blotter.Order;
        }
    }

    public enum Blotter
    {
        Order,
        Brewing
    }
}