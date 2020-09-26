using Aplicacao.Contextos.Usuarios;
using Compartilhado.Comandos;
using Dominio.Contextos.Usuarios.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AplicacaoService.Contextos.Usuarios
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioNegocio UsuarioNegocio;

        public UsuarioService(IUsuarioNegocio usuarioNegocio)
        {
            UsuarioNegocio = usuarioNegocio;
        }

        public async Task<IComandoResultado> CadastrarUsuarioAsync(UsuarioDto usuarioDto)
        {
            try
            {
                var usuario = usuarioDto.TransformaEmEntidade();

                await UsuarioNegocio.Add(usuario);

                return new ComandoResultado(true, "Efetuado com sucesso.");
            }
            catch (Exception ex)
            {
                return new ComandoResultado(true, ex.ToString());
            }
        }

        public async Task<IComandoResultado> ListarTodosOsUsuariosAsync()
        {
            var usuarios = await UsuarioNegocio.ListarTodosOsUsuariosAsync();

            return new ComandoResultado(true, "listagem efetuada", usuarios);
        }
    }
}
