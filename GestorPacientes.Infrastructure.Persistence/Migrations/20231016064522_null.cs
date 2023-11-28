using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestorPacientes.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class @null : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LabResults_Pacients_IdPacient",
                table: "LabResults");

            migrationBuilder.AddForeignKey(
                name: "FK_LabResults_Pacients_IdPacient",
                table: "LabResults",
                column: "IdPacient",
                principalTable: "Pacients",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LabResults_Pacients_IdPacient",
                table: "LabResults");

            migrationBuilder.AddForeignKey(
                name: "FK_LabResults_Pacients_IdPacient",
                table: "LabResults",
                column: "IdPacient",
                principalTable: "Pacients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
