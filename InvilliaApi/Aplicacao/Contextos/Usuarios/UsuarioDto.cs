
using Dominio.Contextos.Usuarios;
using Compartilhado.Validacoes;

namespace Aplicacao.Contextos.Usuarios
{
    public class UsuarioDto
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public int QuantidadeJogosEmprestados { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public bool Status { get; set; }
        public int TipoDeUsuario { get; set; }

        public Usuario TransformaEmEntidade()
        {
            var usuario = new Usuario(Nome, Email, Senha, QuantidadeJogosEmprestados, Status, TipoDeUsuario);
            if(Id != 0)
            {
                usuario.InserirId(Id);
            }
            return usuario;
        }

        public void PrepararSenha()
        {
            Senha = Validacoes.EncriptarSenha(Senha);
        }
    }
}
