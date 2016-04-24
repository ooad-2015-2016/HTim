using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1.RentACarBaza.Models
{
    class Vozilo
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        private int VoziloID { get; set; }
        private double cijenaIznajmljivanja;
        private string slika;
        private Lokacija lokacija;


        public double CijenaIznajmljivanja
        {
            get
            {
                return cijenaIznajmljivanja;
            }

            set
            {
                cijenaIznajmljivanja = value;
            }
        }

        public string Slika
        {
            get
            {
                return slika;
            }

            set
            {
                slika = value;
            }
        }

        internal Lokacija Lokacija
        {
            get
            {
                return lokacija;
            }

            set
            {
                lokacija = value;
            }
        }
    }
}
