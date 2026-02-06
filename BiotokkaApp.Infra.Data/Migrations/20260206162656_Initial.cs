using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BiotokkaApp.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CATEGORIAS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOME = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    DESCRICAO = table.Column<string>(type: "VARCHAR(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CATEGORIAS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CLIENTES",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOME_COMPLETO = table.Column<string>(type: "VARCHAR(200)", maxLength: 200, nullable: false),
                    CPF = table.Column<string>(type: "VARCHAR(11)", maxLength: 11, nullable: false),
                    DATA_NASCIMENTO = table.Column<DateTime>(type: "DATE", nullable: false),
                    ENDERECO = table.Column<string>(type: "VARCHAR(300)", maxLength: 300, nullable: false),
                    TELEFONE = table.Column<string>(type: "VARCHAR(15)", maxLength: 15, nullable: false),
                    EMAIL = table.Column<string>(type: "VARCHAR(150)", maxLength: 150, nullable: false),
                    DATA_CADASTRO = table.Column<DateTime>(type: "DATETIME", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CLIENTES", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PRODUTOS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CategoriaId = table.Column<int>(type: "int", nullable: false),
                    CUSTO = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    PRECO_VENDA = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    DATA_CADASTRO = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUTOS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PRODUTOS_CATEGORIAS_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "CATEGORIAS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VENDAS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CLIENTE_ID = table.Column<int>(type: "int", nullable: false),
                    PRODUTO_ID = table.Column<int>(type: "int", nullable: false),
                    QUANTIDADE = table.Column<int>(type: "int", nullable: false),
                    PRECO_UNITARIO = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    VALOR_TOTAL = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    DataVenda = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FORMA_PAGAMENTO = table.Column<int>(type: "int", nullable: false),
                    OBSERVACOES = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    ClienteId1 = table.Column<int>(type: "int", nullable: true),
                    ProdutoId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VENDAS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_VENDAS_CLIENTES_CLIENTE_ID",
                        column: x => x.CLIENTE_ID,
                        principalTable: "CLIENTES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VENDAS_CLIENTES_ClienteId1",
                        column: x => x.ClienteId1,
                        principalTable: "CLIENTES",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_VENDAS_PRODUTOS_PRODUTO_ID",
                        column: x => x.PRODUTO_ID,
                        principalTable: "PRODUTOS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VENDAS_PRODUTOS_ProdutoId1",
                        column: x => x.ProdutoId1,
                        principalTable: "PRODUTOS",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_Cpf",
                table: "CLIENTES",
                column: "CPF",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_Email",
                table: "CLIENTES",
                column: "EMAIL");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUTOS_CategoriaId",
                table: "PRODUTOS",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_VENDAS_CLIENTE_ID",
                table: "VENDAS",
                column: "CLIENTE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_VENDAS_ClienteId1",
                table: "VENDAS",
                column: "ClienteId1");

            migrationBuilder.CreateIndex(
                name: "IX_VENDAS_PRODUTO_ID",
                table: "VENDAS",
                column: "PRODUTO_ID");

            migrationBuilder.CreateIndex(
                name: "IX_VENDAS_ProdutoId1",
                table: "VENDAS",
                column: "ProdutoId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VENDAS");

            migrationBuilder.DropTable(
                name: "CLIENTES");

            migrationBuilder.DropTable(
                name: "PRODUTOS");

            migrationBuilder.DropTable(
                name: "CATEGORIAS");
        }
    }
}
