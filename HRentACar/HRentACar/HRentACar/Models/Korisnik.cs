using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRentACar.HRentACar.Models
{
    public class Korisnik
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int KorisnikId { get; set; }
        private string ime;
        private string prezime;
        private string sifra;
        private string email;

        public event PropertyChangedEventHandler PropertyChanged;

        public byte[] Slika { get; set; }

        public Korisnik(int id, string i, string p, string s, string e, byte[] pic)
        {
            KorisnikId = id;
            ime = i;
            prezime = p;
            sifra = s;
            email = e;
            Slika = pic;
        }

        public Korisnik()
        {
        }

        public Korisnik(string e, string s)
        {
            email = e;
            sifra = s;
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

