using HRentACar.HRentACar.Helper;
using HRentACar.HRentACar.Models;
using HRentACar.HRentACar.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.ComponentModel;

namespace HRentACar.HRentACar.ViewModels
{
    class PrijavaViewModel
    {
        List<Korisnik> korisnicii = new List<Korisnik>();

        public string uMail { get; set; }
        public string uPassword { get; set; }

        public ICommand Prijavi { get; set; }
        public ICommand Predji { get; set; }
        public INavigationService NavigationService { get; set; }

        public PrijavaViewModel(MainPage mainPage)
        {
            uMail = "";
            uPassword = "";

            //NavigationService = new NavigationService(); NECE DA MI PREPOZNA OVO NAVIGATION SERVICE

            Prijavi = new RelayCommand<object>(prijavi);
            Predji = new RelayCommand<object>(predji);

        }

        private void predji(object obj)
        {
            NavigationService.Navigate(typeof(AdministratorForma), new AdministratorViewModel(this));
        }

        private async void prijavi(object obj)
        {
            using (var db = new KorisnikDbContext())
            {

                korisnicii = db.Korisnici.ToList();
                int nadjen = 0;

                for (int i = 0; i < korisnicii.Count; i++)
                {
                    if (korisnicii[i].Email.Equals(uMail) && korisnicii[i].Sifra.Equals(uPassword))
                    {
                        var dialog = new Windows.UI.Popups.MessageDialog(
                             "Uspješna prijava. ", "Poruka");

                        App.Mail = uMail;
                        App.Password = uPassword;

                        nadjen++;

                        dialog.Commands.Add(new Windows.UI.Popups.UICommand("OK") { Id = 0 });
                        dialog.Commands.Add(new Windows.UI.Popups.UICommand("Cancel") { Id = 1 });

                        dialog.DefaultCommandIndex = 0;
                        dialog.CancelCommandIndex = 1;

                        uMail = "";
                        uPassword = "";

                        var result = await dialog.ShowAsync();

                        //AKO JE ADMINISTRATOR 
                        if(App.Password == "12345" || App.Password.Equals("fifija"))
                        {
                            if(NavigationService != null)
                            predji(uMail);
                        }

                    }
                }
                if (nadjen == 0)
                {
                    var dialog = new Windows.UI.Popups.MessageDialog(
                             "Nije registrovan korisnik sa unesenim podacima! ", "Poruka");

                    App.ImeLogIn = "";
                    App.Mail = "";

                    nadjen++;

                    dialog.Commands.Add(new Windows.UI.Popups.UICommand("OK") { Id = 0 });
                    dialog.Commands.Add(new Windows.UI.Popups.UICommand("Cancel") { Id = 1 });


                    dialog.DefaultCommandIndex = 0;
                    dialog.CancelCommandIndex = 1;

                    uMail = "";
                    uPassword = "";

                    var result = await dialog.ShowAsync();
                }
            }
        }   
    }
}
