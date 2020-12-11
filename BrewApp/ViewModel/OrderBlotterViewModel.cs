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
    public class OrderBlotterViewModel
    {
        public IPagedList<vw_Order_Blotter> OrderBlotter { get; set; }

        public IPagedList<vw_Brewing_Blotter> BrewingBlotter { get; set; }

        public Blotter Blotter { get; set; }

        [Display(Name = "Ref ID")]
        public string RefID { get; set; }

        [Display(Name = "Payment Status")]
        public string PaymentStatus { get; set; }

        [Display(Name = "Records per Page")]
        public int RecordPerPage { get; set; }

        public OrderBlotterViewModel()
        {
            RecordPerPage = 10;
            //Blotter = Blotter.Order;
        }
    }

    public enum PaymentStatus
    {
        All,
        Pending,
        Complete
    }

    //public enum Blotter
    //{
    //    Order,
    //    Brewing
    //}
}