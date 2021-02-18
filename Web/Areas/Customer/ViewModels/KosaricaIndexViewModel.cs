using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Areas.Customer.ViewModels
{
    public class KosaricaIndexViewModel
    {
        public List<Item> Items { get; set; }
        public double TotalPrice { get; set; }
    }
}
