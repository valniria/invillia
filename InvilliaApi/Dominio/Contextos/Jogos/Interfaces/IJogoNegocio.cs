using Compartilhado.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dominio.Contextos.Jogos
{
    public interface IJogoNegocio //: INegocioBase<Jogo>
    {
        Task Add(Jogo Objeto);
        Task Update(Jogo Objeto);
        Task<Jogo> GetById(long Id);
        Task<List<Jogo>> GetAll();
        Task Delete(Jogo Objeto);



        Task<List<Jogo>> ListarTodosOsJogosAsync();
        Task<Jogo> ObterJogoPorIdAsync(long Id);
        Task<int> ObterQuantidadeDeJogos();
    }
}
