using BrewApp.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BrewApp.ViewModel
{
    public class KegViewModel
    {

        public KegDTO Keg { get; set; }

        public IEnumerable<CustomerDTO> Customers { get; set; }

    }
}