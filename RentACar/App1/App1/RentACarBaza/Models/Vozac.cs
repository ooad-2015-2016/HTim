using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Entity;
using Microsoft.Data.Sqlite;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentACar.RentACarBaza.Models
{
    class Vozac
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        private int vozacID;
        private string ime;
        private string prezime;
        private bool dostupan;

        public string Ime
        {
            get
            {
                return ime;
            }

            set
            {
                ime = value;
            }
        }

        public string Prezime
        {
            get
            {
                return prezime;
            }

            set
            {
                prezime = value;
            }
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

        public int VozacID
        {
            get
            {
                return vozacID;
            }

            set
            {
                vozacID = value;
            }
        }
    }
}
