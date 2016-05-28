using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using HRentACar.HRentACar.Models;

namespace HRentACar.HRentACar.ViewModels
{
    class RegistracijaViewModel : INotifyPropertyChanged
    {
        private string imeKratko;
        private RegistrovaniKlijent appUser;

        public RegistrovaniKlijent AppUser
        {
            get { return appUser; }
            set
            {
                appUser = value;
                this.OnPropertyChanged("AppUser");
            }
        }
        public string ImeKratko
        {
            get { return imeKratko; }
            set
            {
                imeKratko = value;
                this.OnPropertyChanged("ImeKratko");
            }
        }

        public event EventHandler CanExecuteChanged;
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}
