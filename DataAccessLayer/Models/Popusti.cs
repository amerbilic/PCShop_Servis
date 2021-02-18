using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Models
{
    public class Popusti : BaseEntity
    {
        public DateTime DatumDo { get; set; }
        public DateTime DatumOd { get; set; }
        public float Popust { get; set; }
        public List<Artikal> Artikal { get; set; }
    }
}
