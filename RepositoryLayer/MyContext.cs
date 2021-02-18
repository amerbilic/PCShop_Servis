using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace RepositoryLayer
{
    public class MyContext : IdentityDbContext<ApplicationUser>
    {
        public MyContext (DbContextOptions<MyContext> x) : base(x)
        {

        }

        public DbSet<Administrator> Administratori { get; set; }
        public DbSet<Artikal> Artikal { get; set; }
        public DbSet<ArtikalKategorija> ArtikalKategorija { get; set; }
        public DbSet<Dobavljac> Dobavljac { get; set; }
        public DbSet<Grad> Grad { get; set; }
        public DbSet<Kupac> Kupci { get; set; }
        public DbSet<Narudzba> Narudzba { get; set; }
        public DbSet<StavkaNarudzbe> StavkaNarudzbe { get; set; }
        public DbSet<Popusti> Popusti { get; set; }
        public DbSet<Poruka> Poruke { get; set; }  
        public DbSet<Proizvodjac> Proizvodjac { get; set; }
        public DbSet<SmsLog> SmsLog { get; set; }
        public DbSet<Servis> Servis { get; set; }
        public DbSet<StavkaServis> StavkaServis { get; set; }
        public DbSet<Skladiste> Skladiste { get; set; }
        public DbSet<Zaposlenik> Zaposlenici { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
            // seed initial db with data.
            MyDBInitializer.Make(modelBuilder);
            // add foreign key to aspnetusers table to match our existing users in the db.
            modelBuilder.Entity<Administrator>().HasOne(x => x.ApplicationUser).WithMany(x => x.Administratori);
            modelBuilder.Entity<Zaposlenik>().HasOne(x => x.ApplicationUser).WithMany(x => x.Zaposlenici);
            modelBuilder.Entity<Kupac>().HasOne(x => x.ApplicationUser).WithMany(x => x.Kupci);

        }

    }
}
