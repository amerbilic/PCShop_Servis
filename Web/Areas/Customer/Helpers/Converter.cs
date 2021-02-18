using DataAccessLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Areas.Customer.Helpers
{
    public class Converter
    {
        public static List<SelectListItem> ConvertToSelectListItem(IEnumerable<Proizvodjac> lista)
        {
            return lista.Select(a => new SelectListItem
            {
                Value = a.Id.ToString(),
                Text = a.Naziv
            }).ToList();
        }

        public static double RoundToTwoDecimal(double d) => Math.Round(d, 2);
    }
}
