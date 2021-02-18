 using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Areas.Customer.ViewModels
{
    public class IndexViewModel
    {
        public List<ArtikalViewModel> Artikli { get; set; }
        public List<SelectListItem> Proizvodjaci { get; set; }
        public string searchName { get; set; }
        public int ProizvodjacId { get; set; }

    }
}
