using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PoopBuddy.Data.Database.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Poopings",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExternalId = table.Column<Guid>(nullable: false),
                    Author = table.Column<string>(nullable: true),
                    Duration = table.Column<TimeSpan>(nullable: false),
                    WagePerHour = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Poopings", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Poopings");
        }
    }
}
