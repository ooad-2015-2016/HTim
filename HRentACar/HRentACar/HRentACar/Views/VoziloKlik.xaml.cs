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
using HRentACar.HRentACar.Models;
using Windows.UI.Core;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace HRentACar.HRentACar.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class VoziloKlik : Page
    {
        private Vozilo auto;
        private List<string> slike = new List<string>();
       
        public VoziloKlik()
        {
            this.InitializeComponent();
        }

        List<Item> TLista = new List<Item>();

        void AddImageIntoList()
        {
            Item a;
            a = new Item("Assets/" + auto.Naziv + "/prva.jpg");
            TLista.Add(a);
            a = new Item("Assets/" + auto.Naziv + "/druga.jpg");
            TLista.Add(a);
            a = new Item("Assets/" + auto.Naziv + "/treca.jpg");
            TLista.Add(a);

            slikeAutomobila.ItemsSource = TLista;
        }

        private void rezervisi_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof (Rezervacija));
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            auto = (Vozilo)e.Parameter;
            slike = auto.Slike;
            AddImageIntoList();

            nazivAuta.Text = auto.Naziv;

            opisAuta.Text = auto.Opis;

            Frame rootFrame = Window.Current.Content as Frame;

            if (rootFrame.CanGoBack)
            {
                // Show UI in title bar if opted-in and in-app backstack is not empty.
                SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility =
                    AppViewBackButtonVisibility.Visible;
            }
            else
            {
                // Remove the UI from the title bar if in-app back stack is empty.
                SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility =
                    AppViewBackButtonVisibility.Collapsed;
            }
        }

    }
}