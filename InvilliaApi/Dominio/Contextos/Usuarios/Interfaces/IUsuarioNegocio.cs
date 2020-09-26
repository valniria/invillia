using Compartilhado.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Contextos.Usuarios.Interfaces
{
    public interface IUsuarioNegocio : INegocioBase<Usuario>
    {
        Task<List<Usuario>> ListarTodosOsUsuariosAsync();
    }
}
