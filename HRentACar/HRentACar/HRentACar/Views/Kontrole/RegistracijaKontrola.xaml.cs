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
using HRentACar.HRentACar.Views.Kontrole;
using System.ComponentModel;
using System.Text.RegularExpressions;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace HRentACar.HRentACar.Views.Kontrole
{
    public sealed partial class RegistracijaKontrola : UserControl, INotifyPropertyChanged
    {
        //Potrebno je privremeno negdje staviti sliku koja se uploaduje
        private byte[] uploadSlika;
        private List<Korisnik> korisnici = new List<Korisnik>();
        private bool ima;
        private string porukaValidacije;

        public string PorukaValidacije
        {
            get
            {
                return porukaValidacije;
            }

            set
            {
                porukaValidacije = value;
                OnPropertyChanged("PorukaValidacije");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

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

                    App.ImeLogIn = ime.Text;
                    App.Mail = mail.Text;

                    ProfilKontrola profil = new ProfilKontrola(mail.Text.ToString());
                    //profil.Logovani = mail.Text.ToString();

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

        private async void ime_LostFocus(object sender, RoutedEventArgs e)
        {
            if (ime.Text.Length < 3)
            {
                porukaValidacije = "Ime je prekratko!";
                OnPropertyChanged("PorukaValidacije");
            }
            else
            {
                porukaValidacije = "";
                OnPropertyChanged("PorukaValidacije");
            }
        }

        private void prezime_LostFocus(object sender, RoutedEventArgs e)
        {
            if (prezime.Text.Length < 3)
            {
                porukaValidacije = "Prezime je prekratko!";
                OnPropertyChanged("PorukaValidacije");
            }
            else
            {
                porukaValidacije = "";
                OnPropertyChanged("PorukaValidacije");
            }
        }

        private void mail_LostFocus(object sender, RoutedEventArgs e)
        {
            Regex regx = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regx.Match(mail.Text);
            if (!match.Success)
            {
                porukaValidacije = "Mail nije validan!";
                OnPropertyChanged("PorukaValidacije");
            }
            else
            {
                porukaValidacije = "";
                OnPropertyChanged("PorukaValidacije");
            }
        }

        private void sifra_LostFocus(object sender, RoutedEventArgs e)
        {
            if (sifra.Password.Length < 3)
            {
                porukaValidacije = "Šifra je prekratka!";
                OnPropertyChanged("PorukaValidacije");
            }
            else
            {
                porukaValidacije = "";
                OnPropertyChanged("PorukaValidacije");
            }
        }

        private void potvrda_LostFocus(object sender, RoutedEventArgs e)
        {
            if(!potvrda.Password.ToString().Equals(sifra.Password.ToString()))
            {
                porukaValidacije = "Ne podudara se";
                OnPropertyChanged("PorukaValidacije");
            }
            else
            {
                porukaValidacije = "";
                OnPropertyChanged("PorukaValidacije");
            }
        }

        private void prebivaliste_LostFocus(object sender, RoutedEventArgs e)
        {
            if (prebivaliste.Text.Length < 3)
            {
                porukaValidacije = "Prebivaliste je prekratko!";
                OnPropertyChanged("PorukaValidacije");
            }
            else
            {
                porukaValidacije = "";
                OnPropertyChanged("PorukaValidacije");
            }
        }
    }
}
