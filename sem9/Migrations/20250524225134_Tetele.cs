using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sem9.Migrations
{
    /// <inheritdoc />
    public partial class Tetele : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "titulo",
                table: "TESIS",
                type: "varchar(200)",
                unicode: false,
                maxLength: 200,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "titulo",
                table: "TESIS");
        }
    }
}
