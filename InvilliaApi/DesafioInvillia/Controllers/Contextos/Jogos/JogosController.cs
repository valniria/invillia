using Aplicacao.Contextos.Jogos;
using AplicacaoService.Contextos.Jogos;
using Compartilhado.Comandos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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
                return BadRequest(new ComandoResultado(false, "Ocorreu erro no serviço ListarTodosOsJogosAsync()"));
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

                return BadRequest(new ComandoResultado(false, "Ocorreu erro no serviço ObterJogoPorIdAsync"));
            }
        }

        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
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
                return BadRequest(new ComandoResultado(false, "Ocorreu erro no serviço CadastrarJogoAsync()"));
            }
        }

        [HttpPut]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
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
                return BadRequest(new ComandoResultado(false, "Ocorreu erro no serviço AtualizarJogoAsync()"));
            }
        }
    }
}
