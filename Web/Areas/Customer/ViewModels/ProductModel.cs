using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Areas.Customer.ViewModels
{
    public class ProductModel : BaseEntity
    {
        public ArtikalViewModel artikal { get; set; }
    }
}
