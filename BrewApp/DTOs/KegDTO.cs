using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BrewApp.DTOs
{
    public class KegDTO
    {
        public int KegID { get; set; }

        [Required]
        [Display(Name = "Keg No")]
        public string KegNumber { get; set; }

        [Required]
        [Display(Name = "Current Location")]
        public string CurrentLocation { get; set; }

        [Display(Name = "Previous Location")]
        public string PreviousLocation { get; set; }

        [Display(Name = "Last Updated At")]
        public DateTime LastUpdatedAt { get; set; }

        [Display(Name = "Created At")]
        public DateTime CreatedAt { get; set; }
    }
}