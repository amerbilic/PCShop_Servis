using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Artikal : BaseEntity
    {
        public string Naziv { get; set; }
        public double Cijena { get; set; }
        public string Opis { get; set; }
        public string KratkiOpis { get; set; }
        public int StanjeNaSkladistu { get; set; }
        public int Sifra { get; set; }
        public string Model { get; set; }
        public bool IsDeleted { get; set; }
        public int? PopustId { get; set; }
        public virtual Popusti Popust { get; set; }
        public int? ProizvodjacId { get; set; }
        public virtual Proizvodjac Prozivodjac { get; set; }

        public virtual System.Collections.Generic.List<StavkaNarudzbe> StavkaNarudzbe { get; set; }

    }
}
