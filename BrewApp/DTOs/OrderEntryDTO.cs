using BrewApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BrewApp.DTOs
{
    public class OrderEntryDTO
    {
        [Key]
        [Display(Name = "Order ID")]
        public int id { get; set; }

        [Display(Name = "Recipe")]
        public int Recipeid { get; set; }
        public RecipeMaster RecipeMaster { get; set; }

        public string RecipeName { get; set; }

        [Required]
        [Display(Name = "Order Quantity (L)")]
        public double Order_Quantity { get; set; }

        [Required]
        [Display(Name = "Production Price (Per L)")]
        public double Production_Price { get; set; }

        public double Production_Cost { get; set; }

        public double Customer_Price { get; set; }

        [Required]
        [Display(Name = "Customer Cost")]
        public double Customer_Cost { get; set; }

        [Required]
        [Display(Name = "GST (Any Other Taxes)")]
        public double GST { get; set; }

        [Required]
        [Display(Name = "Margin (%)")]
        public double Margin { get; set; }

        public double Margin_Amount { get; set; }

        [Required]
        [Display(Name = "Transportation Cost")]
        public double Trasportation_Cost { get; set; }

        [Required]
        [Display(Name = "Sales Person")]
        public string Sales_Person { get; set; }

        [Required]
        [Display(Name = "Customer Name")]
        public string Customer_Restaurant_Details { get; set; }

        [Required]
        [Display(Name = "Remark")]
        public string Remark { get; set; }

        [Required]
        [Display(Name = "Total Amount Paid")]
        public double Amount_Paid { get; set; }

        [Required]
        [Display(Name = "Remaining Amount")]
        public double Remaining_Amount { get; set; }

        [Required]
        [Display(Name = "Amount Paid Now")]
        public double Amount_Paid_Now { get; set; }

        [Required]
        [Display(Name = "Is Black")]
        public string IsBlack { get; set; }

        public string Created_By { get; set; }

        public DateTime Created_At { get; set; }
    }
}