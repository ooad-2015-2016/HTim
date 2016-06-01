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
    public sealed partial class BlankPage1 : Page, INotifyPropertyChanged
    {
        public BlankPage1()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            RegistracijaKorisnikViewModel registracijaKorisnikViewModel = e.Parameter as RegistracijaKorisnikViewModel;
            DataContext = registracijaKorisnikViewModel;
        }


        private byte[] uploadSlika;
        private List<Korisnik> korisnici = new List<Korisnik>();
        private bool ima;
        private string porukaValidacije;

        private string imeV;
        private string prezimeV;
        private string mailV;
        private string sifraV;
        private string prebivalisteV;

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

        public string ImeV
        {
            get
            {
                return imeV;
            }

            set
            {
                imeV = value;
                OnPropertyChanged("ImeV");
            }
        }

        public string PrezimeV
        {
            get
            {
                return prezimeV;
            }

            set
            {
                prezimeV = value;
                OnPropertyChanged("PrezimeV");
            }
        }

        public string MailV
        {
            get
            {
                return mailV;
            }

            set
            {
                mailV = value;
                OnPropertyChanged("MailV");
            }
        }

        public string SifraV
        {
            get
            {
                return sifraV;
            }

            set
            {
                sifraV = value;
                OnPropertyChanged("SifraV");
            }
        }

        public string PrebivalisteV
        {
            get
            {
                return prebivalisteV;
            }

            set
            {
                prebivalisteV = value;
                OnPropertyChanged("PrebivalisteV");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
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
                    profil.OnPropertyChanged("Logovani");
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

        

        private void prezime_LostFocus(object sender, RoutedEventArgs e)
        {
            if (prezime.Text.Length < 3)
            {
                prezimeV = "Prezime je prekratko!";
                OnPropertyChanged("PrezimeV");
            }
            else
            {
                prezimeV = "";
                OnPropertyChanged("PrezimeV");
            }
        }

        private void mail_LostFocus(object sender, RoutedEventArgs e)
        {
            Regex regx = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regx.Match(mail.Text);
            if (!match.Success)
            {
                mailV = "Mail nije validan!";
                OnPropertyChanged("MailV");
            }
            else
            {
                mailV = "";
                OnPropertyChanged("MailV");
            }
        }

        private void sifra_LostFocus(object sender, RoutedEventArgs e)
        {
            if (sifra.Password.Length < 3)
            {
                sifraV = "Šifra je prekratka!";
                OnPropertyChanged("SifraV");
            }
            else
            {
                sifraV = "";
                OnPropertyChanged("SifraV");
            }
        }

        private void potvrda_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!potvrda.Password.ToString().Equals(sifra.Password.ToString()))
            {
                sifraV = "Unesene šifre nisu jednake!";
                OnPropertyChanged("SifraV");
            }
            else
            {
                sifraV = "";
                OnPropertyChanged("SifraV");
            }
        }

        private void prebivaliste_LostFocus(object sender, RoutedEventArgs e)
        {
            if (prebivaliste.Text.Length < 3)
            {
                prebivalisteV = "Naziv je prekratak!";
                OnPropertyChanged("PrebivalisteV");
            }
            else
            {
                prebivalisteV = "";
                OnPropertyChanged("PrebivalisteV");
            }
        }
    }
}
