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


        public async Task<List<Usuario>> ListarTodosOsUsuariosAsync()
        {
            var usuarios = await contexto.Usuarios
                .Include(u => u.UsuarioComJogo)
                .ToListAsync();

            return usuarios;
        }
    }
}
