using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Grad : BaseEntity
    {
        public string Ime { get; set; }

        public virtual System.Collections.Generic.List<Narudzba> Narudzba { get; set; }
        public virtual System.Collections.Generic.List<Zaposlenik> Zaposlenik { get; set; }
        public virtual System.Collections.Generic.List<Kupac> Kupac { get; set; }
    }
}
