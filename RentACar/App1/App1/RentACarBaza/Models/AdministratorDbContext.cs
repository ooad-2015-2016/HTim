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
    class AdministratorDbContext:DbContext
    {
        private DbSet<Administrator> administratori;
        internal DbSet<Administrator> Administratori
        {
            get
            {
                return administratori;
            }
            set
            {
                administratori = value;
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
            optionsBuilder.UseSqlite($"Data source={databaseFilePath}");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}

