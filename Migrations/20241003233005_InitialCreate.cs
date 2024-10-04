using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BibliotecaApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    Cpf = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Telefone = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Livros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    Autor = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    DataLan = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Descricao = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Livros", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Disponibilidade",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    status = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    IdLivro = table.Column<int>(type: "int", nullable: false),
                    IdCLiente = table.Column<int>(type: "int", nullable: false),
                    DtRetirada = table.Column<DateOnly>(type: "date", nullable: false),
                    DtDevolucao = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disponibilidade", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Disponibilidade_Clientes_IdCLiente",
                        column: x => x.IdCLiente,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Disponibilidade_Livros_IdLivro",
                        column: x => x.IdLivro,
                        principalTable: "Livros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "Id", "Cpf", "Nome", "Telefone" },
                values: new object[,]
                {
                    { 1, "002.005.755.09", "Nathalia", "3565-4002" },
                    { 2, "045.123.654.87", "Lucas", "9987-6654" },
                    { 3, "321.654.987.01", "Mariana", "3498-1122" },
                    { 4, "785.321.456.10", "Gustavo", "9876-5432" }
                });

            migrationBuilder.InsertData(
                table: "Livros",
                columns: new[] { "Id", "Autor", "DataLan", "Descricao", "Titulo" },
                values: new object[,]
                {
                    { 1, "Markus Zusak", "2005", "Filha de uma comunista perseguida pelo nazismo, Liesel é adotada por um casal alemão em troca de dinheiro. A menina logo se afeiçoa ao padrasto, Hans, que lhe ensina.", "A menina que roubava livros" },
                    { 2, "Gayle Forman", "2015", "A história de Cody, uma jovem que busca respostas após o inesperado suicídio de sua melhor amiga, Meg, desvendando segredos sobre o que pode ter levado sua amiga a tomar essa decisão.", "Eu Estive Aqui" },
                    { 3, "Stephenie Meyer", "2008", "Em um mundo onde alienígenas parasitas dominam o corpo e mente dos humanos, Melanie Stryder resiste, mesmo após ter sido capturada, lutando contra a invasão da sua própria consciência.", "A Hospedeira" },
                    { 4, "Colleen Hoover", "2014", "Tate Collins e Miles Archer se envolvem em uma relação intensa, com um acordo claro de manter as coisas apenas físicas. No entanto, sentimentos não demoram a surgir, complicando a dinâmica entre eles.", "O Lado Feio do Amor" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Disponibilidade_IdCLiente",
                table: "Disponibilidade",
                column: "IdCLiente",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Disponibilidade_IdLivro",
                table: "Disponibilidade",
                column: "IdLivro",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Disponibilidade");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Livros");
        }
    }
}
