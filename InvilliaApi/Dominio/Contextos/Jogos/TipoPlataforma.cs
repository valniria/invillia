using Compartilhado.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Contextos.Jogos
{
    public class TipoPlataforma : EntidadeBase
    {
        public string Descricao { get; set; }

        public virtual ICollection<Jogo> TipoDePlataforma { get; set; }

        public override void Validar()
        {
            throw new NotImplementedException();
        }
    }
}
