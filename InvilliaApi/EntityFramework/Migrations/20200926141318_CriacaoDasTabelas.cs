using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFramework.Migrations
{
    public partial class CriacaoDasTabelas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_SITUACAO_JOGO",
                columns: table => new
                {
                    ID_SITUACAO = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DS_SITUACAO = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_SITUACAO_JOGO", x => x.ID_SITUACAO)
                        .Annotation("SqlServer:Clustered", true);
                });

            migrationBuilder.CreateTable(
                name: "TB_TIPO_JOGO",
                columns: table => new
                {
                    ID_TIPO_JOGO = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DS_TIPO_JOGO = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_TIPO_JOGO", x => x.ID_TIPO_JOGO)
                        .Annotation("SqlServer:Clustered", true);
                });

            migrationBuilder.CreateTable(
                name: "TB_TIPO_PLATAFORMA",
                columns: table => new
                {
                    ID_PLATAFORMA = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DS_PLATAFORMA = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_TIPO_PLATAFORMA", x => x.ID_PLATAFORMA)
                        .Annotation("SqlServer:Clustered", true);
                });

            migrationBuilder.CreateTable(
                name: "TB_USUARIO",
                columns: table => new
                {
                    ID_USUARIO = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NM_NOME = table.Column<string>(nullable: false),
                    IN_QTDE_JOGOS_EMPRESTADOS = table.Column<int>(nullable: false),
                    IN_PODE_TER_ACESSO = table.Column<bool>(nullable: false),
                    IN_STATUS = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_USUARIO", x => x.ID_USUARIO)
                        .Annotation("SqlServer:Clustered", true);
                });

            migrationBuilder.CreateTable(
                name: "TB_JOGOS",
                columns: table => new
                {
                    ID_JOGO = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NM_JOGO = table.Column<string>(nullable: false),
                    IN_STATUS = table.Column<short>(nullable: false),
                    IN_TIPO_JOGO = table.Column<long>(nullable: false),
                    IN_SITUACAO = table.Column<long>(nullable: false),
                    IN_TIPO_PLATAFORMA = table.Column<long>(nullable: false),
                    ID_USUARIO = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_JOGOS", x => x.ID_JOGO)
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_TB_JOGOS_TB_SITUACAO_JOGO_IN_SITUACAO",
                        column: x => x.IN_SITUACAO,
                        principalTable: "TB_SITUACAO_JOGO",
                        principalColumn: "ID_SITUACAO");
                    table.ForeignKey(
                        name: "FK_TB_JOGOS_TB_TIPO_JOGO_IN_TIPO_JOGO",
                        column: x => x.IN_TIPO_JOGO,
                        principalTable: "TB_TIPO_JOGO",
                        principalColumn: "ID_TIPO_JOGO");
                    table.ForeignKey(
                        name: "FK_TB_JOGOS_TB_TIPO_PLATAFORMA_IN_TIPO_PLATAFORMA",
                        column: x => x.IN_TIPO_PLATAFORMA,
                        principalTable: "TB_TIPO_PLATAFORMA",
                        principalColumn: "ID_PLATAFORMA");
                    table.ForeignKey(
                        name: "FK_TB_JOGOS_TB_USUARIO_ID_USUARIO",
                        column: x => x.ID_USUARIO,
                        principalTable: "TB_USUARIO",
                        principalColumn: "ID_USUARIO");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_JOGOS_IN_SITUACAO",
                table: "TB_JOGOS",
                column: "IN_SITUACAO");

            migrationBuilder.CreateIndex(
                name: "IX_TB_JOGOS_IN_TIPO_JOGO",
                table: "TB_JOGOS",
                column: "IN_TIPO_JOGO");

            migrationBuilder.CreateIndex(
                name: "IX_TB_JOGOS_IN_TIPO_PLATAFORMA",
                table: "TB_JOGOS",
                column: "IN_TIPO_PLATAFORMA");

            migrationBuilder.CreateIndex(
                name: "IX_TB_JOGOS_ID_USUARIO",
                table: "TB_JOGOS",
                column: "ID_USUARIO");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_JOGOS");

            migrationBuilder.DropTable(
                name: "TB_SITUACAO_JOGO");

            migrationBuilder.DropTable(
                name: "TB_TIPO_JOGO");

            migrationBuilder.DropTable(
                name: "TB_TIPO_PLATAFORMA");

            migrationBuilder.DropTable(
                name: "TB_USUARIO");
        }
    }
}
