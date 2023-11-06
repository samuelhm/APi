using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LostArkOffice.Migrations
{
    /// <inheritdoc />
    public partial class CrearDisponibilidadesUsuarios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DisponibilidadesUsuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PropietarioId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DisponibilidadesUsuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DisponibilidadesUsuarios_AspNetUsers_PropietarioId",
                        column: x => x.PropietarioId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DisponibilidadesUsuarios_PropietarioId",
                table: "DisponibilidadesUsuarios",
                column: "PropietarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DisponibilidadesUsuarios");
        }
    }
}
