using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace App1.RentACarBaza.ViewModels
{
    class AdministratorViewModel
    {
        private AdministratorLoginViewModel administratorLoginViewModel;

        public ICommand Klijenti { get; set; }
        public ICommand Zaposlenici { get; set; }
        public ICommand Vozila { get; set; }
        public INavigacija NavigationServis { get; set; }

        public AdministratorLogin Parent { get; set; }

        public AdministratorViewModel(AdministratorLogin parent)
        {

            NavigationServis = new NavigationService();

            Klijenti = new RelayCommand<object>(klijenti, mozeLiKlijentaNaci);
            Zaposlenici = new RelayCommand<object>(zaposlenici, mozeLiSeZaposlenikaNaci);
            Vozila = new RelayCommand<object>(vozila, mozeLiVoziloNaci);

            this.Parent = parent;
        }

        public AdministratorViewModel(AdministratorLoginViewModel administratorLoginViewModel)
        {
            this.administratorLoginViewModel = administratorLoginViewModel;
        }

        public void klijenti(object parametar)
        {


        }

        public void zaposlenici(object parametar)
        {

        }

        public void vozila(object parametar)
        {

        }

        public bool mozeLiKlijentaNaci(object parametar)
        {
            return true;
        }
        public bool mozeLiSeZaposlenikaNaci(object parametar)
        {
            return true;
        }
        public bool mozeLiVoziloNaci(object parametar)
        {
            return true;
        }

    }
}
