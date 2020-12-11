using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BrewApp.Models
{
    public class OrderEntry
    {
        [Key]
        public int id { get; set; }

        public int Recipeid { get; set; }
        public RecipeMaster RecipeMaster { get; set; }

        public string RecipeName { get; set; }

        public double Order_Quantity { get; set; }

        public double Production_Price { get; set; }

        public double Production_Cost{ get; set; }

        public double Customer_Cost { get; set; }

        public double Customer_Price{ get; set; }

        public double GST { get; set; }

        public double Margin { get; set; }

        public double Margin_Amount { get; set; }

        public double Trasportation_Cost { get; set; }

        public string Sales_Person { get; set; }

        public string Customer_Restaurant_Details { get; set; }

        public string Remark { get; set; }

        public string Created_By { get; set; }

        public DateTime Created_At { get; set; }

        public double Amount_Paid { get; set; }

        public double Remaining_Amount { get; set; }

        public string IsBlack { get; set; }
    }
}