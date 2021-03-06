﻿using Microsoft.Data.Entity;
using HRentACar.HRentACar.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace HRentACar.HRentACar.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class KorisniciListView : Page
    {

        public KorisniciListView()
        {
            this.InitializeComponent();
        }

        
        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            using (var db = new KorisnikDbContext())
            {
                listViewKorisnici.ItemsSource = db.Korisnici.ToList();
            }
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DependencyObject dep = (DependencyObject)e.OriginalSource;

            while ((dep != null) && !(dep is ListViewItem))
            {
                dep = VisualTreeHelper.GetParent(dep);
            }

            if (dep == null)
                return;

            using (var db = new KorisnikDbContext())
            {
                db.Korisnici.Remove((Korisnik)listViewKorisnici.ItemFromContainer(dep));

                db.SaveChanges();

                listViewKorisnici.ItemsSource = db.Korisnici.OrderBy(c => c.Prezime).ToList();

          
            }
        }   
            
    }
}

