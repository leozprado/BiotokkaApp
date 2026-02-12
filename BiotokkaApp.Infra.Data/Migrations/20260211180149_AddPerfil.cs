using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BiotokkaApp.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddPerfil : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PERFIL_ID",
                table: "USUARIOS",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "PERFIS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOME = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PERFIS", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_USUARIOS_PERFIL_ID",
                table: "USUARIOS",
                column: "PERFIL_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PERFIS_NOME",
                table: "PERFIS",
                column: "NOME",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_USUARIOS_PERFIS_PERFIL_ID",
                table: "USUARIOS",
                column: "PERFIL_ID",
                principalTable: "PERFIS",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_USUARIOS_PERFIS_PERFIL_ID",
                table: "USUARIOS");

            migrationBuilder.DropTable(
                name: "PERFIS");

            migrationBuilder.DropIndex(
                name: "IX_USUARIOS_PERFIL_ID",
                table: "USUARIOS");

            migrationBuilder.DropColumn(
                name: "PERFIL_ID",
                table: "USUARIOS");
        }
    }
}
