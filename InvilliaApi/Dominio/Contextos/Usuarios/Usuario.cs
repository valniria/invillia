using Compartilhado.Entidades;
using Dominio.Contextos.Jogos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Contextos.Usuarios
{
    public class Usuario : EntidadeBase
    {
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }
        public int QuantidadeJogosEmprestados { get; private set; }
        public bool Status { get; private set; }
        public string Role { get; set; }
        public int TipoDeUsuario { get; set; }

        public virtual ICollection<Jogo> UsuarioComJogo { get; set; }

        public Usuario(string nome, string email, string senha, int quantidadeJogosEmprestados, bool status, int tipoDeUsuario)
        {
            Nome = nome;
            Email = email;
            Senha = senha;
            QuantidadeJogosEmprestados = quantidadeJogosEmprestados;
            Status = status;
            TipoDeUsuario = tipoDeUsuario;
            Role = tipoDeUsuario == 1 ? "Admin" : "Comum";
        }

        public void IncrementarQuantidadeDeEmprestimo()
        {
            QuantidadeJogosEmprestados++;
        }

        public void DecrementarQuantidadeDeEmprestimo()
        {
            QuantidadeJogosEmprestados--;
        }

        public void LimparASenha()
        {
            Senha = "";
        }

        public override void Validar()
        {
            throw new NotImplementedException();
        }
    }
}
