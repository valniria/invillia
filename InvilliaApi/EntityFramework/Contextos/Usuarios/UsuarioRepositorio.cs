using Dominio.Contextos.Usuarios;
using Dominio.Contextos.Usuarios.Interfaces;
using EntityFramework.Configuracao;
using Infraestrutura.Repositorio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Contextos.Usuarios
{
    public class UsuarioRepositorio : RepositorioBase<Usuario>, IUsuarioRepositorio
    {
        private readonly ContextoBase contexto;

        public UsuarioRepositorio(ContextoBase contexto)
            => this.contexto = contexto;

        public async Task<Usuario> BuscaPorEmailESenhaAsync(string email, string senha)
        {
            var usuario = await contexto.Usuarios
                .FirstOrDefaultAsync(u => u.Email == email
                                    && u.Senha == senha);

            return usuario;
        }

        public async Task<List<Usuario>> ListarTodosOsUsuariosAsync()
        {
            var usuarios = await contexto.Usuarios
                .Include(u => u.UsuarioComJogo)
                .ToListAsync();

            return usuarios;
        }

        public async Task<Usuario> ObterUsuarioPorIdAsync(long Id)
        {
            var usuario = await contexto.Usuarios
                .Include(u => u.UsuarioComJogo)
                .ThenInclude(j => j)
                .FirstOrDefaultAsync(u => u.Id == Id);

            return usuario;
        }


    }
}
