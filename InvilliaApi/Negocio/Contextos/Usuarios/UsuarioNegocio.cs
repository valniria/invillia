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

        public async Task<List<Usuario>> GetAll()
        {
            var usuarios = await UsuarioRepositorio.GetAll();

            return usuarios;
        }

        public async Task<Usuario> GetById(long Id)
        {
            var usuario = await UsuarioRepositorio.GetById(Id);

            return usuario;
        }

        public async Task Update(Usuario Objeto)
        {
            await UsuarioRepositorio.Update(Objeto);
        }

        public async Task<Usuario> ObterUsuarioPorIdAsync(long Id)
        {
            var usuario = await UsuarioRepositorio.ObterUsuarioPorIdAsync(Id);

            return usuario;
        }

        public async Task Delete(Usuario Objeto)
        {
            await UsuarioRepositorio.Delete(Objeto);
        }
    }
}
