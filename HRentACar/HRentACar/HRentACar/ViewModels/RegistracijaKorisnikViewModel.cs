using HRentACar.HRentACar.Helper;
using HRentACar.HRentACar.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.Storage;
using Windows.Storage.Pickers;

namespace HRentACar.HRentACar.ViewModels
{
    class RegistracijaKorisnikViewModel : INotifyPropertyChanged
    {

        public string VerifikacijaPoruka { get; set; }
        public string uIme { get; set; }
        public string uPrezime { get; set; }
        public string uMail { get; set; }
        public string uPassword { get; set; }
        public string uPasswordPotvrda { get; set; }
        public string uPrebivaliste { get; set; }
        public bool uVozacka { get; set; }
        public string uUpload { get; set; }

        public string ImeV { get; set; }
        public string PrezimeV { get; set; }
        public string MailV { get; set; }
        public string PasswordV { get; set; }
        public string PotvrdaV { get; set; }
        public string PrebivalisteV { get; set; }

        private bool ima;
        private List<Korisnik> korisnici = new List<Korisnik>();
        private byte[] uploadSlika;



        public ICommand RegistrujNovog { get; set; }
        public ICommand UploadSliku { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        public RegistracijaKorisnikViewModel(MainPage mainPage)
        {

            VerifikacijaPoruka = "";
            uIme = "";
            uPrezime = "";
            uMail = "";
            uPassword = "";
            uPasswordPotvrda = "";
            uPrebivaliste = "";
            uUpload = "Upload";

            RegistrujNovog = new RelayCommand<object>(registrujNovog);
            UploadSliku = new RelayCommand<object>(uploadSliku);
        }



        private async void registrujNovog(object obj)
        {
            //IME VALIDACIJA
            if (uIme.Length < 3)
            {

                ImeV = "Ime je prekratko!";
                NotifyPropertyChanged("ImeV");
            }
            else
            {
                ImeV = "";
                NotifyPropertyChanged("ImeV");
            }

            //MAIL VALIDACIJA
            Regex regx = new Regex(@"^([\w\.\-]+)@([\w\-]+)([\w\.\-]+)$");
            Match match = regx.Match(uMail);
            if (!match.Success)
            {
                MailV = "Mail nije validan!";
                NotifyPropertyChanged("MailV");
            }
            else
            {
                MailV = "";
                NotifyPropertyChanged("MailV");
            }

            //PREZIME VALIDACIJA
            if (uPrezime.Length < 3)
            {
                PrezimeV = "Prezime je prekratko!";
                NotifyPropertyChanged("PrezimeV");
            }
            else
            {
                PrezimeV = "";
                NotifyPropertyChanged("PrezimeV");
            }
            //password validacija
            if (uPassword.Length < 5)
            {
                PasswordV = "5 kraktera min!";
                NotifyPropertyChanged("PasswordV");
            }
            else
            {
                PasswordV = "";
                NotifyPropertyChanged("PasswordV");
            }

            //POTVRDA PASSWORD

            if (uPasswordPotvrda.Length < 5)
            {
                PotvrdaV = "5 kraktera min!";
                NotifyPropertyChanged("PotvrdaV");
            }
            else if (uPasswordPotvrda.Length >= 5 && uPasswordPotvrda != uPassword)
            {
                PotvrdaV = "Šire nisu jednake!";
                NotifyPropertyChanged("PotvrdaV");
            }
            else
            {
                PotvrdaV = "";
                NotifyPropertyChanged("PotvrdaV");
            }

            //prebivaliste
            if (uPrebivaliste.Length < 3)
            {
                PrebivalisteV = "3 kraktera min!";
                NotifyPropertyChanged("PrebivalisteV");
            }
            else
            {
                PrebivalisteV = "";
                NotifyPropertyChanged("PrebivalisteV");
            }

            if (ImeV.Equals("") && PrezimeV.Equals("") && MailV.Equals("") && PasswordV.Equals("") && PotvrdaV.Equals("") && PrebivalisteV.Equals(""))
            {
                ima = false;

                using (var db = new KorisnikDbContext())
                {
                    korisnici = db.Korisnici.ToList();

                    var contact = new Korisnik
                    {
                        Ime = uIme,
                        Prezime = uPrezime,
                        Sifra = uPassword,
                        Email = uMail,
                        Slika = uploadSlika
                

                };

                for (int i = 0; i < korisnici.Count; i++)
                {
                    if (korisnici[i].Email.Equals(uMail))
                    {
                        var dijalog = new Windows.UI.Popups.MessageDialog(
                             "Korisnik sa tim mailom je već registrovan. ", "Poruka");


                        dijalog.Commands.Add(new Windows.UI.Popups.UICommand("OK") { Id = 0 });
                        dijalog.Commands.Add(new Windows.UI.Popups.UICommand("Cancel") { Id = 1 });

                        dijalog.DefaultCommandIndex = 0;
                        dijalog.CancelCommandIndex = 1;

                        var rezultat = await dijalog.ShowAsync();
                        //reset polja za unos
                        uIme = string.Empty;
                        uPassword = string.Empty;
                        uMail = string.Empty;
                        uPrebivaliste = string.Empty;
                        uVozacka = false;
                        uPasswordPotvrda = string.Empty;
                        uPrezime = string.Empty;
                        uUpload = "Upload";

                        ima = true;

                        break;

                    }
                }

                if (!ima)
                {
                    db.Korisnici.Add(contact);

                    db.SaveChanges();

                    App.ImeLogIn = uIme;
                    App.Mail = uMail;

                        //reset polja za unos
                        //reset polja za unos
                        uIme = string.Empty;
                        uPassword = string.Empty;
                        uMail = string.Empty;
                        uPrebivaliste = string.Empty;
                        uVozacka = false;
                        uPasswordPotvrda = string.Empty;
                        uPrezime = string.Empty;
                        uUpload = "Upload";

                        var dialog = new Windows.UI.Popups.MessageDialog(
                            "Uspješna registracija. ", "Poruka");


                    dialog.Commands.Add(new Windows.UI.Popups.UICommand("OK") { Id = 0 });
                    dialog.Commands.Add(new Windows.UI.Popups.UICommand("Cancel") { Id = 1 });

                    dialog.DefaultCommandIndex = 0;
                    dialog.CancelCommandIndex = 1;

                    var result = await dialog.ShowAsync();

                    }

                }
            }
        }

        private async void uploadSliku(object parametar)
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
                uUpload = "Picked photo: " + file.Name;
                NotifyPropertyChanged("uUpload");
            }
        }
    }
}
