using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.Classes.Interfaces
{
    public interface IArtikliService
    {
        IEnumerable<Artikal> GetArtikli();
        IEnumerable<Artikal> GetArtikliSorted( int? ProizvodjacId);
        Artikal GetArtikal(int id);
    }
}
