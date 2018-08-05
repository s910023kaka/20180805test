using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace _20180805.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Servers",
                columns: table => new
                {
                    ServerID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    Owner = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servers", x => x.ServerID);
                });

            migrationBuilder.CreateTable(
                name: "AppProfiles",
                columns: table => new
                {
                    AppProfileID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: true),
                    ReleaseDate = table.Column<DateTime>(nullable: false),
                    Version = table.Column<string>(nullable: true),
                    Owner = table.Column<string>(nullable: true),
                    VSTS = table.Column<string>(nullable: true),
                    SqlServer = table.Column<string>(nullable: true),
                    ServerID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppProfiles", x => x.AppProfileID);
                    table.ForeignKey(
                        name: "FK_AppProfiles_Servers_ServerID",
                        column: x => x.ServerID,
                        principalTable: "Servers",
                        principalColumn: "ServerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppProfiles_ServerID",
                table: "AppProfiles",
                column: "ServerID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppProfiles");

            migrationBuilder.DropTable(
                name: "Servers");
        }
    }
}
