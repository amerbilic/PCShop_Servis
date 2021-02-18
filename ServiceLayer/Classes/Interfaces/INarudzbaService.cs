using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.Classes.Interfaces
{
    public interface INarudzbaService
    {
        List<Narudzba> GetNarudzbe (string userId);
        void InsertNarudzba (Narudzba narudzba, List<StavkaNarudzbe> stavke);
    }
}
