using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RepositoryLayer.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ArtikalKategorija",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtikalKategorija", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dobavljac",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(nullable: true),
                    Broj = table.Column<string>(nullable: true),
                    Mail = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dobavljac", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Grad",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grad", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Popusti",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DatumDo = table.Column<DateTime>(nullable: false),
                    DatumOd = table.Column<DateTime>(nullable: false),
                    Popust = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Popusti", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Proizvodjac",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proizvodjac", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Skladiste",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true),
                    Kapacitet = table.Column<string>(nullable: true),
                    Opis = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skladiste", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SmsLog",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Broj = table.Column<string>(nullable: true),
                    Poruka = table.Column<string>(nullable: true),
                    DodatniSadrzaj = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SmsLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Administratori",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(nullable: true),
                    IsSuperAdmin = table.Column<bool>(nullable: false),
                    Ime = table.Column<string>(nullable: true),
                    Prezime = table.Column<string>(nullable: true),
                    ApplicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administratori", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Administratori_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Kupci",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(nullable: true),
                    Prezime = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    BrojPokusaja = table.Column<int>(nullable: false),
                    DatumPokusaja = table.Column<DateTime>(nullable: false),
                    BrojMobitela = table.Column<string>(nullable: true),
                    GradId = table.Column<int>(nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kupci", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kupci_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Kupci_Grad_GradId",
                        column: x => x.GradId,
                        principalTable: "Grad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Zaposlenici",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(nullable: true),
                    Prezime = table.Column<string>(nullable: true),
                    Ulica = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    isDeleted = table.Column<bool>(nullable: false),
                    GradId = table.Column<int>(nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zaposlenici", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Zaposlenici_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Zaposlenici_Grad_GradId",
                        column: x => x.GradId,
                        principalTable: "Grad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Artikal",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true),
                    Cijena = table.Column<double>(nullable: false),
                    Opis = table.Column<string>(nullable: true),
                    KratkiOpis = table.Column<string>(nullable: true),
                    StanjeNaSkladistu = table.Column<int>(nullable: false),
                    Sifra = table.Column<int>(nullable: false),
                    Model = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    PopustId = table.Column<int>(nullable: true),
                    ProizvodjacId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artikal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Artikal_Popusti_PopustId",
                        column: x => x.PopustId,
                        principalTable: "Popusti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Artikal_Proizvodjac_ProizvodjacId",
                        column: x => x.ProizvodjacId,
                        principalTable: "Proizvodjac",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Narudzba",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UkupnaCijena = table.Column<double>(nullable: false),
                    DatumNarudzbe = table.Column<DateTime>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Kontakt = table.Column<string>(nullable: true),
                    KupacId = table.Column<int>(nullable: false),
                    ZaposlenikId = table.Column<int>(nullable: false),
                    GradId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Narudzba", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Narudzba_Grad_GradId",
                        column: x => x.GradId,
                        principalTable: "Grad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Narudzba_Kupci_KupacId",
                        column: x => x.KupacId,
                        principalTable: "Kupci",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Narudzba_Zaposlenici_ZaposlenikId",
                        column: x => x.ZaposlenikId,
                        principalTable: "Zaposlenici",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Poruke",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tema = table.Column<string>(nullable: true),
                    Sadrzaj = table.Column<string>(nullable: true),
                    DatumSlanja = table.Column<DateTime>(nullable: false),
                    Procitano = table.Column<bool>(nullable: false),
                    AdministratorId = table.Column<int>(nullable: false),
                    ZaposlenikId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Poruke", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Poruke_Administratori_AdministratorId",
                        column: x => x.AdministratorId,
                        principalTable: "Administratori",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Poruke_Zaposlenici_ZaposlenikId",
                        column: x => x.ZaposlenikId,
                        principalTable: "Zaposlenici",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Servis",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Opis = table.Column<string>(nullable: true),
                    Cijena = table.Column<double>(nullable: false),
                    StatusServisa = table.Column<int>(nullable: false),
                    DatumPrijema = table.Column<DateTime>(nullable: false),
                    DatumZavrsetka = table.Column<DateTime>(nullable: false),
                    ZaposlenikId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Servis_Zaposlenici_ZaposlenikId",
                        column: x => x.ZaposlenikId,
                        principalTable: "Zaposlenici",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StavkaNarudzbe",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cijena = table.Column<double>(nullable: false),
                    Kolicina = table.Column<int>(nullable: false),
                    ArtikalId = table.Column<int>(nullable: false),
                    NarudzbaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StavkaNarudzbe", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StavkaNarudzbe_Artikal_ArtikalId",
                        column: x => x.ArtikalId,
                        principalTable: "Artikal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StavkaNarudzbe_Narudzba_NarudzbaId",
                        column: x => x.NarudzbaId,
                        principalTable: "Narudzba",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StavkaServis",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(nullable: true),
                    Cijena = table.Column<double>(nullable: false),
                    ServisId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StavkaServis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StavkaServis_Servis_ServisId",
                        column: x => x.ServisId,
                        principalTable: "Servis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Administratori",
                columns: new[] { "Id", "ApplicationUserId", "Email", "Ime", "IsSuperAdmin", "Prezime" },
                values: new object[] { 1, null, "admin@admin.com", "admin", true, "admin" });

            migrationBuilder.InsertData(
                table: "Dobavljac",
                columns: new[] { "Id", "Broj", "Ime", "Mail" },
                values: new object[] { 1, "061234132", "Nvidia", "dobavljac@dobavljac.com" });

            migrationBuilder.InsertData(
                table: "Grad",
                columns: new[] { "Id", "Ime" },
                values: new object[,]
                {
                    { 1, "Mostar" },
                    { 2, "Sarajevo" }
                });

            migrationBuilder.InsertData(
                table: "Popusti",
                columns: new[] { "Id", "DatumDo", "DatumOd", "Popust" },
                values: new object[] { 1, new DateTime(2021, 2, 17, 17, 56, 35, 487, DateTimeKind.Local).AddTicks(4953), new DateTime(2021, 2, 17, 17, 56, 35, 485, DateTimeKind.Local).AddTicks(336), 0.1f });

            migrationBuilder.InsertData(
                table: "Proizvodjac",
                columns: new[] { "Id", "Naziv" },
                values: new object[,]
                {
                    { 1, "Nvidia" },
                    { 2, "Apple" },
                    { 3, "Sapphire" },
                    { 4, "Intel" },
                    { 5, "AMD" },
                    { 6, "Nekilijevi1" },
                    { 7, "Nepadaminapamet" },
                    { 8, "Nistanovo" }
                });

            migrationBuilder.InsertData(
                table: "Artikal",
                columns: new[] { "Id", "Cijena", "IsDeleted", "KratkiOpis", "Model", "Naziv", "Opis", "PopustId", "ProizvodjacId", "Sifra", "StanjeNaSkladistu" },
                values: new object[,]
                {
                    { 1, 1200.0, false, "Ovo je neki malo kraci opis, a takodjer je jako dosadno raditi seedanje DB-a", "Neki glupi model", "Testni1", "Neki opis koji nesto znaci a zapravo nista ne znaci, samo ovdje da popuni mjesto, 123,321,321,123, ovo je jako dosadno.", 1, 1, 123321, 10 },
                    { 3, 500.0, false, "Ovo je neki malo kraci opis, a takodjer je jako dosadno raditi seedanje DB-a", "Neki glupi model", "Testni33", "Neki opis koji nesto znaci a zapravo nista ne znaci, samo ovdje da popuni mjesto, 123,321,321,123, ovo je jako dosadno.", null, 1, 123324, 5 },
                    { 2, 1300.0, false, "Ovo je neki malo kraci opis, a takodjer je jako dosadno raditi seedanje DB-a", "Neki glupi model", "Testni2", "Neki opis koji nesto znaci a zapravo nista ne znaci, samo ovdje da popuni mjesto, 123,321,321,123, ovo je jako dosadno.", 1, 2, 123322, 12 },
                    { 4, 1400.0, false, "Ovo je neki malo kraci opis, a takodjer je jako dosadno raditi seedanje DB-a", "Neki glupi model", "Testni44", "Neki opis koji nesto znaci a zapravo nista ne znaci, samo ovdje da popuni mjesto, 123,321,321,123, ovo je jako dosadno.", 1, 2, 123355, 11 },
                    { 6, 140.0, false, "Ovo je neki malo kraci opis, a takodjer je jako dosadno raditi seedanje DB-a", "Neki glupi model", "Testni5555", "Neki opis koji nesto znaci a zapravo nista ne znaci, samo ovdje da popuni mjesto, 123,321,321,123, ovo je jako dosadno.", 1, 2, 1233215, 6 },
                    { 5, 1100.0, false, "Ovo je neki malo kraci opis, a takodjer je jako dosadno raditi seedanje DB-a", "Neki glupi model", "Testni666", "Neki opis koji nesto znaci a zapravo nista ne znaci, samo ovdje da popuni mjesto, 123,321,321,123, ovo je jako dosadno.", null, 3, 121111, 5 },
                    { 7, 4760.0, false, "Ovo je neki malo kraci opis, a takodjer je jako dosadno raditi seedanje DB-a", "Neki glupi model", "Testni2333", "Neki opis koji nesto znaci a zapravo nista ne znaci, samo ovdje da popuni mjesto, 123,321,321,123, ovo je jako dosadno.", 1, 4, 321455, 7 },
                    { 9, 1880.0, false, "Ovo je neki malo kraci opis, a takodjer je jako dosadno raditi seedanje DB-a", "Neki glupi model", "Testni2asd", "Neki opis koji nesto znaci a zapravo nista ne znaci, samo ovdje da popuni mjesto, 123,321,321,123, ovo je jako dosadno.", 1, 4, 8876812, 9 },
                    { 10, 444.0, false, "Ovo je neki malo kraci opis, a takodjer je jako dosadno raditi seedanje DB-a", "Neki glupi model", "Testni2fgfgw", "Neki opis koji nesto znaci a zapravo nista ne znaci, samo ovdje da popuni mjesto, 123,321,321,123, ovo je jako dosadno.", 1, 5, 987754, 32 },
                    { 8, 140.0, false, "Ovo je neki malo kraci opis, a takodjer je jako dosadno raditi seedanje DB-a", "Neki glupi model", "Testni278", "Neki opis koji nesto znaci a zapravo nista ne znaci, samo ovdje da popuni mjesto, 123,321,321,123, ovo je jako dosadno.", null, 7, 898123, 7 }
                });

            migrationBuilder.InsertData(
                table: "Kupci",
                columns: new[] { "Id", "ApplicationUserId", "BrojMobitela", "BrojPokusaja", "DatumPokusaja", "Email", "GradId", "Ime", "Prezime" },
                values: new object[] { 1, null, "061545545", 0, new DateTime(2021, 2, 17, 17, 56, 35, 487, DateTimeKind.Local).AddTicks(7871), "kupac@kupac.com", 1, "kupac", "kupicic" });

            migrationBuilder.InsertData(
                table: "Zaposlenici",
                columns: new[] { "Id", "ApplicationUserId", "Email", "GradId", "Ime", "Prezime", "Ulica", "isDeleted" },
                values: new object[] { 1, null, "Zaposlenik@zaposlenik.com", 1, "Zaposlenik", "Zaposlenkic", "Nekaulica", false });

            migrationBuilder.CreateIndex(
                name: "IX_Administratori_ApplicationUserId",
                table: "Administratori",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Artikal_PopustId",
                table: "Artikal",
                column: "PopustId");

            migrationBuilder.CreateIndex(
                name: "IX_Artikal_ProizvodjacId",
                table: "Artikal",
                column: "ProizvodjacId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Kupci_ApplicationUserId",
                table: "Kupci",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Kupci_GradId",
                table: "Kupci",
                column: "GradId");

            migrationBuilder.CreateIndex(
                name: "IX_Narudzba_GradId",
                table: "Narudzba",
                column: "GradId");

            migrationBuilder.CreateIndex(
                name: "IX_Narudzba_KupacId",
                table: "Narudzba",
                column: "KupacId");

            migrationBuilder.CreateIndex(
                name: "IX_Narudzba_ZaposlenikId",
                table: "Narudzba",
                column: "ZaposlenikId");

            migrationBuilder.CreateIndex(
                name: "IX_Poruke_AdministratorId",
                table: "Poruke",
                column: "AdministratorId");

            migrationBuilder.CreateIndex(
                name: "IX_Poruke_ZaposlenikId",
                table: "Poruke",
                column: "ZaposlenikId");

            migrationBuilder.CreateIndex(
                name: "IX_Servis_ZaposlenikId",
                table: "Servis",
                column: "ZaposlenikId");

            migrationBuilder.CreateIndex(
                name: "IX_StavkaNarudzbe_ArtikalId",
                table: "StavkaNarudzbe",
                column: "ArtikalId");

            migrationBuilder.CreateIndex(
                name: "IX_StavkaNarudzbe_NarudzbaId",
                table: "StavkaNarudzbe",
                column: "NarudzbaId");

            migrationBuilder.CreateIndex(
                name: "IX_StavkaServis_ServisId",
                table: "StavkaServis",
                column: "ServisId");

            migrationBuilder.CreateIndex(
                name: "IX_Zaposlenici_ApplicationUserId",
                table: "Zaposlenici",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Zaposlenici_GradId",
                table: "Zaposlenici",
                column: "GradId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArtikalKategorija");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Dobavljac");

            migrationBuilder.DropTable(
                name: "Poruke");

            migrationBuilder.DropTable(
                name: "Skladiste");

            migrationBuilder.DropTable(
                name: "SmsLog");

            migrationBuilder.DropTable(
                name: "StavkaNarudzbe");

            migrationBuilder.DropTable(
                name: "StavkaServis");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Administratori");

            migrationBuilder.DropTable(
                name: "Artikal");

            migrationBuilder.DropTable(
                name: "Narudzba");

            migrationBuilder.DropTable(
                name: "Servis");

            migrationBuilder.DropTable(
                name: "Popusti");

            migrationBuilder.DropTable(
                name: "Proizvodjac");

            migrationBuilder.DropTable(
                name: "Kupci");

            migrationBuilder.DropTable(
                name: "Zaposlenici");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Grad");
        }
    }
}
