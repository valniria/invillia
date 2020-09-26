using Compartilhado.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dominio.Contextos.Jogos
{
    public interface IJogoNegocio : INegocioBase<Jogo>
    {
        Task<List<Jogo>> ListarTodosOsJogosAsync();
        Task<Jogo> ObterJogoPorIdAsync(long Id);
    }
}
