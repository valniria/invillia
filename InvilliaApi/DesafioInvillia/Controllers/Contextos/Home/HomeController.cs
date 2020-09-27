using Aplicacao.Contextos.Home;
using Compartilhado.Comandos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Mime;
using System.Threading.Tasks;

namespace DesafioInvillia.Controllers.Contextos.Home
{
    [Route("api/home")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IHomeService HomeService;

        public HomeController(IHomeService homeService)
        {
            HomeService = homeService;
        }

        [HttpGet]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<IComandoResultado> ObterDadosDashboard()
        {
            try
            {
                var jogos = (ComandoResultado) HomeService.ObterDadosDashboard();

                return Ok(jogos);
            }
            catch (Exception ex)
            {
                return BadRequest(new ComandoResultado(false, ex.ToString()));
            }
        }
    }
}
