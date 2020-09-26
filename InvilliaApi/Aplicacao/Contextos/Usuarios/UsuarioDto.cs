
using Dominio.Contextos.Usuarios;

namespace Aplicacao.Contextos.Usuarios
{
    public class UsuarioDto
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public int QuantidadeJogosEmprestados { get; set; }
        public bool PodeTerAcessoAoSistema { get; set; }
        public bool Status { get; set; }

        public Usuario TransformaEmEntidade()
        {
            var usuario = new Usuario(Nome, QuantidadeJogosEmprestados, PodeTerAcessoAoSistema, Status);

            return usuario;
        }
    }
}
