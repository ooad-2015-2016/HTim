using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1.RentACarBaza.Models
{
    class Uposlenik:KorisnikUsluga
    {
        private int provjeraID { get; set; }
        public Uposlenik (int id, string i, string p, string s, string e, int provjera):base(id,i,p,s,e)
        {
            provjeraID = provjera;
        }
    }
}
