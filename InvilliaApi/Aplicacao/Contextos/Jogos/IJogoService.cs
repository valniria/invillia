using Compartilhado.Comandos;
using Compartilhado.Interfaces;
using Dominio.Contextos.Jogos;
using System.Threading.Tasks;

namespace Aplicacao.Contextos.Jogos
{
    public interface IJogoService : IServiceBase<Jogo>
    {
        Task<IComandoResultado> CadastrarJogoAsync(JogoDto jogoDto);

        Task<IComandoResultado> AtualizarJogoAsync(JogoDto jogoDto);

        Task<IComandoResultado> ListarTodosOsJogosAsync();

        Task<IComandoResultado> ObterJogoPorIdAsync(long Id);
    }
}
