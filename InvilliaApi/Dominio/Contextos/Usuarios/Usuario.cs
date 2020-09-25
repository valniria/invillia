using Compartilhado.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Contextos.Usuarios
{
    public class Usuario : EntidadeBase
    {
        public string Nome { get; set; }
        public int QuantidadeJogosEmprestados { get; set; }
        public bool PodeTerAcessoAoSistema { get; set; }
        public bool Status { get; set; }

        public Usuario(string nome, int quantidadeJogosEmprestados, bool podeTerAcessoAoSistema, bool status)
        {
            Nome = nome;
            QuantidadeJogosEmprestados = quantidadeJogosEmprestados;
            PodeTerAcessoAoSistema = podeTerAcessoAoSistema;
            Status = status;
        }

        public override void Validar()
        {
            throw new NotImplementedException();
        }
    }
}
