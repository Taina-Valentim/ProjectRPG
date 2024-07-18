using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectRPG.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class LigacaoUsuarioPersonagem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArmamentoPersonagem");

            migrationBuilder.AddColumn<string>(
                name: "UsuarioId",
                table: "Personagens",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Armas",
                type: "nvarchar(max)",
                maxLength: 10000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.CreateTable(
                name: "ArmaPersonagem",
                columns: table => new
                {
                    ArmamentosId = table.Column<int>(type: "int", nullable: false),
                    PersonagensId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArmaPersonagem", x => new { x.ArmamentosId, x.PersonagensId });
                    table.ForeignKey(
                        name: "FK_ArmaPersonagem_Armas_ArmamentosId",
                        column: x => x.ArmamentosId,
                        principalTable: "Armas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArmaPersonagem_Personagens_PersonagensId",
                        column: x => x.PersonagensId,
                        principalTable: "Personagens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Personagens_UsuarioId",
                table: "Personagens",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_ArmaPersonagem_PersonagensId",
                table: "ArmaPersonagem",
                column: "PersonagensId");

            migrationBuilder.AddForeignKey(
                name: "FK_Personagens_AspNetUsers_UsuarioId",
                table: "Personagens",
                column: "UsuarioId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personagens_AspNetUsers_UsuarioId",
                table: "Personagens");

            migrationBuilder.DropTable(
                name: "ArmaPersonagem");

            migrationBuilder.DropIndex(
                name: "IX_Personagens_UsuarioId",
                table: "Personagens");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Personagens");

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Armas",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldMaxLength: 10000);

            migrationBuilder.CreateTable(
                name: "ArmamentoPersonagem",
                columns: table => new
                {
                    ArmamentosId = table.Column<int>(type: "int", nullable: false),
                    PersonagensId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArmamentoPersonagem", x => new { x.ArmamentosId, x.PersonagensId });
                    table.ForeignKey(
                        name: "FK_ArmamentoPersonagem_Armas_ArmamentosId",
                        column: x => x.ArmamentosId,
                        principalTable: "Armas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArmamentoPersonagem_Personagens_PersonagensId",
                        column: x => x.PersonagensId,
                        principalTable: "Personagens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArmamentoPersonagem_PersonagensId",
                table: "ArmamentoPersonagem",
                column: "PersonagensId");
        }
    }
}
