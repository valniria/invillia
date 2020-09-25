using System;
using System.Collections.Generic;
using System.Text;

namespace Compartilhado.Entidades
{
    public abstract class EntidadeBase
    {
        public long Id { get; set; }


        public void InserirId(long id)
            => Id = id;


        public abstract void Validar();
    }
}
