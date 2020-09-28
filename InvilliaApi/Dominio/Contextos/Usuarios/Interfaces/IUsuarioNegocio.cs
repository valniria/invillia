using Compartilhado.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Contextos.Usuarios.Interfaces
{
    public interface IUsuarioNegocio //: INegocioBase<Usuario>
    {
        Task Add(Usuario Objeto);
        Task Update(Usuario Objeto);
        Task<Usuario> GetById(long Id);
        Task<List<Usuario>> GetAll();
        Task Delete(Usuario Objeto);


        Task<List<Usuario>> ListarTodosOsUsuariosAsync();
        Task<Usuario> ObterUsuarioPorIdAsync(long Id);
        Task<Usuario> BuscaPorEmailESenhaAsync(string Email, string Senha);

    }
}
