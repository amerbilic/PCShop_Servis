using DataAccessLayer.Models;
using RepositoryLayer;
using ServiceLayer.Classes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceLayer.Classes
{
    public class KupacService : IKupacService
    {
        private IRepository<Kupac> kupacRepository;

        public KupacService(IRepository<Kupac> kupacRepository)
        {
            this.kupacRepository = kupacRepository;
        }

        public Kupac GetKupac(int id)
        {
            return kupacRepository.Get(id);
        }

        public int GetKupacByAspUserId(string userId)
        {
            return kupacRepository.GetAllQueryable().FirstOrDefault(x => x.ApplicationUser.Id == userId)?.Id ?? 0;
        }

        public IEnumerable<Kupac> GetKupci()
        {
            return kupacRepository.GetAll();
        }

        public void InsertKupac(Kupac kupac)
        {
            kupacRepository.Insert(kupac);
        }
    }
}
