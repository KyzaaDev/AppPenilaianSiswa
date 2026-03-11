using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppPenilaianSiswa.Migrations
{
    /// <inheritdoc />
    public partial class AddingSiswaPicture : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SiswaPicture",
                table: "Siswas",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SiswaPicture",
                table: "Siswas");
        }
    }
}
