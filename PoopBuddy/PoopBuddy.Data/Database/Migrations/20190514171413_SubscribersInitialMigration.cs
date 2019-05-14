using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PoopBuddy.Data.Database.Migrations
{
    public partial class SubscribersInitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Subscribers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExternalId = table.Column<Guid>(nullable: false),
                    Endpoint = table.Column<string>(nullable: true),
                    ExpirationTime = table.Column<DateTime>(nullable: true),
                    P256Dh = table.Column<string>(nullable: true),
                    Auth = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscribers", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Subscribers");
        }
    }
}
