using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class conexao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mensagem_Chat_ChatId",
                table: "Mensagem");

            migrationBuilder.DropForeignKey(
                name: "FK_Mensagem_Personagem_ToPersonagemId",
                table: "Mensagem");

            migrationBuilder.DropTable(
                name: "Chat");

            migrationBuilder.DropIndex(
                name: "IX_Mensagem_ChatId",
                table: "Mensagem");

            migrationBuilder.DropColumn(
                name: "ChatId",
                table: "Mensagem");

            migrationBuilder.RenameColumn(
                name: "ToPersonagemId",
                table: "Mensagem",
                newName: "ToGrupoId");

            migrationBuilder.RenameIndex(
                name: "IX_Mensagem_ToPersonagemId",
                table: "Mensagem",
                newName: "IX_Mensagem_ToGrupoId");

            migrationBuilder.CreateTable(
                name: "ConexaoPersonagem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonagemId = table.Column<int>(type: "int", nullable: false),
                    Conexao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConexaoPersonagem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConexaoPersonagem_Personagem_PersonagemId",
                        column: x => x.PersonagemId,
                        principalTable: "Personagem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Grupo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrimeiraPersonagemId = table.Column<int>(type: "int", nullable: false),
                    SegundaPersonagemId = table.Column<int>(type: "int", nullable: false),
                    EstadoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grupo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Grupo_Estado_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "Estado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Grupo_Personagem_PrimeiraPersonagemId",
                        column: x => x.PrimeiraPersonagemId,
                        principalTable: "Personagem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Grupo_Personagem_SegundaPersonagemId",
                        column: x => x.SegundaPersonagemId,
                        principalTable: "Personagem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConexaoPersonagem_PersonagemId",
                table: "ConexaoPersonagem",
                column: "PersonagemId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Grupo_EstadoId",
                table: "Grupo",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Grupo_PrimeiraPersonagemId",
                table: "Grupo",
                column: "PrimeiraPersonagemId");

            migrationBuilder.CreateIndex(
                name: "IX_Grupo_SegundaPersonagemId",
                table: "Grupo",
                column: "SegundaPersonagemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Mensagem_Grupo_ToGrupoId",
                table: "Mensagem",
                column: "ToGrupoId",
                principalTable: "Grupo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mensagem_Grupo_ToGrupoId",
                table: "Mensagem");

            migrationBuilder.DropTable(
                name: "ConexaoPersonagem");

            migrationBuilder.DropTable(
                name: "Grupo");

            migrationBuilder.RenameColumn(
                name: "ToGrupoId",
                table: "Mensagem",
                newName: "ToPersonagemId");

            migrationBuilder.RenameIndex(
                name: "IX_Mensagem_ToGrupoId",
                table: "Mensagem",
                newName: "IX_Mensagem_ToPersonagemId");

            migrationBuilder.AddColumn<int>(
                name: "ChatId",
                table: "Mensagem",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Chat",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstadoId = table.Column<int>(type: "int", nullable: false),
                    PrimeiraPersonagemId = table.Column<int>(type: "int", nullable: false),
                    SegundaPersonagemId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chat", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Chat_Estado_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "Estado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Chat_Personagem_PrimeiraPersonagemId",
                        column: x => x.PrimeiraPersonagemId,
                        principalTable: "Personagem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Chat_Personagem_SegundaPersonagemId",
                        column: x => x.SegundaPersonagemId,
                        principalTable: "Personagem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Mensagem_ChatId",
                table: "Mensagem",
                column: "ChatId");

            migrationBuilder.CreateIndex(
                name: "IX_Chat_EstadoId",
                table: "Chat",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Chat_PrimeiraPersonagemId",
                table: "Chat",
                column: "PrimeiraPersonagemId");

            migrationBuilder.CreateIndex(
                name: "IX_Chat_SegundaPersonagemId",
                table: "Chat",
                column: "SegundaPersonagemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Mensagem_Chat_ChatId",
                table: "Mensagem",
                column: "ChatId",
                principalTable: "Chat",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Mensagem_Personagem_ToPersonagemId",
                table: "Mensagem",
                column: "ToPersonagemId",
                principalTable: "Personagem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
