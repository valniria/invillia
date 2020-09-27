using Compartilhado.Comandos;
using System.Threading.Tasks;

namespace Aplicacao.Contextos.Home
{
    public interface IHomeService
    {
        IComandoResultado ObterDadosDashboard();
    }
}
