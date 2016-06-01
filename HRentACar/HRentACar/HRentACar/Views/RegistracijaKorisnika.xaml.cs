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
using HRentACar.HRentACar.ViewModels;
using System.Text.RegularExpressions;
using Windows.Storage;
using Windows.Storage.Pickers;
using HRentACar.HRentACar.Views.Kontrole;
using HRentACar.HRentACar.Models;
using System.ComponentModel;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace HRentACar.HRentACar.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class RegistracijaKorisnika : Page
    {
        public RegistracijaKorisnika()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            RegistracijaKorisnikViewModel registracijaKorisnikViewModel = e.Parameter as RegistracijaKorisnikViewModel;
            DataContext = registracijaKorisnikViewModel;
        }       
    }
}
