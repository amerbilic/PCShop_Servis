using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Models
{
    public class SmsLog : BaseEntity
    {
        public string Broj { get; set; }
        public string Poruka { get; set; }
        public string DodatniSadrzaj { get; set; }
    }
}
