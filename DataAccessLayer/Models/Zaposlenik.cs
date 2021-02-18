using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Models
{
    public class Zaposlenik : BaseEntity
    {
		public string Ime { get; set; }
		public string Prezime { get; set; }
		public string Ulica { get; set; }
		public string Email { get; set; }
		public bool isDeleted { get; set; }
		public int GradId { get; set; }
		public virtual Grad Grad { get; set; }
		public virtual ApplicationUser ApplicationUser { get; set; }

		public virtual System.Collections.Generic.List<Servis> Servis { get; set; }
		public virtual System.Collections.Generic.List<Narudzba> Narudzba { get; set; }
		public virtual System.Collections.Generic.List<Poruka> Poruka { get; set; }
	}
}
