﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRentACar.HRentACar.Models
{
    public class Administrator : Korisnik
    {
        public List<Uposlenik> uposlenici { get; set; }

        public Administrator(int id, string i, string p, string s, string e, byte [] pic) : base(id, i, p, s, e, pic)
        {
            uposlenici = new List<Uposlenik>();
        }

        public Administrator() {}

 
    }
}
