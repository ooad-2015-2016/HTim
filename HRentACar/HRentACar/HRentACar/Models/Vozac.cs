using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRentACar.HRentACar.Models
{
    public class Vozac : Uposlenik
    {
        private bool dostupan;
        private int provjera;

        public Vozac (int id, string i, string p, string s, string e, byte [] pic, int provjera, bool dostupan) : base(id, i, p, s, e, pic, provjera)
        {
            this.dostupan = dostupan;
        }

        public bool Dostupan
        {
            get
            {
                return dostupan;
            }

            set
            {
                dostupan = value;
            }
        }


        public int Provjera
        {
            get
            {
                return provjera;
            }

            set
            {
                provjera = value;
            }
        }
    }
}
