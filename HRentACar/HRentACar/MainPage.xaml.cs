using System;
using System.Collections.Generic;
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
using HRentACar.HRentACar.Views;
using HRentACar.HRentACar.ViewModels;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace HRentACar
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        

        public MainPage()
        {
            this.InitializeComponent();
            mainContentFrame.Navigate(typeof(Pocetna));
            nazad.Visibility = Visibility.Collapsed;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            MainModelView mainModelView = e.Parameter as MainModelView;
            DataContext = mainModelView;
        }

        private void PushDugme_Click(object sender, RoutedEventArgs e)
        {
            MojView.IsPaneOpen = !MojView.IsPaneOpen;
        }

        private void IconsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(Pretraga.IsSelected)
            {
                nazad.Visibility = Visibility.Visible;
                mainContentFrame.Navigate(typeof(Katalog));
            }
            else if (Registracija.IsSelected)
            {
                nazad.Visibility = Visibility.Collapsed;
                mainContentFrame.Navigate(typeof(RegistracijaKorisnika), new RegistracijaKorisnikViewModel(this));
            }
            else if (Pocetna.IsSelected)
            {
                nazad.Visibility = Visibility.Collapsed;
                stekPenl.Visibility = Visibility.Collapsed;
                if (App.Mail.Equals("bhomarac1@etf.unsa.ba") && App.Password.Equals("123456") ||
                    App.Mail.Equals("sumejja.halilovic.96@gmail.com") && App.Password.Equals("fifija"))
                    mainContentFrame.Navigate(typeof(KorisniciListView));

                else
                    mainContentFrame.Navigate(typeof(Pocetna));
            }
            else if (iNFO.IsSelected)
            {
                nazad.Visibility = Visibility.Collapsed;
                mainContentFrame.Navigate(typeof(info));
            }
            else if(Prijava.IsSelected)
            {
                nazad.Visibility = Visibility.Collapsed;
                mainContentFrame.Navigate(typeof(Prijava), new PrijavaViewModel(this));
            }
            else if (Lokacija.IsSelected)
            {
                nazad.Visibility = Visibility.Collapsed;
                mainContentFrame.Navigate(typeof(Lokacija));
            }
        }

        private void nazad_Click(object sender, RoutedEventArgs e)
        {
             if(mainContentFrame.CanGoBack)
            {
                mainContentFrame.GoBack();
            }
        }

        private void korisnik_Clicked(object sender, RoutedEventArgs e)
        {
            Registracija.IsSelected = true;
            mainContentFrame.Navigate(typeof(RegistracijaKorisnika));
        }
    }
}
