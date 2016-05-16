using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRentACar.HRentACar.Models
{
    public class Vozilo
    {
        private int voziloID;
        private string naziv;
        private string godiste;
        private bool dostupnost;
        private double cijena;
        private string opis;

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

        public int VoziloID
        {
            get
            {
                return voziloID;
            }

            set
            {
                voziloID = value;
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

        public Vozilo(int id, string naziv, string godiste,  double cijena, string opis, bool dostupnost)
        {
            voziloID = id;
            this.naziv = naziv;
            this.godiste = godiste;
            this.cijena = cijena;
            this.opis = opis;
            this.dostupnost = dostupnost;

        }
    }

    public class KatalogVozila
    {
        public static List<Vozilo> vozila { get; set; }

        public static List<Vozilo> vratiSvaVozila()
        {
            return new List<Vozilo>()
            {
                new Vozilo(1, "Volkswagen Kombi", "1992", 70, "ms-appx:///Assets/Automobili/vw-kombi.jpg", true),
                new Vozilo(2, "BMW X5", "2010", 50, "ms-appx:///Assets/Automobili/bmw-x5.jpg", true),
                new Vozilo(3, "Golf GTI", "2014", 65, "ms-appx:///Assets/Automobili/Golf gti.jpg", true),
                new Vozilo(4, "Hyundai ix35", "2011", 80, "ms-appx:///Assets/Automobili/hyundai.jpg", true),
                new Vozilo(5, "Mercedes Benz S Klasse", "2012", 90, "ms-appx:///Assets/Automobili/Mercedes-benz S.jpg", true),
                new Vozilo(6, "Mini Cooper", "2015", 40, "ms-appx:///Assets/Automobili/mini-cooper.jpg", true),
                new Vozilo(7, "Renault Megane", "2013", 75, "ms-appx:///Assets/Automobili/renault-megane.jpg", true),
                new Vozilo(8, "Yugo 45", "1984", 120, "ms-appx:///Assets/Automobili/yugo.jpg", true),
                new Vozilo(9, "Audi Q3", "2014", 100, "ms-appx:///Assets/Automobili/q3.png", true),
                new Vozilo(10, "Volkswagen Beetle ", "2010", 55, "ms-appx:///Assets/Automobili/buba.jpg", true),
                new Vozilo(11, "Audi A8", "2013", 60 , "ms-appx:///Assets/Automobili/audi-a8.jpg", true)

            };
        }
    }
}
