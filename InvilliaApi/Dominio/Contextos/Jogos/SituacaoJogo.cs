using Compartilhado.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Contextos.Jogos
{
    public class SituacaoJogo : EntidadeBase
    {
        public string Descricao { get; set; }

        public virtual ICollection<Jogo> SituacaoDeJogo { get; set; }

        public override void Validar()
        {
            throw new NotImplementedException();
        }
    }
}
