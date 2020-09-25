using Compartilhado.Comandos;
using System.Threading.Tasks;

namespace Compartilhado.Interfaces
{
    public interface IServiceBase<T> where T : class
    {
        Task<IComandoResultado> GetAll();
        Task<IComandoResultado> GetById(long Id);
    }
}
