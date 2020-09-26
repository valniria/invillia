using Aplicacao.Contextos.Jogos;
using Compartilhado.Comandos;
using Dominio.Contextos.Jogos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AplicacaoService.Contextos.Jogos
{
    public class JogoService : IJogoService
    {
        private readonly IJogoNegocio JogoNegocio;

        public JogoService(IJogoNegocio jogoNegocio)
        {
            JogoNegocio = jogoNegocio;
        }

        public async Task<IComandoResultado> AtualizarJogoAsync(JogoDto jogoDto)
        {
            var jogo = await JogoNegocio.GetById(jogoDto.Id);
            if (jogo == null)
            {
                return new ComandoResultado(false, "Jogo não encontrado.");
            }

            //Trasformar em entidade

            //atualizar

            return new ComandoResultado(true, "Efetuado com sucesso.");
        }

        public async Task<IComandoResultado> CadastrarJogoAsync(JogoDto jogoDto)
        {
            try
            {
                var jogo = jogoDto.TransformaEmEntidade();

                await JogoNegocio.Add(jogo);

                return new ComandoResultado(true, "Efetuado com sucesso.");
            }
            catch (Exception ex)
            {
                return new ComandoResultado(true, "Ocorreu um erro.");
            }

        }

        public async Task<IComandoResultado> GetAll()
        {
            var jogos = await JogoNegocio.GetAll();

            var jogoDto = new List<JogoDto>();

            jogos.ForEach(jogo => jogoDto.Add(new JogoDto()
            {
                Id = jogo.Id,
                Nome = jogo.Nome,
                Status = jogo.Status,
                TipoJogoId = jogo.TipoJogoId,
                TipoPlataformaId = jogo.TipoPlataformaId,
                SituacaoId = jogo.SituacaoId,
            }));

            return new ComandoResultado(true, "listagem efetuada", jogoDto);
        }

        public async Task<IComandoResultado> GetById(long Id)
        {
            var jogo = await JogoNegocio.GetById(Id);

            var jogoDto = new JogoDto()
            {
                Id = jogo.Id,
                Nome = jogo.Nome,
                Status = jogo.Status,
                TipoJogoId = jogo.TipoJogoId,
                SituacaoId = jogo.SituacaoId,
                TipoPlataformaId = jogo.TipoPlataformaId
            };

            return new ComandoResultado(true, "listagem efetuada", jogoDto);
        }

        public async Task<IComandoResultado> ListarTodosOsJogosAsync()
        {
            var jogos = await JogoNegocio.ListarTodosOsJogosAsync();

            var jogoDto = new List<JogoDto>();

            jogos.ForEach(jogo => jogoDto.Add(new JogoDto()
            {
                Id = jogo.Id,
                Nome = jogo.Nome,
                Status = jogo.Status,
                TipoJogoId = jogo.TipoJogoId,
                TipoJogoNome = jogo.TipoJogo.Descricao,
                TipoPlataformaId = jogo.TipoPlataformaId,
                TipoPlataformaNome = jogo.TipoPlataforma.Descricao,
                SituacaoId = jogo.SituacaoId,
                SituacaoNome = jogo.Situacao.Descricao
            }));

            return new ComandoResultado(true, "listagem efetuada", jogoDto);
        }

        public async Task<IComandoResultado> ObterJogoPorIdAsync(long Id)
        {
            var jogo = await JogoNegocio.ObterJogoPorIdAsync(Id);

            var jogoDto = new JogoDto()
            {
                Id = jogo.Id,
                Nome = jogo.Nome,
                Status = jogo.Status,
                TipoJogoId = jogo.TipoJogoId,
                TipoJogoNome = jogo.TipoJogo.Descricao,
                TipoPlataformaId = jogo.TipoPlataformaId,
                TipoPlataformaNome = jogo.TipoPlataforma.Descricao,
                SituacaoId = jogo.SituacaoId,
                SituacaoNome = jogo.Situacao.Descricao
            };

            return new ComandoResultado(true, "listagem efetuada", jogoDto);
        }
    }
}
