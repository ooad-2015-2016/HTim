using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRentACar.HRentACar.Models
{
 
    public class Vozilo
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        private int voziloId;
        private string naziv;
        private string godiste;
        private bool dostupnost;
        private double cijena;
        private string opis;
        private List<string> slike;

        public string Naziv
        {
            get
            {
                return naziv;
            }

            set
            {
                naziv = value;
            }
        }

        public string Godiste
        {
            get
            {
                return godiste;
            }

            set
            {
                godiste = value;
            }
        }

        public bool Dostupnost
        {
            get
            {
                return dostupnost;
            }

            set
            {
                dostupnost = value;
            }
        }

        public double Cijena
        {
            get
            {
                return cijena;
            }

            set
            {
                cijena = value;
            }
        }

        public int VoziloId
        {
            get
            {
                return voziloId;
            }

            set
            {
                voziloId = value;
            }
        }

        public string Opis
        {
            get
            {
                return opis;
            }

            set
            {
                opis = value;
            }
        }

        public List<string> Slike
        {
            get
            {
                return slike;
            }

            set
            {
                slike = value;
            }
        }

        public Vozilo(int id, string naziv, string godiste,  double cijena, List<string> slike, string opis, bool dostupnost)
        {
            voziloId = id;
            this.naziv = naziv;
            this.godiste = godiste;
            this.cijena = cijena;
            this.opis = opis;
            this.slike = slike;                
            this.dostupnost = dostupnost;

        }

        public Vozilo () { }

        public void dodajOpis()
        {
            Opis = Naziv + "\n" + "Godište: " + Godiste + "\n" + "Automobil je noviji, uredno održavan, prihvatljive cijene. Idealan je za porodice s djecom, ali i za samce.\n" +
                "Cijena: " + Cijena + " KM po danu.";
        }

    }

    public class KatalogVozila
    {
        public static List<Vozilo> vozila { get; set; }



        public static List<Vozilo> vratiSvaVozila()
        {
            List<Vozilo> vozila = new List<Vozilo>();

            vozila.Add(new Vozilo(1, "Mercedes Benz C220", "2016", 110, new List<string> { "ms-appx:///Assets/Mercedes Benz C220/prva.jpg", "ms-appx:///Assets/C220/druga.jpg", "ms-appx:///Assets/C220/treca.jpg" }, "opis", true));
            vozila.Add(new Vozilo(2, "BMW 650i", "2015", 95, new List<string> { "ms-appx:///Assets/BMW 650i/prva.jpg", "ms-appx:///Assets/BMW/druga.jpg", "ms-appx:///Assets/BMW/treca.jpg" }, "opis", true));
            vozila.Add(new Vozilo(3, "Lancia", "2014", 65, new List<string> { "ms-appx:///Assets/Lancia/prva.jpg", "ms-appx:///Assets/Lancia/druga.jpg", "ms-appx:///Assets/Lancia/treca.jpg" }, "opis", true));
            vozila.Add(new Vozilo(4, "Peugeot 307", "2009", 50, new List<string> { "ms-appx:///Assets/Peugeot 307/prva.jpg", "ms-appx:///Assets/307/druga.jpg", "ms-appx:///Assets/307/treca.jpg" }, "opis", true));
            vozila.Add(new Vozilo(5, "Mini Cooper", "2015", 40, new List<string> { "ms-appx:///Assets/Mini Cooper/prva.jpg", "ms-appx:///Assets/Mini Cooper/druga.jpg", "ms-appx:///Assets/Mini Cooper/treca.jpg" }, "opis", true));
            vozila.Add(new Vozilo(6, "Renault Megane", "2013", 75, new List<string> { "ms-appx:///Assets/Renault Megane/prva.jpg" }, "opis", true));
            vozila.Add(new Vozilo(7, "Audi Q3", "2014", 100, new List<string> { "ms-appx:///Assets/Audi Q3/prva.jpg" }, "opis", true));
            vozila.Add(new Vozilo(8, "Volkswagen Beetle", "1970", 55, new List<string> { "ms-appx:///Assets/Volkswagen Beetle/prva.jpg" }, "opis", true));
            vozila.Add(new Vozilo(9, "Volkswagen Kombi", "1992", 70, new List<string> { "ms-appx:///Assets/Automobili/vw-kombi.jpg" }, "opis", true));

            for (int i = 0; i < vozila.Count; i++)
            {
                vozila[i].dodajOpis();
            }

            return vozila;

        }

       
            
    }
}
