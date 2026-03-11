using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppPenilaianSiswa.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Mapels",
                columns: table => new
                {
                    MapelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NamaMapel = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NamaGuru = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mapels", x => x.MapelId);
                });

            migrationBuilder.CreateTable(
                name: "Siswas",
                columns: table => new
                {
                    SiswaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nisn = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    NamaSiswa = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Kelas = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Jurusan = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Siswas", x => x.SiswaId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Nama = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Nilais",
                columns: table => new
                {
                    NilaiId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SiswaId = table.Column<int>(type: "int", nullable: false),
                    MapelId = table.Column<int>(type: "int", nullable: false),
                    nilai = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nilais", x => x.NilaiId);
                    table.ForeignKey(
                        name: "FK_Nilais_Mapels_MapelId",
                        column: x => x.MapelId,
                        principalTable: "Mapels",
                        principalColumn: "MapelId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Nilais_Siswas_SiswaId",
                        column: x => x.SiswaId,
                        principalTable: "Siswas",
                        principalColumn: "SiswaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Nilais_MapelId",
                table: "Nilais",
                column: "MapelId");

            migrationBuilder.CreateIndex(
                name: "IX_Nilais_SiswaId",
                table: "Nilais",
                column: "SiswaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Nilais");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Mapels");

            migrationBuilder.DropTable(
                name: "Siswas");
        }
    }
}
