using Aplicacao.Contextos.Jogos;
using Compartilhado.Comandos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Mime;
using System.Threading.Tasks;

namespace DesafioInvillia.Controllers.Contextos.Jogos
{
    [Route("api/jogos")]
    [ApiController]
    public class JogosController : ControllerBase
    {
        private readonly IJogoService JogoService;

        public JogosController(IJogoService jogoService)
        {
            JogoService = jogoService;
        }

        [HttpGet]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IComandoResultado>> ListarTodosOsJogosAsync()
        {
            try
            {
                var jogos = (ComandoResultado)await JogoService.ListarTodosOsJogosAsync();

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
        public async Task<ActionResult<string>> ObterJogoPorIdAsync(int id)
        {
            try
            {
                var jogo = (ComandoResultado)await JogoService.ObterJogoPorIdAsync(id);

                return Ok(jogo);
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
        public async Task<ActionResult> CadastrarJogoAsync([FromBody] JogoDto jogoDto)
        {
            try
            {
                if (jogoDto == null)
                    return NotFound();

                var jogos = await JogoService.CadastrarJogoAsync(jogoDto);

                return Ok(jogos);
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
        public async Task<ActionResult> AtualizarJogoAsync([FromBody] JogoDto jogoDto)
        {
            try
            {
                var jogo = (ComandoResultado)await JogoService.AtualizarJogoAsync(jogoDto);

                return Ok(jogo);
            }
            catch (Exception ex)
            {
                return BadRequest(new ComandoResultado(false, ex.ToString()));
            }
        }

        [HttpPut]
        [Route("emprestarOuReceber")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> EmprestarJogoAsync([FromBody] JogoDto jogoDto)
        {
            try
            {
                if (jogoDto == null)
                    return NotFound();

                var jogos = await JogoService.EmprestarJogoAsync(jogoDto);

                return Ok(jogos);
            }
            catch (Exception ex)
            {
                return BadRequest(new ComandoResultado(false, ex.ToString()));
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> RemoverJogoAsync(int Id)
        {
            try
            {
                if (Id == 0)
                    return NotFound();

                var jogos = await JogoService.RemoverJogoAsync(Id);

                return Ok(jogos);
            }
            catch (Exception ex)
            {
                return BadRequest(new ComandoResultado(false, ex.ToString()));
            }
        }
    }
}
