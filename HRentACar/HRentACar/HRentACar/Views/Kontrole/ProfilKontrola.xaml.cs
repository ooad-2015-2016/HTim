using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace HRentACar.HRentACar.Views.Kontrole
{
    public sealed partial class ProfilKontrola : UserControl, INotifyPropertyChanged
    {
        private string logovani;

        public string Logovani
        {
            get
            {
                return logovani;
            }

            set
            {
                logovani = value;
                OnPropertyChanged("Logovani");
            }
        }
       
        public ProfilKontrola()
        {
            this.InitializeComponent();
            logovani = App.Mail;
            //logovaniKorisnik.DataContext = App.Mail;
        }

        public ProfilKontrola(string mail)
        {
            this.InitializeComponent();
            logovani = mail;
            //logovaniKorisnik.DataContext = App.Mail;
        }

        public event RoutedEventHandler korisnikClicked
        {
            add { korisničkiProfil.Click += value; }
            remove { korisničkiProfil.Click -= value; }
        }

        public void promijeniVrijednosti(string ime)
        {
            logovaniKorisnik.Text = "Dobrodošli" + ime;
        }

        public event PropertyChangedEventHandler PropertyChanged;


        public void OnPropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
