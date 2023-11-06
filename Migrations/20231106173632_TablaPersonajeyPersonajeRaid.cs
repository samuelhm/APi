using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LostArkOffice.Migrations
{
    /// <inheritdoc />
    public partial class TablaPersonajeyPersonajeRaid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Personajes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ItemLevel = table.Column<int>(type: "int", nullable: false),
                    Habilidad = table.Column<short>(type: "smallint", nullable: true),
                    ClaseDePersonajeId = table.Column<int>(type: "int", nullable: false),
                    PropietarioId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personajes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Personajes_AspNetUsers_PropietarioId",
                        column: x => x.PropietarioId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Personajes_ClasesDePersonaje_ClaseDePersonajeId",
                        column: x => x.ClaseDePersonajeId,
                        principalTable: "ClasesDePersonaje",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonajesRaid",
                columns: table => new
                {
                    PersonajeId = table.Column<int>(type: "int", nullable: false),
                    TipoDeRaidId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonajesRaid", x => new { x.PersonajeId, x.TipoDeRaidId });
                    table.ForeignKey(
                        name: "FK_PersonajesRaid_Personajes_PersonajeId",
                        column: x => x.PersonajeId,
                        principalTable: "Personajes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonajesRaid_TiposDeRaid_TipoDeRaidId",
                        column: x => x.TipoDeRaidId,
                        principalTable: "TiposDeRaid",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Personajes_ClaseDePersonajeId",
                table: "Personajes",
                column: "ClaseDePersonajeId");

            migrationBuilder.CreateIndex(
                name: "IX_Personajes_PropietarioId",
                table: "Personajes",
                column: "PropietarioId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonajesRaid_TipoDeRaidId",
                table: "PersonajesRaid",
                column: "TipoDeRaidId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonajesRaid");

            migrationBuilder.DropTable(
                name: "Personajes");
        }
    }
}
