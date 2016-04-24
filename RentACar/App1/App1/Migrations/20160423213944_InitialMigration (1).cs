using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Migrations.Builders;
using Microsoft.Data.Entity.Migrations.Operations;

namespace App1Migrations
{
    public partial class InitialMigration : Migration
    {
        public override void Up(MigrationBuilder migration)
        {
            migration.CreateTable(
                name: "Vozac",
                columns: table => new
                {
                    VozacID = table.Column(type: "INTEGER", nullable: false),
                    Dostupan = table.Column(type: "INTEGER", nullable: false),
                    Ime = table.Column(type: "TEXT", nullable: true),
                    Prezime = table.Column(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vozac", x => x.VozacID);
                });
        }

        public override void Down(MigrationBuilder migration)
        {
            migration.DropTable("Vozac");
        }
    }
}
