using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Narudzba : BaseEntity
    {
        public double UkupnaCijena { get; set; }
        public DateTime DatumNarudzbe { get; set; }
        public int Status { get; set; }
        public string Kontakt { get; set; }
        public int KupacId { get; set; }
        public virtual Kupac Kupac { get; set; }
        public int? ZaposlenikId { get; set; }
        public virtual Zaposlenik Zaposlenik { get; set; }

        public virtual System.Collections.Generic.List<StavkaNarudzbe> StavkaNarudzbe { get; set; }

    }
}
