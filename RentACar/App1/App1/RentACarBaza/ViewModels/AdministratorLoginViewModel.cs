using App1.RentACarBaza.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace App1.RentACarBaza.ViewModels
{
    class AdministratorLoginViewModel
    {
        public Administrator Prijavljeni { get; set; }

        public string UnosUsername { get; set; }
        public string UnosPass { get; set; }

        public ICommand Log { get; set; }

        public INavigacija NavigationServis { get; set; }



        public AdministratorLoginViewModel()
        {
            NavigationServis = new NavigationService();
            Prijavljeni = new Administrator();

            UnosUsername = "";
            UnosPass = "";

            Log = new RelayCommand<object>(log, mozeLiSePrijaviti);
        }

        public bool mozeLiSePrijaviti(object parametar)
        {
            return true;
        }
        

        public void log(object parametar)
        {
            using (var db = new AdministratorDbContext())
            {
                Prijavljeni = db.Administratori.Where(x => x.Ime == UnosUsername && x.Sifra == UnosPass).FirstOrDefault();

                if (Prijavljeni != null)
                {
                    NavigationServis.Navigate(typeof(AdministratorView), new AdministratorViewModel(this));
                }
            }
        }
        
        }


    }


