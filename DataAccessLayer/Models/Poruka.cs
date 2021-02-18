using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Models
{
    public class Poruka : BaseEntity
    {
		public string Tema { get; set; }
		public string Sadrzaj { get; set; }
		public DateTime DatumSlanja { get; set; }
		public Boolean Procitano { get; set; }
		public int AdministratorId { get; set; }
		public virtual Administrator Administrator { get; set; }
		public int ZaposlenikId { get; set; }
		public virtual Zaposlenik Zaposlenik { get; set; }
	}
}
