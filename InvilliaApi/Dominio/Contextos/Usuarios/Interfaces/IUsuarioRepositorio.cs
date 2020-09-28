using Compartilhado.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dominio.Contextos.Usuarios.Interfaces
{
    public interface IUsuarioRepositorio : IRepositorioBase<Usuario>
    {
        Task<List<Usuario>> ListarTodosOsUsuariosAsync();
        Task<Usuario> ObterUsuarioPorIdAsync(long Id);
        Task<Usuario> BuscaPorEmailESenhaAsync(string email, string senha);
    }
}
