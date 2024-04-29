using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PedroFranca.Migrations
{
    /// <inheritdoc />
    public partial class primeiraMigracao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Folhas",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    valor = table.Column<float>(type: "REAL", nullable: false),
                    quantidadeHora = table.Column<int>(type: "INTEGER", nullable: false),
                    mes = table.Column<int>(type: "INTEGER", nullable: false),
                    ano = table.Column<int>(type: "INTEGER", nullable: false),
                    salarioBruto = table.Column<float>(type: "REAL", nullable: false),
                    impostoIrrf = table.Column<float>(type: "REAL", nullable: false),
                    impostoInss = table.Column<float>(type: "REAL", nullable: false),
                    impostoFgts = table.Column<float>(type: "REAL", nullable: false),
                    salarioLiquido = table.Column<float>(type: "REAL", nullable: false),
                    funcionarioId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Folhas", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Funcionario",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    Cpf = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionario", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Folhas");

            migrationBuilder.DropTable(
                name: "Funcionario");
        }
    }
}
