using Microsoft.EntityFrameworkCore.Migrations;

namespace Infraestrutura.Migrations
{
    public partial class MigrationInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SituacaoJogo",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SituacaoJogo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoJogo",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoJogo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoPlataforma",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoPlataforma", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: true),
                    QuantidadeJogosEmprestados = table.Column<int>(nullable: false),
                    PodeTerAcessoAoSistema = table.Column<bool>(nullable: false),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Jogos",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false),
                    TipoJogoId = table.Column<long>(nullable: false),
                    SituacaoId = table.Column<long>(nullable: false),
                    TipoPlataformaId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jogos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Jogos_SituacaoJogo_SituacaoId",
                        column: x => x.SituacaoId,
                        principalTable: "SituacaoJogo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Jogos_TipoJogo_TipoJogoId",
                        column: x => x.TipoJogoId,
                        principalTable: "TipoJogo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Jogos_TipoPlataforma_TipoPlataformaId",
                        column: x => x.TipoPlataformaId,
                        principalTable: "TipoPlataforma",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Jogos_SituacaoId",
                table: "Jogos",
                column: "SituacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Jogos_TipoJogoId",
                table: "Jogos",
                column: "TipoJogoId");

            migrationBuilder.CreateIndex(
                name: "IX_Jogos_TipoPlataformaId",
                table: "Jogos",
                column: "TipoPlataformaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Jogos");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "SituacaoJogo");

            migrationBuilder.DropTable(
                name: "TipoJogo");

            migrationBuilder.DropTable(
                name: "TipoPlataforma");
        }
    }
}
