using Dominio.Contextos.Jogos;
using Dominio.Contextos.Usuarios;

namespace Aplicacao.Contextos.Jogos
{
    public class JogoDto
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public short Status { get; set; }
        public long TipoJogoId { get; set; }
        public long SituacaoId { get; set; }
        public long TipoPlataformaId { get; set; }

        public string TipoJogoNome { get; set; }
        public string TipoPlataformaNome { get; set; }
        public string SituacaoNome { get; set; }

        public long UsuarioId { get; set; }
        public string UsuarioNome { get; set; }
        public string Email { get; set; }
        public int QuantidadeJogosEmprestados { get; set; }

        public Jogo TransformaEmEntidade()
        {
            var jogo = new Jogo(Nome, Status, TipoJogoId, 1, TipoPlataformaId);

            return jogo;
        }

        public Jogo TransformaEmEntidadeAtualizacao()
        {
            var jogo = new Jogo(Nome, Status, TipoJogoId, 1, TipoPlataformaId);
            if (Id != 0)
                jogo.InserirId(Id);

            return jogo;
        }

    }
}
