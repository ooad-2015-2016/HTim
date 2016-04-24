using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1.RentACarBaza.Models
{
    enum Lokacija { Sarajevo, Mostar, Tuzla, Zenica }
    enum VrstaIznajmljivanja { saVozacem, bezVozaca }

    class Rezervacija
    {
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

            int idRezervacije { get; set; }
            Lokacija lokacija { get; set; }
            VrstaIznajmljivanja vrstaIznajmljivanja { get; set; }
            DateTime datumRezervisanja { get; set; }
        
    }
}
