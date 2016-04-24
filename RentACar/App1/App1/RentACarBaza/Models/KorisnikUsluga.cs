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

        string ime { get; set; }
        string prezime { get; set; }
        string prebivaliste { get; set; }
        bool validnaVozackaDozvola { get; set; }
        bool punoljetnost { get; set;  }
    }
}
