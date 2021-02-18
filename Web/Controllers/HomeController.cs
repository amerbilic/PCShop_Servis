using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RepositoryLayer;

namespace PCShop_Servis.Controllers
{
    public class HomeController : Controller

    {
        private MyContext _context;

        public HomeController(MyContext db)
        {
            _context = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult InitDB()
        {
            return RedirectToAction("Index");
        }
  
    }
}
