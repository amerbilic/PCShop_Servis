using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.Classes.Interfaces
{
    public interface IKupacService
    {
        IEnumerable<Kupac> GetKupci();
        Kupac GetKupac(int id);

        void InsertKupac(Kupac kupac);
        int GetKupacByAspUserId(string userId);
    }
}
