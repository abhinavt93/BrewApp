using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BrewApp.DTOs
{
    public class OrderBlotterDTO
    {
        public int OrderId { get; set; }
        public int Recipeid { get; set; }
        public string RecipeName { get; set; }
        public double Order_Quantity { get; set; }
        public double Production_Price { get; set; }
        public double Production_Cost { get; set; }
        public double Customer_Price { get; set; }
        public double Customer_Cost { get; set; }
        public double GST { get; set; }
        public double Margin { get; set; }
        public double Trasportation_Cost { get; set; }
        public string Sales_Person { get; set; }
        public string Customer_Restaurant_Details { get; set; }
        public string Remark { get; set; }
        public System.DateTime Created_At { get; set; }
        public string Created_By { get; set; }
    }
}