﻿using System;
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
using HRentACar.HRentACar.Views;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace HRentACar
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            mainContentFrame.Navigate(typeof(Pocetna));
        }

   
        private void PushDugme_Click(object sender, RoutedEventArgs e)
        {
            MojView.IsPaneOpen = !MojView.IsPaneOpen;
        }

        private void IconsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(Pretraga.IsSelected)
            {
                mainContentFrame.Navigate(typeof(Katalog));
            }
            else if (Registracija.IsSelected)
            {
                mainContentFrame.Navigate(typeof(Registracija));
            }
            else if (Pocetna.IsSelected)
            {
                mainContentFrame.Navigate(typeof(Pocetna));
            }
            else if (iNFO.IsSelected)
            {
                mainContentFrame.Navigate(typeof(info));
            }
            else if(Prijava.IsSelected)
            {
                mainContentFrame.Navigate(typeof(Prijava));
            }
        }
    }
}