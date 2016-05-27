using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRentACar.HRentACar.Views
{
    public class Item
    {
        static Uri baseUri = new Uri("ms-appx:///");
        // ms-appx:///Assets/C220/prva.png
        private Uri slika;

        public Uri Slika
        {
            get {return slika;}

            set { slika = value; }
        }

        public Item(string path)
        {
            this.slika = new Uri(baseUri, path);
        }
    }
}
