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
using HRentACar.HRentACar.Models;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace HRentACar.HRentACar.Views.Kontrole
{
    public sealed partial class LogIn : UserControl
    {
        List<Korisnik> korisnicii = new List<Korisnik>();

        public LogIn()
        {
            this.InitializeComponent();
        }


        private void mail_GotFocus(object sender, RoutedEventArgs e)
        {
            mail.Text = "";
        }

        private void sifra_GotFocus(object sender, RoutedEventArgs e)
        {
            sifra.Password = "";
        }

        private async void prijaviSe_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new KorisnikDbContext())
            {

               korisnicii =  db.Korisnici.ToList();

                for (int i = 0; i < korisnicii.Count; i++)
                {
                    if (korisnicii[i].Email.Equals(mail.Text) && korisnicii[i].Sifra.Equals(sifra.Password))
                    {
                        var dialog = new Windows.UI.Popups.MessageDialog(
                             "Uspješna prijava. ", "Poruka");

                        App.ImeLogIn = korisnicii[i].Ime;
                        App.Mail = mail.Text;

                        ProfilKontrola profil = new ProfilKontrola();
                        profil.Logovani = App.Mail;
                        profil.OnPropertyChanged("Logovani");
                        
                        //profil.Logovani = mail.Text.ToString();


                        dialog.Commands.Add(new Windows.UI.Popups.UICommand("OK") { Id = 0 });
                        dialog.Commands.Add(new Windows.UI.Popups.UICommand("Cancel") { Id = 1 });

                        /*
                        if (Windows.System.Profile.AnalyticsInfo.VersionInfo.DeviceFamily != "Windows.Mobile")
                        {
                            dialog.Commands.Add(new Windows.UI.Popups.UICommand("Maybe later") { Id = 2 });
                        }
                        */

                        dialog.DefaultCommandIndex = 0;
                        dialog.CancelCommandIndex = 1;

                        sifra.Password = "";
                        mail.Text = "";

                        var result = await dialog.ShowAsync();

                    }
                }
            }
        }
    }
}
