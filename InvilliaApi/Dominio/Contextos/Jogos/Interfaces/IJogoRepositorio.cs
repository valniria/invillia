using Compartilhado.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Contextos.Jogos.Interfaces
{
    public interface IJogoRepositorio : IRepositorioBase<Jogo>
    {
        Task<List<Jogo>> ListarTodosOsJogosAsync();
        Task<Jogo> ObterJogoPorIdAsync(long Id);
        Task<int> ObterQuantidadeDeJogos();
    }
}
