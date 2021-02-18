using DataAccessLayer.Models;
using RepositoryLayer;
using ServiceLayer.Classes.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.Classes
{
    public class GradoviService : IGradoviService
    {
        private IRepository<Grad> gradRepository;

        public GradoviService(IRepository<Grad> gradRepository)
        {
            this.gradRepository = gradRepository;
        }
        public Grad GetGrad(int id)
        {
            return gradRepository.Get(id);
        }

        public IEnumerable<Grad> GetGradovi()
        {
            return gradRepository.GetAll();
        }
    }
}
