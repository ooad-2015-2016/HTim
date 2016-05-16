using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
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
using HRentACar.HRentACar.Models;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace HRentACar.HRentACar.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Katalog : Page
    {
        private List<Vozilo> vozila;

        public Katalog()
        {
            this.InitializeComponent();
            ShopWindowCollection = new ObservableCollection<Vozilo>();

            // noobs
            vozila = KatalogVozila.vratiSvaVozila();
        }

        // Kolekcija proizvoda koja predstavlja "izlog prodavnice", dakle sadrži sve proizvode koje trenutno posjedujemo
        public ObservableCollection<Vozilo> ShopWindowCollection { get; set; }


        private void RegistracijaKontrola_Loaded(object sender, RoutedEventArgs e)
        {

        }

       
        private void GridView_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            this.Frame.Navigate(typeof(Prijava));
        }
    }
}
