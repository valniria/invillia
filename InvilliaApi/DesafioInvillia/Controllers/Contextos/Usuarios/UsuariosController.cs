using Aplicacao.Contextos.Usuarios;
using Compartilhado.Comandos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Mime;
using System.Threading.Tasks;

namespace DesafioInvillia.Controllers.Contextos.Usuarios
{
    [Route("api/usuarios")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioService UsuarioService;

        public UsuariosController(IUsuarioService usuarioService)
        {
            UsuarioService = usuarioService;
        }

        [HttpGet]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles ="Admin")]
        public async Task<ActionResult<IComandoResultado>> ListarTodosOsUsuariosAsync()
        {
            try
            {
                var usuarios = (ComandoResultado)await UsuarioService.ListarTodosOsUsuariosAsync();

                return Ok(usuarios);
            }
            catch (Exception ex)
            {
                return BadRequest(new ComandoResultado(false, ex.ToString()));
            }
        }


        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CadastrarUsuarioAsync([FromBody] UsuarioDto usuarioDto)
        {
            try
            {
                if (usuarioDto == null)
                    return NotFound();

                var jogos = await UsuarioService.CadastrarUsuarioAsync(usuarioDto);

                return Ok(jogos);
            }
            catch (Exception ex)
            {
                return BadRequest(new ComandoResultado(false, ex.ToString()));
            }
        }

        [HttpGet("{id}")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<string>> ObterUsuarioPorIdAsync(int id)
        {
            try
            {
                var usuario = (ComandoResultado)await UsuarioService.ObterUsuarioPorIdAsync(id);

                return Ok(usuario);
            }
            catch (Exception ex)
            {

                return BadRequest(new ComandoResultado(false, ex.ToString()));
            }
        }

        [HttpPut]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> AtualizarUsuarioAsync([FromBody] UsuarioDto usuarioDto)
        {
            try
            {
                if (usuarioDto == null)
                    return NotFound();

                var jogos = await UsuarioService.AtualizarUsuarioAsync(usuarioDto);

                return Ok(jogos);
            }
            catch (Exception ex)
            {
                return BadRequest(new ComandoResultado(false, ex.ToString()));
            }
        }

        [HttpDelete()]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> RemoverUsuarioAsync([FromBody] UsuarioDto usuarioDto)
        {
            try
            {
                if (usuarioDto == null)
                    return NotFound();

                var jogos = await UsuarioService.RemoverUsuarioAsync(usuarioDto);

                return Ok(jogos);
            }
            catch (Exception ex)
            {
                return BadRequest(new ComandoResultado(false, ex.ToString()));
            }
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> RealizarLoginAsync([FromBody] UsuarioDto usuarioDto)
        {
            try
            {
                if (usuarioDto == null)
                    return NotFound();

                var jogos = await UsuarioService.RealizarLoginAsync(usuarioDto);

                return Ok(jogos);
            }
            catch (Exception ex)
            {
                return BadRequest(new ComandoResultado(false, ex.ToString()));
            }
        }
    }
}
