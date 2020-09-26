using Compartilhado.Entidades;
using System;

namespace Dominio.Contextos.Jogos
{
    public class Jogo : EntidadeBase
    {
        public string Nome { get; private set; }
        public bool Status { get; private set; }
        public long TipoJogoId { get; private set; }
        public long SituacaoId { get; private set; }
        public long TipoPlataformaId { get; private set; }
        public TipoJogo TipoJogo { get; private set; }
        public SituacaoJogo Situacao { get; private set; }
        public TipoPlataforma TipoPlataforma { get; private set; }

        public Jogo(string nome, bool status, long tipoJogoId, long situacaoId, long tipoPlataformaId)
        {
            Nome = nome;
            Status = status;
            TipoJogoId = tipoJogoId;
            SituacaoId = situacaoId;
            TipoPlataformaId = tipoPlataformaId;
        }




        //Propriedades de Navegação com Usuários


        public override void Validar()
        {
            throw new NotImplementedException();
        }
    }
}
