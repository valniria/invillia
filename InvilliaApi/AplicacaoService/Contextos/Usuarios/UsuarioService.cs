using Aplicacao.Contextos.Usuarios;
using Compartilhado.Comandos;
using Dominio.Contextos.Usuarios.Interfaces;
using System;
using System.Linq;
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

        public async Task<IComandoResultado> AtualizarUsuarioAsync(UsuarioDto usuarioDto)
        {
            var usuario = await UsuarioNegocio.GetById(usuarioDto.Id);
            if(usuario == null)
            {
                return new ComandoResultado(false, "Usuário não encontrado");
            }

            var usuarioASerAtualizado = usuarioDto.TransformaEmEntidade();
            await UsuarioNegocio.Update(usuarioASerAtualizado);

            return new ComandoResultado(true, "Efetuado com sucesso.");
        }

        public async Task<IComandoResultado> CadastrarUsuarioAsync(UsuarioDto usuarioDto)
        {
            try
            {
                usuarioDto.PrepararSenha();
                usuarioDto.Email = usuarioDto.Email.ToLower();

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

        public async Task<IComandoResultado> ObterUsuarioPorIdAsync(long Id)
        {
            var usuario = await UsuarioNegocio.ObterUsuarioPorIdAsync(Id);

            return new ComandoResultado(true, "listagem efetuada", usuario);
        }

        public async Task<IComandoResultado> RealizarLoginAsync(UsuarioDto usuarioDto)
        {
            usuarioDto.PrepararSenha();
            usuarioDto.Email = usuarioDto.Email.ToLower();

            var usuario = await UsuarioNegocio.BuscaPorEmailESenhaAsync(usuarioDto.Email, usuarioDto.Senha);

            if(usuario == null)
            {
                return new ComandoResultado(false, "Usuário ou Senha Inválidos.");
            }

            //Gera Token
            var token = TokenService.GenerateToken(usuario);

            var usuarioLogin = new UsuarioLoginDto(usuario, token);

            return new ComandoResultado(true, "Efetuado com sucesso.", usuarioLogin);
        }

        public async Task<IComandoResultado> RemoverUsuarioAsync(UsuarioDto usuarioDto)
        {
            var usuario = await UsuarioNegocio.ObterUsuarioPorIdAsync(usuarioDto.Id);
            if (usuario == null)
            {
                return new ComandoResultado(false, "Usuário não encontrado");
            }
            if(usuario.UsuarioComJogo.Count() > 0)
            {
                return new ComandoResultado(false, "Usuário não pode ser excluído pois está vinculado a um jogo.");
            }

            await UsuarioNegocio.Delete(usuario);

            return new ComandoResultado(true, "Efetuado com sucesso.");
        }

    }
}
