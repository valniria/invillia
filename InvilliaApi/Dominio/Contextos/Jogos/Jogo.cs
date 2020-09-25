using Compartilhado.Entidades;
using System;
using Aplicacao.Contextos.Jogos;
using Compartilhado.Enumeradores;

namespace Dominio.Contextos.Jogos
{
    public class Jogo : EntidadeBase
    {
        public string Nome { get; set; }

        public TipoJogo TipoJogo { get; set; }
        public bool Status { get; set; }
        public SituacaoJogo Situacao { get; set; }

        public Jogo(string nome, TipoJogo tipoJogo, bool status, SituacaoJogo situacao)
        {
            Nome = nome;
            TipoJogo = tipoJogo;
            Status = status;
            Situacao = situacao;
        }


        //Propriedades de Navegação com Usuários


        public override void Validar()
        {
            throw new NotImplementedException();
        }
    }
}
