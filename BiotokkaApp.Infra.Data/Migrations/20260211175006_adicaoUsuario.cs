using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BiotokkaApp.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class adicaoUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VENDAS_CLIENTES_ClienteId1",
                table: "VENDAS");

            migrationBuilder.DropForeignKey(
                name: "FK_VENDAS_PRODUTOS_ProdutoId1",
                table: "VENDAS");

            migrationBuilder.DropIndex(
                name: "IX_VENDAS_ClienteId1",
                table: "VENDAS");

            migrationBuilder.DropIndex(
                name: "IX_VENDAS_ProdutoId1",
                table: "VENDAS");

            migrationBuilder.DropColumn(
                name: "ClienteId1",
                table: "VENDAS");

            migrationBuilder.DropColumn(
                name: "ProdutoId1",
                table: "VENDAS");

            migrationBuilder.AlterColumn<string>(
                name: "DESCRICAO",
                table: "CATEGORIAS",
                type: "VARCHAR(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "VARCHAR(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "USUARIOS",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NOME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EMAIL = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SENHA = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DATAHORACRIACAO = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USUARIOS", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_USUARIOS_EMAIL",
                table: "USUARIOS",
                column: "EMAIL",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "USUARIOS");

            migrationBuilder.AddColumn<int>(
                name: "ClienteId1",
                table: "VENDAS",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProdutoId1",
                table: "VENDAS",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DESCRICAO",
                table: "CATEGORIAS",
                type: "VARCHAR(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(500)",
                oldMaxLength: 500);

            migrationBuilder.CreateIndex(
                name: "IX_VENDAS_ClienteId1",
                table: "VENDAS",
                column: "ClienteId1");

            migrationBuilder.CreateIndex(
                name: "IX_VENDAS_ProdutoId1",
                table: "VENDAS",
                column: "ProdutoId1");

            migrationBuilder.AddForeignKey(
                name: "FK_VENDAS_CLIENTES_ClienteId1",
                table: "VENDAS",
                column: "ClienteId1",
                principalTable: "CLIENTES",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_VENDAS_PRODUTOS_ProdutoId1",
                table: "VENDAS",
                column: "ProdutoId1",
                principalTable: "PRODUTOS",
                principalColumn: "ID");
        }
    }
}
