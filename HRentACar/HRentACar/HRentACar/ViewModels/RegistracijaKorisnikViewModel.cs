using HRentACar.HRentACar.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;

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

        public string ImeV { get; set; }
        public string PrezimeV { get; set; }
        public string MailV { get; set; }
        public string PasswordV { get; set; }
        public string PotvrdaV { get; set; }
        public string PrebivalisteV { get; set; }

        public ICommand RegistrujNovog { get; set; }

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

            RegistrujNovog = new RelayCommand<object>(registrujNovog);
        }

        

        private void registrujNovog(object obj)
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
            Regex regx = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
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
            else if(uPasswordPotvrda.Length >= 5 && uPasswordPotvrda != uPassword)
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

            if(ImeV.Equals("") && PrezimeV.Equals("") && MailV.Equals("") && PasswordV.Equals("") && PotvrdaV.Equals("") && PrebivalisteV.Equals(""))
            {
                //OVDJE IDE DIO KODA KOJI UPISUJE NOVOG KORISNIKA U BAZU
            }
        }
    }
}
