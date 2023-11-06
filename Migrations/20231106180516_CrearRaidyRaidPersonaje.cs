using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LostArkOffice.Migrations
{
    /// <inheritdoc />
    public partial class CrearRaidyRaidPersonaje : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonajesRaid_Personajes_PersonajeId",
                table: "PersonajesRaid");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonajesRaid_TiposDeRaid_TipoDeRaidId",
                table: "PersonajesRaid");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonajesRaid",
                table: "PersonajesRaid");

            migrationBuilder.RenameTable(
                name: "PersonajesRaid",
                newName: "PersonajesRaids");

            migrationBuilder.RenameIndex(
                name: "IX_PersonajesRaid_TipoDeRaidId",
                table: "PersonajesRaids",
                newName: "IX_PersonajesRaids_TipoDeRaidId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonajesRaids",
                table: "PersonajesRaids",
                columns: new[] { "PersonajeId", "TipoDeRaidId" });

            migrationBuilder.CreateTable(
                name: "Raids",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Duration = table.Column<TimeSpan>(type: "time", nullable: false),
                    Finished = table.Column<bool>(type: "bit", nullable: false),
                    TipoDeRaidId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Raids", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Raids_TiposDeRaid_TipoDeRaidId",
                        column: x => x.TipoDeRaidId,
                        principalTable: "TiposDeRaid",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RaidsPersonajes",
                columns: table => new
                {
                    RaidId = table.Column<int>(type: "int", nullable: false),
                    PersonajeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RaidsPersonajes", x => new { x.RaidId, x.PersonajeId });
                    table.ForeignKey(
                        name: "FK_RaidsPersonajes_Personajes_PersonajeId",
                        column: x => x.PersonajeId,
                        principalTable: "Personajes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RaidsPersonajes_Raids_RaidId",
                        column: x => x.RaidId,
                        principalTable: "Raids",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Raids_TipoDeRaidId",
                table: "Raids",
                column: "TipoDeRaidId");

            migrationBuilder.CreateIndex(
                name: "IX_RaidsPersonajes_PersonajeId",
                table: "RaidsPersonajes",
                column: "PersonajeId");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonajesRaids_Personajes_PersonajeId",
                table: "PersonajesRaids",
                column: "PersonajeId",
                principalTable: "Personajes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonajesRaids_TiposDeRaid_TipoDeRaidId",
                table: "PersonajesRaids",
                column: "TipoDeRaidId",
                principalTable: "TiposDeRaid",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonajesRaids_Personajes_PersonajeId",
                table: "PersonajesRaids");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonajesRaids_TiposDeRaid_TipoDeRaidId",
                table: "PersonajesRaids");

            migrationBuilder.DropTable(
                name: "RaidsPersonajes");

            migrationBuilder.DropTable(
                name: "Raids");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonajesRaids",
                table: "PersonajesRaids");

            migrationBuilder.RenameTable(
                name: "PersonajesRaids",
                newName: "PersonajesRaid");

            migrationBuilder.RenameIndex(
                name: "IX_PersonajesRaids_TipoDeRaidId",
                table: "PersonajesRaid",
                newName: "IX_PersonajesRaid_TipoDeRaidId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonajesRaid",
                table: "PersonajesRaid",
                columns: new[] { "PersonajeId", "TipoDeRaidId" });

            migrationBuilder.AddForeignKey(
                name: "FK_PersonajesRaid_Personajes_PersonajeId",
                table: "PersonajesRaid",
                column: "PersonajeId",
                principalTable: "Personajes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonajesRaid_TiposDeRaid_TipoDeRaidId",
                table: "PersonajesRaid",
                column: "TipoDeRaidId",
                principalTable: "TiposDeRaid",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
