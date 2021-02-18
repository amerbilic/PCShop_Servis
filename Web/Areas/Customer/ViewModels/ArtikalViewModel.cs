using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Areas.Customer.Helpers;

namespace Web.Areas.Customer.ViewModels
{
    public class ArtikalViewModel
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public double Cijena { get; set; }
        public string Opis { get; set; }
        public string KratkiOpis { get; set; }
        public int StanjeNaSkladistu { get; set; }
        public int Sifra { get; set; }
        public string Model { get; set; }
        public bool Popust { get; set; }
        public string  Proizvodjac { get; set; }

        public static ArtikalViewModel ConvertToArtikalViewModel(Artikal x)
        {
            // cijena je sa popustom ako je popust true. 
            return new ArtikalViewModel
            {
                Id = x.Id,
                Naziv = x.Naziv,
                Popust = x.PopustId != null,
                Cijena = Converter.RoundToTwoDecimal(x.Cijena),
                StanjeNaSkladistu = x.StanjeNaSkladistu,
                Opis = x.Opis,
                KratkiOpis = x.KratkiOpis,
                Proizvodjac = x.Prozivodjac.Naziv

            };
        }
    }
}
