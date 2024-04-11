using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectRPG.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoBanco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Personagens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Especie = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Aparencia = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    PvTotal = table.Column<int>(type: "int", nullable: false),
                    PvAtual = table.Column<int>(type: "int", nullable: false),
                    Deslocamento = table.Column<int>(type: "int", nullable: false),
                    Evasao = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personagens", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Armas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Dano = table.Column<int>(type: "int", nullable: false),
                    Alcance = table.Column<int>(type: "int", nullable: false),
                    UsaMunicao = table.Column<bool>(type: "bit", nullable: false),
                    TipoMunicao = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MunicaoMaxima = table.Column<int>(type: "int", nullable: false),
                    MunicaoAtual = table.Column<int>(type: "int", nullable: false),
                    Equipado = table.Column<bool>(type: "bit", nullable: false),
                    PersonagemId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Armas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Armas_Personagens_PersonagemId",
                        column: x => x.PersonagemId,
                        principalTable: "Personagens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Atributos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Corpo = table.Column<int>(type: "int", nullable: false),
                    Foco = table.Column<int>(type: "int", nullable: false),
                    Mente = table.Column<int>(type: "int", nullable: false),
                    Reacao = table.Column<int>(type: "int", nullable: false),
                    PersonagemId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atributos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Atributos_Personagens_PersonagemId",
                        column: x => x.PersonagemId,
                        principalTable: "Personagens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Condicoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Desnutrido = table.Column<bool>(type: "bit", nullable: false),
                    Aterrorizado = table.Column<bool>(type: "bit", nullable: false),
                    Paralisado = table.Column<bool>(type: "bit", nullable: false),
                    Envenenado = table.Column<bool>(type: "bit", nullable: false),
                    Sangrando = table.Column<bool>(type: "bit", nullable: false),
                    Queimado = table.Column<bool>(type: "bit", nullable: false),
                    Infectado = table.Column<bool>(type: "bit", nullable: false),
                    PersonagemId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Condicoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Condicoes_Personagens_PersonagemId",
                        column: x => x.PersonagemId,
                        principalTable: "Personagens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Equipamentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Equipado = table.Column<bool>(type: "bit", nullable: false),
                    PersonagemId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipamentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Equipamentos_Personagens_PersonagemId",
                        column: x => x.PersonagemId,
                        principalTable: "Personagens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Itens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    PersonagemId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Itens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Itens_Personagens_PersonagemId",
                        column: x => x.PersonagemId,
                        principalTable: "Personagens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Armas_PersonagemId",
                table: "Armas",
                column: "PersonagemId");

            migrationBuilder.CreateIndex(
                name: "IX_Atributos_PersonagemId",
                table: "Atributos",
                column: "PersonagemId");

            migrationBuilder.CreateIndex(
                name: "IX_Condicoes_PersonagemId",
                table: "Condicoes",
                column: "PersonagemId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipamentos_PersonagemId",
                table: "Equipamentos",
                column: "PersonagemId");

            migrationBuilder.CreateIndex(
                name: "IX_Itens_PersonagemId",
                table: "Itens",
                column: "PersonagemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Armas");

            migrationBuilder.DropTable(
                name: "Atributos");

            migrationBuilder.DropTable(
                name: "Condicoes");

            migrationBuilder.DropTable(
                name: "Equipamentos");

            migrationBuilder.DropTable(
                name: "Itens");

            migrationBuilder.DropTable(
                name: "Personagens");
        }
    }
}
