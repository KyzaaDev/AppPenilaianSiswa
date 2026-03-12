using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppPenilaianSiswa.Migrations
{
    /// <inheritdoc />
    public partial class NambahinTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Jurusan",
                table: "Siswas");

            migrationBuilder.DropColumn(
                name: "Kelas",
                table: "Siswas");

            migrationBuilder.DropColumn(
                name: "NamaGuru",
                table: "Mapels");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Users",
                newName: "OperatorId");

            migrationBuilder.RenameColumn(
                name: "nilai",
                table: "Nilais",
                newName: "OperatorId");

            migrationBuilder.AddColumn<int>(
                name: "KelasId",
                table: "Siswas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NilaiSiswa",
                table: "Nilais",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GuruId",
                table: "Mapels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Gurus",
                columns: table => new
                {
                    GuruId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GuruName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gurus", x => x.GuruId);
                });

            migrationBuilder.CreateTable(
                name: "Jurusans",
                columns: table => new
                {
                    JurusanId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NamaJurusan = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jurusans", x => x.JurusanId);
                });

            migrationBuilder.CreateTable(
                name: "Kelas",
                columns: table => new
                {
                    KelasId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JurusanId = table.Column<int>(type: "int", nullable: false),
                    NamaKelas = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kelas", x => x.KelasId);
                    table.ForeignKey(
                        name: "FK_Kelas_Jurusans_JurusanId",
                        column: x => x.JurusanId,
                        principalTable: "Jurusans",
                        principalColumn: "JurusanId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Siswas_KelasId",
                table: "Siswas",
                column: "KelasId");

            migrationBuilder.CreateIndex(
                name: "IX_Nilais_OperatorId",
                table: "Nilais",
                column: "OperatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Mapels_GuruId",
                table: "Mapels",
                column: "GuruId");

            migrationBuilder.CreateIndex(
                name: "IX_Kelas_JurusanId",
                table: "Kelas",
                column: "JurusanId");

            migrationBuilder.AddForeignKey(
                name: "FK_Mapels_Gurus_GuruId",
                table: "Mapels",
                column: "GuruId",
                principalTable: "Gurus",
                principalColumn: "GuruId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Nilais_Users_OperatorId",
                table: "Nilais",
                column: "OperatorId",
                principalTable: "Users",
                principalColumn: "OperatorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Siswas_Kelas_KelasId",
                table: "Siswas",
                column: "KelasId",
                principalTable: "Kelas",
                principalColumn: "KelasId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mapels_Gurus_GuruId",
                table: "Mapels");

            migrationBuilder.DropForeignKey(
                name: "FK_Nilais_Users_OperatorId",
                table: "Nilais");

            migrationBuilder.DropForeignKey(
                name: "FK_Siswas_Kelas_KelasId",
                table: "Siswas");

            migrationBuilder.DropTable(
                name: "Gurus");

            migrationBuilder.DropTable(
                name: "Kelas");

            migrationBuilder.DropTable(
                name: "Jurusans");

            migrationBuilder.DropIndex(
                name: "IX_Siswas_KelasId",
                table: "Siswas");

            migrationBuilder.DropIndex(
                name: "IX_Nilais_OperatorId",
                table: "Nilais");

            migrationBuilder.DropIndex(
                name: "IX_Mapels_GuruId",
                table: "Mapels");

            migrationBuilder.DropColumn(
                name: "KelasId",
                table: "Siswas");

            migrationBuilder.DropColumn(
                name: "NilaiSiswa",
                table: "Nilais");

            migrationBuilder.DropColumn(
                name: "GuruId",
                table: "Mapels");

            migrationBuilder.RenameColumn(
                name: "OperatorId",
                table: "Users",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "OperatorId",
                table: "Nilais",
                newName: "nilai");

            migrationBuilder.AddColumn<string>(
                name: "Jurusan",
                table: "Siswas",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Kelas",
                table: "Siswas",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NamaGuru",
                table: "Mapels",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }
    }
}
