using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRentACar.HRentACar.Models
{
    public class Korisnik
    {
        public int KorisnikUslugaID { get; set; }
        private string ime;
        private string prezime;
        private string sifra;
        private string email;

        public Korisnik(int id, string i, string p, string s, string e)
        {
            KorisnikUslugaID = id;
            ime = i;
            prezime = p;
            sifra = s;
            email = e;
        }
        public Korisnik()
        {
        }

        public string Ime
        {
            get
            {
                return ime;
            }

            set
            {
                ime = value;
            }
        }

        public string Prezime
        {
            get
            {
                return prezime;
            }

            set
            {
                prezime = value;
            }
        }



        public string Sifra
        {
            get
            {
                return sifra;
            }

            set
            {
                sifra = value;
            }
        }

        public string Email
        {
            get
            {
                return email;
            }

            set
            {
                email = value;
            }
        }
    }
}

