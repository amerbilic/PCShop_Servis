using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccessLayer.Models
{
    public class Kupac : BaseEntity
    {
		public string Ime { get; set; }
		public string Prezime { get; set; }
		public string Email { get; set; }
		public int BrojPokusaja { get; set; }
		public DateTime DatumPokusaja { get; set; }
		public string BrojMobitela { get; set; }
		public int GradId { get; set; }
		public virtual Grad Grad { get; set; }

		public virtual System.Collections.Generic.List<Narudzba> Narudzba { get; set; }
		public virtual ApplicationUser ApplicationUser { get; set; }




	}
}
