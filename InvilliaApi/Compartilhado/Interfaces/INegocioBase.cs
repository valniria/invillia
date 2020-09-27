using System.Collections.Generic;
using System.Threading.Tasks;

namespace Compartilhado.Interfaces
{
    public interface INegocioBase<T> where T : class
    {
        Task Add(T Objeto);
        Task Update(T Objeto);
        Task<T> GetById(long Id);
        Task<List<T>> GetAll();
        Task Delete(T Objeto);
    }
}
