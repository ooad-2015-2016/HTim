using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1.RentACarBaza.Models
{
    class KorisnikUsluga
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int KorisnikUslugaID { get; set; }
        private string ime;
        private string prezime;
        private string sifra;
        private string email;
        
        public KorisnikUsluga (int id, string i, string p, string s, string e)
        {
            KorisnikUslugaID = id;
            ime = i;
            prezime = p;
            sifra = s;
            email = e;
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
