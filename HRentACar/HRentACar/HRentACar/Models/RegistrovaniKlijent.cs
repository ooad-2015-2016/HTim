using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRentACar.HRentACar.Models
{
    public class RegistrovaniKlijent : Korisnik
    {
        private bool validnaVozackaDozvola;
        private bool punoljetnost;
        private string prebivaliste;

        public RegistrovaniKlijent(int id, string i, string p, string s, string e, byte [] pic, bool v, bool pu, string pr): base (id,i,p,s,e, pic)
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
