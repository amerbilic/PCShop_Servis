using Castle.Core.Internal;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Classes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Areas.Customer.Helpers;
using Web.Areas.Customer.ViewModels;

namespace Web.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class CustomerController : Controller
    {
        public IArtikliService ArtikliService { get; }
        public IProizvodjaciService ProizvodjaciService { get; }
        public UserManager<ApplicationUser> UserManager { get; }

        public CustomerController(IArtikliService artikliService, IProizvodjaciService proizvodjaciService, UserManager<ApplicationUser> userManager)
        {
            ArtikliService = artikliService;
            ProizvodjaciService = proizvodjaciService;
            UserManager = userManager;
        }



        public IActionResult Index(IndexViewModel model)
        {
            model.Proizvodjaci = Converter.ConvertToSelectListItem(ProizvodjaciService.GetProizvodjaci());

            List<Artikal> list = ArtikliService.GetArtikliSorted(model.ProizvodjacId).ToList();
            List<ArtikalViewModel> artiklilist = new List<ArtikalViewModel>();
            foreach (var artikal in list)
            {
                ArtikalViewModel ne = new ArtikalViewModel();
                artikal.Cijena = artikal.Cijena;
                    ne.Id = artikal.Id;
                    ne.Naziv = artikal.Naziv;
                    ne.Popust = artikal.PopustId != null;
                    ne.Cijena = Converter.RoundToTwoDecimal(artikal.Cijena);
                    ne.StanjeNaSkladistu = artikal.StanjeNaSkladistu;
                    ne.Opis = artikal.Opis;
                    ne.KratkiOpis = artikal.KratkiOpis;
                    ne.Proizvodjac = artikal.Prozivodjac.Naziv;

                artiklilist.Add(ne); 
            }

            model.Artikli = artiklilist;
            return View(model);
        }
    }
}
