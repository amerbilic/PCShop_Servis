using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.Classes.Interfaces
{
    public interface IGradoviService
    {
        IEnumerable<Grad> GetGradovi();
        Grad GetGrad(int id);
    }
}
