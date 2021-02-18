using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Models
{
    public class StavkaNarudzbe : BaseEntity
    {
        public double Cijena { get; set; }
        public int Kolicina { get; set; }
        public int ArtikalId { get; set; }
        public virtual Artikal Artikal { get; set; }
        public int NarudzbaId { get; set; }
        public virtual Narudzba Narudzba { get; set; }

    }
}
