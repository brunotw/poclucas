using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace POCProjectAPI.Infra.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "POCAPI_Pessoas",
                columns: table => new
                {
                    PessoaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    Idade = table.Column<int>(type: "int", nullable: false),
                    Sexo = table.Column<string>(type: "varchar(9)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_POCAPI_Pessoas", x => x.PessoaId);
                });

            migrationBuilder.CreateTable(
                name: "POCAPI_Contatos",
                columns: table => new
                {
                    ContatoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    Conteudo = table.Column<string>(type: "varchar(80)", nullable: false),
                    PessoaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_POCAPI_Contatos", x => x.ContatoId);
                    table.ForeignKey(
                        name: "FK_POCAPI_Contatos_POCAPI_Pessoas_PessoaId",
                        column: x => x.PessoaId,
                        principalTable: "POCAPI_Pessoas",
                        principalColumn: "PessoaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_POCAPI_Contatos_PessoaId",
                table: "POCAPI_Contatos",
                column: "PessoaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "POCAPI_Contatos");

            migrationBuilder.DropTable(
                name: "POCAPI_Pessoas");
        }
    }
}
