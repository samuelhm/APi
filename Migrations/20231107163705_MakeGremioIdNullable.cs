using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LostArkOffice.Migrations
{
    /// <inheritdoc />
    public partial class MakeGremioIdNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GremioId",
                table: "AspNetUsers",
                type: "int",
                nullable: true,
                defaultValue: null);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_GremioId",
                table: "AspNetUsers",
                column: "GremioId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Gremios_GremioId",
                table: "AspNetUsers",
                column: "GremioId",
                principalTable: "Gremios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Gremios_GremioId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_GremioId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "GremioId",
                table: "AspNetUsers");
        }
    }
}
