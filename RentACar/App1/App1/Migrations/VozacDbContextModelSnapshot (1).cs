using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations.Infrastructure;
using RentACar.RentACarBaza.Models;

namespace App1Migrations
{
    [ContextType(typeof(VozacDbContext))]
    partial class VozacDbContextModelSnapshot : ModelSnapshot
    {
        public override void BuildModel(ModelBuilder builder)
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
