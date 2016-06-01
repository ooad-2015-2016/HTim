using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRentACar.HRentACar.Models
{
    class DefaultPodaci
    {
        public static void Initialize(KorisnikDbContext context)
        {
            if (!context.Korisnici.Any())
            {
                context.Korisnici.AddRange(
                new Korisnik()
                {
                    KorisnikId = 1,
                    Ime = "Belma",
                    Prezime = "Homarac",
                    Sifra = "123456",
                    Email = "bhomarac1@etf.unsa.ba"
                
                }
                );
                context.SaveChanges();


                context.Korisnici.AddRange(
                new Korisnik()
                {
                    KorisnikId = 2,
                    Ime = "Sumejja",
                    Prezime = "Halilovic",
                    Sifra = "sifra",
                    Email = "sumejja.halilovic.96@gmail.com"

                }
                );
                context.SaveChanges();
            }
        }
    }
}
