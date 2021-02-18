using DataAccessLayer.Models;
using RepositoryLayer;
using ServiceLayer.Classes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceLayer.Classes
{
    public class ArtikalService : IArtikliService
    {
        private IRepository<Artikal> artikalRepository;

        public ArtikalService(IRepository<Artikal> artikalRepository)
        {
            this.artikalRepository = artikalRepository;
        }
        public IEnumerable<Artikal> GetArtikli()
        {
            return artikalRepository.GetAll();
        }

        public Artikal GetArtikal(int id)
        {
            return artikalRepository.Get(id);
        }

        public IEnumerable<Artikal> GetArtikliSorted(int? ProizvodjacId)
        {
            var artikli = artikalRepository.GetAllQueryable();


            if (ProizvodjacId != null && ProizvodjacId != 0)
            {
                artikli = artikli.Where(x => x.ProizvodjacId == ProizvodjacId.Value);
            }
                artikli = artikli.OrderBy(x => x.Cijena);



            return artikli.ToList();
        }


    }
}
