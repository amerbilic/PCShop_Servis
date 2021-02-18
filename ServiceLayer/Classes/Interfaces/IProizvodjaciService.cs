using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.Classes.Interfaces
{
    public interface IProizvodjaciService
    {
        IEnumerable<Proizvodjac> GetProizvodjaci();
        Proizvodjac Get(int Id);
    }
}
