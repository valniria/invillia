using Dominio.Contextos.Jogos;
using Dominio.Contextos.Jogos.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Contextos.Jogos
{
    public class JogoNegocio : IJogoNegocio
    {
        private readonly IJogoRepositorio JogoRepositorio;
        public JogoNegocio(IJogoRepositorio jogoRepositorio)
        {
            JogoRepositorio = jogoRepositorio;
        }

        public async Task Add(Jogo Objeto)
        {
            await JogoRepositorio.Add(Objeto);
        }

        public async Task<List<Jogo>> GetAll()
        {
            var jogos = await JogoRepositorio.GetAll();

            return jogos;
        }

        public async Task<Jogo> GetById(long Id)
        {
            var jogo = await JogoRepositorio.GetById(Id);

            return jogo;
        }

        public async Task<List<Jogo>> ListarTodosOsJogosAsync()
        {
            var jogos = await JogoRepositorio.ListarTodosOsJogosAsync();

            return jogos;
        }

        public async Task<Jogo> ObterJogoPorIdAsync(long Id)
        {
            var jogo = await JogoRepositorio.ObterJogoPorIdAsync(Id);
            return jogo;
        }

        public async Task Update(Jogo Objeto)
        {
            throw new NotImplementedException();
        }
    }
}
