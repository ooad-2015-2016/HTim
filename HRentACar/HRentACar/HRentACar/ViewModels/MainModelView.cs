using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRentACar.HRentACar.ViewModels
{
    class MainModelView: INotifyPropertyChanged
    {
        public string Logovani { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        MainModelView()
        {
            Logovani = App.Mail;
            NotifyPropertyChanged("Logovani");
        }
    }
}
