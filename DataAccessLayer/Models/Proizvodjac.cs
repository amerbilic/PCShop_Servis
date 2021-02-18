using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Models
{
    public class Proizvodjac : BaseEntity
    {
        public string Naziv { get; set; }

        public virtual System.Collections.Generic.List<Artikal> Artikli { get; set; }
    }
}
