using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1.RentACarBaza.Models
{
    class Klijent : KorisnikUsluga
    {
        private bool validnaVozackaDozvola;
        private bool punoljetnost;
        private string prebivaliste;

        public Klijent(int id,string i, string p, string s, string e, bool v, bool pu, string pr): base (id,i,p,s,e)
            {
                validnaVozackaDozvola = v;
                punoljetnost = pu;
                prebivaliste = pr;
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
