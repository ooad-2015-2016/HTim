using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1.RentACarBaza.Models
{
    class Administrator:KorisnikUsluga
    {
        public List<Uposlenik> uposlenici { get; set; }
        public Administrator (int id, string i, string p, string s, string e): base (id,i,p,s,e)
        {
            uposlenici = new List<Uposlenik>();
        }
    }
}
