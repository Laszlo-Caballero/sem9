using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sem9.Migrations
{
    /// <inheritdoc />
    public partial class muchos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__TESIS__idEstudia__3D5E1FD2",
                table: "TESIS");

            migrationBuilder.DropIndex(
                name: "IX_TESIS_idEstudiante",
                table: "TESIS");

            migrationBuilder.DropColumn(
                name: "idEstudiante",
                table: "TESIS");

            migrationBuilder.AlterColumn<DateTime>(
                name: "fechaInicio",
                table: "TESIS",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateOnly),
                oldType: "date",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateOnly>(
                name: "fechaInicio",
                table: "TESIS",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "idEstudiante",
                table: "TESIS",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TESIS_idEstudiante",
                table: "TESIS",
                column: "idEstudiante");

            migrationBuilder.AddForeignKey(
                name: "FK__TESIS__idEstudia__3D5E1FD2",
                table: "TESIS",
                column: "idEstudiante",
                principalTable: "ESTUDIANTE",
                principalColumn: "idEstudiante");
        }
    }
}
