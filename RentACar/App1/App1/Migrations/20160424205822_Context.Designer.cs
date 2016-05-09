using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations.Infrastructure;
using App1.RentACarBaza.Models;

namespace App1Migrations
{
    [ContextType(typeof(KorisnikUslugaDbContext))]
    partial class Context
    {
        public override string Id
        {
            get { return "20160424205822_Context"; }
        }

        public override string ProductVersion
        {
            get { return "7.0.0-beta6-13815"; }
        }

        public override void BuildTargetModel(ModelBuilder builder)
        {
            builder
                .Annotation("ProductVersion", "7.0.0-beta6-13815");

            builder.Entity("App1.RentACarBaza.Models.KorisnikUsluga", b =>
                {
                    b.Property<int>("KorisnikUslugaID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Ime");

                    b.Property<string>("Prebivaliste");

                    b.Property<string>("Prezime");

                    b.Property<bool>("Punoljetnost");

                    b.Property<bool>("ValidnaVozackaDozvola");

                    b.Key("KorisnikUslugaID");
                });
        }
    }
}