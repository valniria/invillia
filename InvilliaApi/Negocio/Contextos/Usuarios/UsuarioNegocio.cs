using Dominio.Contextos.Usuarios;
using Dominio.Contextos.Usuarios.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Negocio.Contextos.Usuarios
{
    public class UsuarioNegocio : IUsuarioNegocio
    {
        private readonly IUsuarioRepositorio UsuarioRepositorio;
        public UsuarioNegocio(IUsuarioRepositorio usuarioRepositorio)
        {
            UsuarioRepositorio = usuarioRepositorio;
        }
        public async Task<List<Usuario>> ListarTodosOsUsuariosAsync()
        {
            var usuarios = await UsuarioRepositorio.ListarTodosOsUsuariosAsync();

            return usuarios;
        }

        public async Task Add(Usuario Objeto)
        {
            await UsuarioRepositorio.Add(Objeto);
        }

        public Task<List<Usuario>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Usuario> GetById(long Id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Usuario Objeto)
        {
            throw new NotImplementedException();
        }
    }
}
