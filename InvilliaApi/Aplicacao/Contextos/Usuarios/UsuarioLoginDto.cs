using Dominio.Contextos.Usuarios;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacao.Contextos.Usuarios
{
    public class UsuarioLoginDto
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public int QuantidadeJogosEmprestados { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public bool Status { get; set; }
        public string Token { get; set; }

        public UsuarioLoginDto(Usuario usuario, string token)
        {
            Id = usuario.Id;
            Nome = usuario.Nome;
            QuantidadeJogosEmprestados = usuario.QuantidadeJogosEmprestados;
            Email = usuario.Email;
            Status = usuario.Status;
            Token = token;
        }
    }
}
