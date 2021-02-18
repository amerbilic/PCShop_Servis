using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Dobavljac : BaseEntity
    {
        public string Ime { get; set; }
        public string Broj { get; set; }
        public string Mail { get; set; }


    }
}
