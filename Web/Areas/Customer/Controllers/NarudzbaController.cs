using DataAccessLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ServiceLayer.Classes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vonage.Messaging;
using Vonage.Request;
using Web.Areas.Customer.Helpers;
using Web.Areas.Customer.ViewModels;

namespace Web.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class NarudzbaController : Controller
    {
        private static readonly string CartName = "cart";
        public IArtikliService ArtikliService;
        public INarudzbaService NarudzbaService;
        public UserManager<ApplicationUser> UserManager;
        public IKupacService KupacService;
        private readonly IProizvodjaciService proizvodjaciService;
        public IConfiguration Configuration { get; set; }
        public NarudzbaController(IArtikliService artikliService,INarudzbaService narudzbaService,UserManager<ApplicationUser> userManager,IKupacService kupacService, IProizvodjaciService proizvodjaciService, IConfiguration Configuration)
        {
            this.ArtikliService = artikliService;
            this.NarudzbaService = narudzbaService;
            this.UserManager = userManager;
            this.KupacService = kupacService;
            this.proizvodjaciService = proizvodjaciService;
            this.Configuration = Configuration;
        }

        public IActionResult Index()
        {
            var model = ArtikliService.GetArtikal(1);
            NarudzbaViewModel returnModel = new NarudzbaViewModel();
            
      PopulateModel(ref returnModel);
            return View(returnModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(NarudzbaViewModel model)
        {
            NarudzbaViewModel returnModel = new NarudzbaViewModel();
            PopulateModel(ref returnModel);

            if (!ModelState.IsValid)
            {

                return View(returnModel);
            }


            Narudzba narudzba = new Narudzba
            {
                DatumNarudzbe = DateTime.UtcNow,
                Kontakt = model.KontaktTelefon,
                UkupnaCijena = returnModel.Detalji.TotalPrice,
                Status = 1,
                KupacId = KupacService.GetKupacByAspUserId(UserManager.GetUserId(HttpContext.User))

            };

            List<StavkaNarudzbe> listaStavki = new List<StavkaNarudzbe>();
            foreach (var item in returnModel.Detalji.Items)
            {
                var stavka = new StavkaNarudzbe
                {
                    ArtikalId = item.Product.Id,
                    Kolicina = item.Quantity,
                    Cijena = item.Product.artikal.Cijena
                };
                listaStavki.Add(stavka);
            }


            NarudzbaService.InsertNarudzba(narudzba, listaStavki);
            var VONAGE_API_KEY = Configuration["VONAGE_API_KEY"];
            var VONAGE_API_SECRET = Configuration["VONAGE_API_SECRET"];
            var credentials = Credentials.FromApiKeyAndSecret(VONAGE_API_KEY, VONAGE_API_SECRET);
            var client = new SmsClient(credentials);
            var request = new SendSmsRequest { To = model.KontaktTelefon, From = model.KontaktTelefon, Text = "Uspjesno ste narucili artikal!" };
            var response = client.SendAnSms(request);
            ViewBag.MessageId = response.Messages[0].MessageId;

            // Delete sve iz kosarice nakon uspjesne narudzbe
            List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, CartName);
            cart.RemoveAll(x => x.Quantity > 0);
            SessionHelper.SetObjectAsJson(HttpContext.Session, CartName, cart);




            return View("NarudzbaConfirmation");
        }


        private void PopulateModel(ref NarudzbaViewModel returnModel)
        {
            KosaricaIndexViewModel model = new KosaricaIndexViewModel();
            model.TotalPrice = 0;
            List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, CartName);

            // get all of the data for display view and calculate the total price of the article
            foreach (var item in cart)
            {
                var artikal = ArtikliService.GetArtikal(item.Product.Id);
                var proizvodjac = proizvodjaciService.Get(artikal.ProizvodjacId.Value);
                ArtikalViewModel artik = new ArtikalViewModel
                {
                    Id = artikal.Id,
                    Naziv = artikal.Naziv,
                    Popust = artikal.PopustId != null,
                    Cijena = Converter.RoundToTwoDecimal(artikal.Cijena),
                    StanjeNaSkladistu = artikal.StanjeNaSkladistu,
                    Opis = artikal.Opis,
                    KratkiOpis = artikal.KratkiOpis,
                    Proizvodjac = proizvodjac.Naziv
                };
                item.Product.artikal = artik;
                model.TotalPrice += Converter.RoundToTwoDecimal(item.Product.artikal.Cijena * item.Quantity);
            }
            model.Items = cart;

            returnModel.Detalji = model;
        }
    }
}
