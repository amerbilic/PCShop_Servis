using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Identity;

namespace RepositoryLayer
{
    public class MyDBInitializer
    {
        public static void Make(ModelBuilder modelBuilder)
        {
            const string ADMIN_ID = "b4280b6a-0613-4cbd-a9e6-f1701e926e73";
            const string ROLE_ID = ADMIN_ID;
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = ROLE_ID,
                Name = "Administrator",
                NormalizedName = "ADMINISTRATOR"
            });
            modelBuilder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = ADMIN_ID,
                UserName = "myemail@myemail.com",
                NormalizedUserName = "MYEMAIL@MYEMAIL.COM",
                Email = "myemail@myemail.com",
                NormalizedEmail = "MYEMAIL@MYEMAIL.COM",
                EmailConfirmed = true,
                PasswordHash = "AQAAAAEAACcQAAAAEDAD7FKSw7zCwb4DyznFarGng3GlDglgDVw6GddFkgAEUdWj6o7wjnxuFjUEV82TXA==",
                SecurityStamp = "VVPCRDAS3MJWQD5CSW2GWPRADBXEZINA",
                ConcurrencyStamp = "c8554266-b401-4519-9aeb-a9283053fc58"
            });
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = ROLE_ID,
                UserId = ADMIN_ID
            });

            modelBuilder.Entity<Artikal>().HasData(new Artikal
            {
                Id = 1,
                Naziv = "Testni1",
                Opis = "Neki opis koji nesto znaci a zapravo nista ne znaci, samo ovdje da popuni mjesto, 123,321,321,123, ovo je jako dosadno.",
                KratkiOpis = "Ovo je neki malo kraci opis, a takodjer je jako dosadno raditi seedanje DB-a",
                IsDeleted = false,
                StanjeNaSkladistu = 10,
                PopustId = 1,
                Cijena = 1200f,
                ProizvodjacId = 1,
                Model = "Neki glupi model",
                Sifra = 123321
            }, new Artikal
            {
                Id = 2,
                Naziv = "Testni2",
                Opis = "Neki opis koji nesto znaci a zapravo nista ne znaci, samo ovdje da popuni mjesto, 123,321,321,123, ovo je jako dosadno.",
                KratkiOpis = "Ovo je neki malo kraci opis, a takodjer je jako dosadno raditi seedanje DB-a",
                IsDeleted = false,
                StanjeNaSkladistu = 12,
                PopustId = 1,
                Cijena = 1300f,
                ProizvodjacId = 2,
                Model = "Neki glupi model",
                Sifra = 123322
            }, new Artikal
            {
                Id = 3,
                Naziv = "Testni33",
                Opis = "Neki opis koji nesto znaci a zapravo nista ne znaci, samo ovdje da popuni mjesto, 123,321,321,123, ovo je jako dosadno.",
                KratkiOpis = "Ovo je neki malo kraci opis, a takodjer je jako dosadno raditi seedanje DB-a",
                IsDeleted = false,
                StanjeNaSkladistu = 5,
                PopustId = null,
                Cijena = 500f,
                ProizvodjacId = 1,
                Model = "Neki glupi model",
                Sifra = 123324
            }, new Artikal
            {
                Id = 4,
                Naziv = "Testni44",
                Opis = "Neki opis koji nesto znaci a zapravo nista ne znaci, samo ovdje da popuni mjesto, 123,321,321,123, ovo je jako dosadno.",
                KratkiOpis = "Ovo je neki malo kraci opis, a takodjer je jako dosadno raditi seedanje DB-a",
                IsDeleted = false,
                StanjeNaSkladistu = 11,
                PopustId = 1,
                Cijena = 1400f,
                ProizvodjacId = 2,
                Model = "Neki glupi model",
                Sifra = 123355
            }, new Artikal
            {
                Id = 5,
                Naziv = "Testni666",
                Opis = "Neki opis koji nesto znaci a zapravo nista ne znaci, samo ovdje da popuni mjesto, 123,321,321,123, ovo je jako dosadno.",
                KratkiOpis = "Ovo je neki malo kraci opis, a takodjer je jako dosadno raditi seedanje DB-a",
                IsDeleted = false,
                StanjeNaSkladistu = 5,
                PopustId = null,
                Cijena = 1100f,
                ProizvodjacId = 3,
                Model = "Neki glupi model",
                Sifra = 121111
            }, new Artikal
            {
                Id = 6,
                Naziv = "Testni5555",
                Opis = "Neki opis koji nesto znaci a zapravo nista ne znaci, samo ovdje da popuni mjesto, 123,321,321,123, ovo je jako dosadno.",
                KratkiOpis = "Ovo je neki malo kraci opis, a takodjer je jako dosadno raditi seedanje DB-a",
                IsDeleted = false,
                StanjeNaSkladistu = 6,
                PopustId = 1,
                Cijena = 140f,
                ProizvodjacId = 2,
                Model = "Neki glupi model",
                Sifra = 1233215
            }, new Artikal
            {
                Id = 7,
                Naziv = "Testni2333",
                Opis = "Neki opis koji nesto znaci a zapravo nista ne znaci, samo ovdje da popuni mjesto, 123,321,321,123, ovo je jako dosadno.",
                KratkiOpis = "Ovo je neki malo kraci opis, a takodjer je jako dosadno raditi seedanje DB-a",
                IsDeleted = false,
                StanjeNaSkladistu = 7,
                PopustId = 1,
                Cijena = 4760f,
                ProizvodjacId = 4,
                Model = "Neki glupi model",
                Sifra = 321455
            }, new Artikal
            {
                Id = 8,
                Naziv = "Testni278",
                Opis = "Neki opis koji nesto znaci a zapravo nista ne znaci, samo ovdje da popuni mjesto, 123,321,321,123, ovo je jako dosadno.",
                KratkiOpis = "Ovo je neki malo kraci opis, a takodjer je jako dosadno raditi seedanje DB-a",
                IsDeleted = false,
                StanjeNaSkladistu = 7,
                PopustId = null,
                Cijena = 140f,
                ProizvodjacId = 7,
                Model = "Neki glupi model",
                Sifra = 898123
            }, new Artikal
            {
                Id = 9,
                Naziv = "Testni2asd",
                Opis = "Neki opis koji nesto znaci a zapravo nista ne znaci, samo ovdje da popuni mjesto, 123,321,321,123, ovo je jako dosadno.",
                KratkiOpis = "Ovo je neki malo kraci opis, a takodjer je jako dosadno raditi seedanje DB-a",
                IsDeleted = false,
                StanjeNaSkladistu = 9,
                PopustId = 1,
                Cijena = 1880f,
                ProizvodjacId = 4,
                Model = "Neki glupi model",
                Sifra = 8876812
            }, new Artikal
            {
                Id = 10,
                Naziv = "Testni2fgfgw",
                Opis = "Neki opis koji nesto znaci a zapravo nista ne znaci, samo ovdje da popuni mjesto, 123,321,321,123, ovo je jako dosadno.",
                KratkiOpis = "Ovo je neki malo kraci opis, a takodjer je jako dosadno raditi seedanje DB-a",
                IsDeleted = false,
                StanjeNaSkladistu = 32,
                PopustId = 1,
                Cijena = 444f,
                ProizvodjacId = 5,
                Model = "Neki glupi model",
                Sifra = 987754
            });

            modelBuilder.Entity<Administrator>().HasData(new Administrator { Id = 1, Email = "admin@admin.com", Ime = "admin", IsSuperAdmin = true, Prezime = "admin" });
            modelBuilder.Entity<Dobavljac>().HasData(new Dobavljac { Id = 1, Ime = "Nvidia", Broj = "061234132", Mail = "dobavljac@dobavljac.com" });
            modelBuilder.Entity<Grad>().HasData(new Grad { Id = 1, Ime = "Mostar"}, new Grad { Id = 2,  Ime = "Sarajevo"});
            modelBuilder.Entity<Proizvodjac>().HasData(new Proizvodjac { Id = 1, Naziv = "Nvidia" }, new Proizvodjac { Id = 2, Naziv = "Apple" }, new Proizvodjac { Id = 3, Naziv = "Sapphire" }
           , new Proizvodjac { Id = 4, Naziv = "Intel" }, new Proizvodjac { Id = 5, Naziv = "AMD" }, new Proizvodjac { Id = 6, Naziv = "Nekilijevi1" }, new Proizvodjac { Id = 7, Naziv = "Nepadaminapamet" }, new Proizvodjac { Id = 8, Naziv = "Nistanovo" });
            modelBuilder.Entity<Popusti>().HasData(new Popusti { DatumOd = DateTime.Now, DatumDo = DateTime.Now, Id = 1, Popust = 0.10f });
            modelBuilder.Entity<Kupac>().HasData(new Kupac { Id = 1, Email = "kupac@kupac.com", BrojMobitela = "061545545", Ime = "kupac", Prezime = "kupicic", BrojPokusaja = 0, DatumPokusaja = DateTime.Now, GradId = 1 });
            modelBuilder.Entity<Zaposlenik>().HasData(new Zaposlenik { Id = 1, isDeleted = false, Ime = "Zaposlenik", Prezime = "Zaposlenkic", Email = "Zaposlenik@zaposlenik.com", GradId = 1, Ulica = "Nekaulica" });

        }
    }
}