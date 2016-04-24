using Microsoft.Data.Entity;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace RentACar.RentACarBaza.Models
{
    class VozacDbContext : DbContext
    {
        private DbSet<Vozac> vozaci;

        internal DbSet<Vozac> Vozaci
        {
            get
            {
                return vozaci;
            }

            set
            {
                vozaci = value;
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
