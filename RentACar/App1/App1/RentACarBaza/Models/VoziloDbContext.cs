using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace App1.RentACarBaza.Models
{
    class VoziloDbContext:DbContext
    {
        private DbSet<Vozilo> vozila;

        internal DbSet<Vozilo> Vozila
        {
            get
            {
                return vozila;
            }

            set
            {
                vozila = value;
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string databaseFilePath = "Ooadbaza.db";

            try
            {
                databaseFilePath = Path.Combine(ApplicationData.Current.LocalFolder.Path, databaseFilePath);
            }

            catch (InvalidOperationException) { }

            //Sqlite baza            

            optionsBuilder.UseSqlite($"Data source={databaseFilePath}");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.Entity<Restoran>().Property(p => p.Slika).HasColumnType("image");
        }
    }
}
