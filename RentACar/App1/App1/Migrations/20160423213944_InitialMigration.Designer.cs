using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations.Infrastructure;
using RentACar.RentACarBaza.Models;

namespace App1Migrations
{
    [ContextType(typeof(VozacDbContext))]
    partial class InitialMigration
    {
        public override string Id
        {
            get { return "20160423213944_InitialMigration"; }
        }

        public override string ProductVersion
        {
            get { return "7.0.0-beta6-13815"; }
        }

        public override void BuildTargetModel(ModelBuilder builder)
        {
            builder
                .Annotation("ProductVersion", "7.0.0-beta6-13815");

            builder.Entity("RentACar.RentACarBaza.Models.Vozac", b =>
                {
                    b.Property<int>("VozacID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Dostupan");

                    b.Property<string>("Ime");

                    b.Property<string>("Prezime");

                    b.Key("VozacID");
                });
        }
    }
}
