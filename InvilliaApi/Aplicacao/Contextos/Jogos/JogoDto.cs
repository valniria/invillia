using Aplicacao.Contextos.Jogos;
using Compartilhado.Enumeradores;
using Dominio.Contextos.Jogos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacao.Contextos.Jogos
{
    public class JogoDto
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public bool Status { get; set; }
        public long TipoJogoId { get; set; }
        public long SituacaoId { get; set; }
        public long TipoPlataformaId { get; set; }

        public string TipoJogoNome { get; set; }
        public string TipoPlataformaNome { get; set; }
        public string SituacaoNome { get; set; }

        public Jogo TransformaEmEntidade()
        {
            var jogo = new Jogo(Nome, Status, TipoJogoId, 1, TipoPlataformaId);

            return jogo;
        }
    }
}
