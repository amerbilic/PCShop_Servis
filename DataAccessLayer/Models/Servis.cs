using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Servis : BaseEntity
    {
        public string Opis { get; set; }
        public double Cijena { get; set; }
        public int StatusServisa { get; set; }
        public DateTime DatumPrijema { get; set; }
        public DateTime DatumZavrsetka { get; set; }
        public int ZaposlenikId { get; set; }
        public virtual Zaposlenik Zaposlenik { get; set; }

        public virtual System.Collections.Generic.List<StavkaServis> StavkaServis { get; set; }

    }
}
