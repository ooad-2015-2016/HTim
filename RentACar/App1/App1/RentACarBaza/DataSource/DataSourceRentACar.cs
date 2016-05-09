using App1.RentACarBaza.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1.RentACarBaza.DataSource
{
    class DataSourceRentACar
    {
        #region KorisnikUsluga - kreiranje testnih korisnika
        private static List<KorisnikUsluga> _korisnici = new List<KorisnikUsluga>()
        {
            new Administrator (1,"ImeAdmina","PrezimeAdmina","0000","glavni@gmail.com"),
            new Klijent (1,"ImeKlijenta","PrezimeKlijenta","1234","klijent1@gmail.com",true,true,"Vogosca")
        };
         

        #endregion
    }
}
