using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRentACar.HRentACar.Models
{
     public class Uposlenik : Korisnik
    {
        private int provjeraID { get; set; }

        public Uposlenik(int id, string i, string p, string s, string e, byte [] pic, int provjera) : base(id, i, p, s, e, pic)
        {
            provjeraID = provjera;
        }
    }
}
