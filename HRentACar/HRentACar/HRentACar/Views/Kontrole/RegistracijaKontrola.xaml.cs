using Microsoft.Data.Entity;
using HRentACar.HRentACar.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Pickers;
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
    public sealed partial class RegistracijaKontrola : UserControl
    {
        //Potrebno je privremeno negdje staviti sliku koja se uploaduje
        private byte[] uploadSlika;
        private List<Korisnik> korisnici = new List<Korisnik>();
        private bool ima;

        public RegistracijaKontrola()
        {
            this.InitializeComponent();
        }
        

        private async void registrujSe_Click(object sender, RoutedEventArgs e)
        {
            ima = false;

            using (var db = new KorisnikDbContext())
            {
                korisnici = db.Korisnici.ToList();

                var contact = new Korisnik
                {
                    Ime = ime.Text,
                    Prezime = prezime.Text,
                    Sifra = sifra.Password,
                    Email = mail.Text,
                    Slika = uploadSlika

                };

                for (int i = 0; i < korisnici.Count; i++)
                {
                    if (korisnici[i].Email.Equals(mail.Text))
                    {
                        var dijalog = new Windows.UI.Popups.MessageDialog(
                             "Korisnik sa tim mailom je već registrovan. ", "Poruka");


                        dijalog.Commands.Add(new Windows.UI.Popups.UICommand("OK") { Id = 0 });
                        dijalog.Commands.Add(new Windows.UI.Popups.UICommand("Cancel") { Id = 1 });

                        /*
                        if (Windows.System.Profile.AnalyticsInfo.VersionInfo.DeviceFamily != "Windows.Mobile")
                        {
                            dialog.Commands.Add(new Windows.UI.Popups.UICommand("Maybe later") { Id = 2 });
                        }
                        */

                        dijalog.DefaultCommandIndex = 0;
                        dijalog.CancelCommandIndex = 1;

                        var rezultat = await dijalog.ShowAsync();
                        //reset polja za unos
                        ime.Text = string.Empty;
                        sifra.Password = string.Empty;
                        mail.Text = string.Empty;
                        prebivaliste.Text = string.Empty;
                        vozacka.IsChecked = false;
                        potvrda.Password = string.Empty;
                        prezime.Text = string.Empty;
                        buttonUpload.Content = "";

                        ima = true;

                        break;

                    }
                }

                if (!ima)
                {
                    db.Korisnici.Add(contact);

                    db.SaveChanges();

                    //reset polja za unos
                    ime.Text = string.Empty;
                    sifra.Password = string.Empty;
                    mail.Text = string.Empty;
                    prebivaliste.Text = string.Empty;
                    vozacka.IsChecked = false;
                    potvrda.Password = string.Empty;
                    prezime.Text = string.Empty;
                    buttonUpload.Content = "";

                    var dialog = new Windows.UI.Popups.MessageDialog(
                            "Uspješna registracija. ", "Poruka");


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

                    var result = await dialog.ShowAsync();
                    
                }
                
            }


        }
               

        private async void buttonUpload_Click(object sender, RoutedEventArgs e)
        {
            FileOpenPicker openPicker = new Windows.Storage.Pickers.FileOpenPicker();
            openPicker.ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail;
            openPicker.SuggestedStartLocation =
           Windows.Storage.Pickers.PickerLocationId.PicturesLibrary;
            //Da se filtriraju dokumenti u pickeru na slike
            openPicker.FileTypeFilter.Add(".jpg");
            openPicker.FileTypeFilter.Add(".jpeg");
            openPicker.FileTypeFilter.Add(".png");
            //Prebacivanje contenta fajla u uploadSlika varijablu
            StorageFile file = await openPicker.PickSingleFileAsync();
            if (file != null)
            {
                uploadSlika = (await Windows.Storage.FileIO.ReadBufferAsync(file)).ToArray(); ;
                //Da se na buttonu vidi neka promjena da je upload uspjesan
                buttonUpload.Content = "Picked photo: " + file.Name;
            }
        }
    }
}
