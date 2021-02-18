using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Models
{
    public class ApplicationUser : IdentityUser
    {
        public virtual ICollection<Administrator> Administratori { get; set; }
        public virtual ICollection<Kupac> Kupci { get; set; }
        public virtual ICollection<Zaposlenik> Zaposlenici { get; set; }
    }
}
