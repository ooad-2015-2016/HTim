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
        private string prebivaliste;
        private bool validnaVozackaDozvola;
        private bool punoljetnost;

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

        public string Prebivaliste
        {
            get
            {
                return prebivaliste;
            }

            set
            {
                prebivaliste = value;
            }
        }

        public bool ValidnaVozackaDozvola
        {
            get
            {
                return validnaVozackaDozvola;
            }

            set
            {
                validnaVozackaDozvola = value;
            }
        }

        public bool Punoljetnost
        {
            get
            {
                return punoljetnost;
            }

            set
            {
                punoljetnost = value;
            }
        }
    }
}
