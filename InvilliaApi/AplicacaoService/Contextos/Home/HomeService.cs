using Aplicacao.Contextos.Home;
using Compartilhado.Comandos;
using Dominio.Contextos.Jogos;
using Dominio.Contextos.Usuarios.Interfaces;
using System.Linq;

namespace AplicacaoService.Contextos.Home
{
    public class HomeService : IHomeService
    {
        private readonly IJogoNegocio JogoNegocio;
        private readonly IUsuarioNegocio UsuarioNegocio;

        public HomeService(IJogoNegocio jogoNegocio, IUsuarioNegocio usuarioNegocio)
        {
            JogoNegocio = jogoNegocio;
            UsuarioNegocio = usuarioNegocio;
        }

        public IComandoResultado ObterDadosDashboard()
        {
            var dashboard = new HomeDto
            {
                QuantidadeDeJogos = JogoNegocio.ListarTodosOsJogosAsync().Result.Count(),
                UsuariosCadastrados = UsuarioNegocio.ListarTodosOsUsuariosAsync().Result.Count(u => u.Status.Equals(1))
            };
            var jogosEmprestados = JogoNegocio.ListarTodosOsJogosAsync().Result.Count(j => j.SituacaoId == 2);

            if (dashboard.QuantidadeDeJogos != 0 && jogosEmprestados != 0)
                dashboard.PorcentagemDeEmprestimo = dashboard.QuantidadeDeJogos / jogosEmprestados;
            else
                dashboard.PorcentagemDeEmprestimo = 0;

            return new ComandoResultado(true, "Efetuado com sucesso.", dashboard);
        }
    }
}
