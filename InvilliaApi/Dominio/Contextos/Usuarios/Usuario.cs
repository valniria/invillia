using Compartilhado.Entidades;
using Dominio.Contextos.Jogos;
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

        public virtual ICollection<Jogo> UsuarioComJogo { get; set; }

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
