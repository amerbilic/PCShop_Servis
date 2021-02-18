using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Skladiste : BaseEntity
    {
        public string Naziv { get; set; }
        public string Kapacitet { get; set; }
        public string Opis { get; set; }

    }
}
