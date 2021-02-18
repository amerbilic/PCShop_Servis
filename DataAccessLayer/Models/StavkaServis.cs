using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Models
{
    public class StavkaServis : BaseEntity
    {
        public string Ime { get; set; }
        public double Cijena { get; set; }

        public int ServisId { get; set; }
        public virtual Servis Servis { get; set; }
    }
}
