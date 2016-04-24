using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Migrations.Builders;
using Microsoft.Data.Entity.Migrations.Operations;

namespace App1Migrations
{
    public partial class Context : Migration
    {
        public override void Up(MigrationBuilder migration)
        {
            migration.CreateTable(
                name: "KorisnikUsluga",
                columns: table => new
                {
                    KorisnikUslugaID = table.Column(type: "INTEGER", nullable: false),
                    Ime = table.Column(type: "TEXT", nullable: true),
                    Prebivaliste = table.Column(type: "TEXT", nullable: true),
                    Prezime = table.Column(type: "TEXT", nullable: true),
                    Punoljetnost = table.Column(type: "INTEGER", nullable: false),
                    ValidnaVozackaDozvola = table.Column(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KorisnikUsluga", x => x.KorisnikUslugaID);
                });
        }

        public override void Down(MigrationBuilder migration)
        {
            migration.DropTable("KorisnikUsluga");
        }
    }
}
