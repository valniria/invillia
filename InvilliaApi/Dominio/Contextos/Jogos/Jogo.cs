using Compartilhado.Entidades;
using Dominio.Contextos.Usuarios;
using System;

namespace Dominio.Contextos.Jogos
{
    public class Jogo : EntidadeBase
    {
        public string Nome { get; private set; }
        public short Status { get; private set; }
        public long TipoJogoId { get; private set; }
        public long SituacaoId { get; private set; }
        public long TipoPlataformaId { get; private set; }
        public long UsuarioId { get; private set; }
        public virtual TipoJogo TipoJogo { get; set; }
        public virtual SituacaoJogo Situacao { get; set; }
        public virtual TipoPlataforma TipoPlataforma { get; set; }
        public virtual Usuario UsuarioQueEstaComOJogo { get; set; }


        public Jogo(string nome, short status, long tipoJogoId, long situacaoId, long tipoPlataformaId)
        {
            Nome = nome;
            Status = status;
            TipoJogoId = tipoJogoId;
            SituacaoId = situacaoId;
            TipoPlataformaId = tipoPlataformaId;
            UsuarioId = 1;
        }

        public void EmprestarJogo(long usuarioId)
        {
            UsuarioId = usuarioId;
            SituacaoId = 2;
        }

        public void DevolverJogo()
        {
            UsuarioId = 1; //Admin
            SituacaoId = 1;
        }

        public override void Validar()
        {
            throw new NotImplementedException();
        }
    }
}
