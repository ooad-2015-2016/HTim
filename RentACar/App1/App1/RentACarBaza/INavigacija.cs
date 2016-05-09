using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1.RentACarBaza
{
    interface INavigacija
    {
        void Navigate(Type sourcePage);
        void Navigate(Type sourcePage, object parameter);
        void GoBack();
    }
}
