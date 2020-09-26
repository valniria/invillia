using Compartilhado.Comandos;
using System.Threading.Tasks;

namespace Aplicacao.Contextos.Usuarios
{
    public interface IUsuarioService
    {
        Task<IComandoResultado> ListarTodosOsUsuariosAsync();

        Task<IComandoResultado> CadastrarUsuarioAsync(UsuarioDto usuarioDto);
    }
}
