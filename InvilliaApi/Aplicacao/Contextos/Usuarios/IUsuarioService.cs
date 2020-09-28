using Compartilhado.Comandos;
using System.Threading.Tasks;

namespace Aplicacao.Contextos.Usuarios
{
    public interface IUsuarioService
    {
        Task<IComandoResultado> ListarTodosOsUsuariosAsync();

        Task<IComandoResultado> CadastrarUsuarioAsync(UsuarioDto usuarioDto);
        
        Task<IComandoResultado> ObterUsuarioPorIdAsync(long Id);

        Task<IComandoResultado> AtualizarUsuarioAsync(UsuarioDto usuarioDto);

        Task<IComandoResultado> RemoverUsuarioAsync(UsuarioDto usuarioDto);

        Task<IComandoResultado> RealizarLoginAsync(UsuarioDto usuarioDto);
    }
}
