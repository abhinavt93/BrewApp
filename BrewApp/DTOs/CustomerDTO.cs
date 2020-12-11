using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BrewApp.DTOs
{
    public class CustomerDTO
    {
        public int CustomerID { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string CustomerName { get; set; }

        [Display(Name = "Father's Name")]
        public string FatherName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Mother's Name")]
        public string MotherName { get; set; }

        [Display(Name = "Current Address")]
        public string CurrentAddress { get; set; }

        [Display(Name = "Permanent Address")]
        public string PermanentAddress { get; set; }

        [Required]
        [Display(Name = "Phone No.")]
        public string MobNo { get; set; }

        [Display(Name = "Date of Birth")]
        public DateTime? DOB { get; set; }

        [Display(Name = "Pan Card No")]
        public string PAN { get; set; }

    }
}