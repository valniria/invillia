using Dominio.Contextos.Jogos;
using Dominio.Contextos.Jogos.Interfaces;
using EntityFramework.Configuracao;
using Infraestrutura.Repositorio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFramework.Contextos.Jogos
{
    public class JogoRepositorio : RepositorioBase<Jogo>, IJogoRepositorio
    {
        
        private readonly ContextoBase contexto;

        public JogoRepositorio(ContextoBase contexto)
            => this.contexto = contexto;

        public async Task<List<Jogo>> ListarTodosOsJogosAsync()
        {
            var jogos = await contexto.Jogos
                .Include(j => j.TipoJogo)
                .Include(j => j.TipoPlataforma)
                .Include(j => j.Situacao)
                .ToListAsync();

            return jogos;
        }

        public async Task<Jogo> ObterJogoPorIdAsync(long Id)
        {
            var jogo = await contexto.Jogos
                .Include(j => j.TipoJogo)
                .Include(j => j.TipoPlataforma)
                .Include(j => j.Situacao)
                .FirstOrDefaultAsync(j => j.Id == Id);

            return jogo;
        }

        public async Task<int> ObterQuantidadeDeJogos()
        {
            var quantidade = await contexto.Jogos
                                .CountAsync(j => j.Status == 1);

            return quantidade;
        }
    }
}
