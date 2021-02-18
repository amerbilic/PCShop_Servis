using DataAccessLayer.Models;
using RepositoryLayer;
using ServiceLayer.Classes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceLayer.Classes
{
    public class ProizvodjaciService : IProizvodjaciService
    {
        private IRepository<Proizvodjac> proizvodjacRepository;

        public ProizvodjaciService(IRepository<Proizvodjac> gradRepository)
        {
            this.proizvodjacRepository = gradRepository;
        }
        public Proizvodjac Get(int id)
        {
            return proizvodjacRepository.Get(id);
        }

        public IEnumerable<Proizvodjac> GetProizvodjaci()
        {
            return proizvodjacRepository.GetAllQueryable().OrderBy(x => x.Naziv).ToList();
        }
    }
}

