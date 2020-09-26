using Compartilhado.Interfaces;
using EntityFramework.Configuracao;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Infraestrutura.Repositorio
{
    public class RepositorioBase<T> : IRepositorioBase<T>, IDisposable where T : class
    {

        private readonly DbContextOptions<ContextoBase> contexto;

        public RepositorioBase()
        {
            contexto = new DbContextOptions<ContextoBase>();
        }

        public async Task Add(T Objeto)
        {
            try
            {
                using var data = new ContextoBase(contexto);
                await data.AddAsync(Objeto);
                await data.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        public async Task Delete(T Objeto)
        {
            using var data = new ContextoBase(contexto);
            data.Set<T>().Remove(Objeto);
            await data.SaveChangesAsync();
        }

        public async Task<T> GetById(long Id)
        {
            using var data = new ContextoBase(contexto);
            return await data.Set<T>()
                             .FindAsync(Id);
        }

        public async Task<List<T>> GetAll()
        {
            using var data = new ContextoBase(contexto);
            return await data.Set<T>()
                             .AsNoTracking()
                             .ToListAsync();
        }

        public async Task Update(T Objeto)
        {
            using var data = new ContextoBase(contexto);
            data.Update(Objeto);
            await data.SaveChangesAsync();
        }



        #region Disposed https://docs.microsoft.com/pt-br/dotnet/standard/garbage-collection/implementing-dispose
        // To detect redundant calls
        private bool _disposed = false;

        // Instantiate a SafeHandle instance.
        private SafeHandle _safeHandle = new SafeFileHandle(IntPtr.Zero, true);

        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose() => Dispose(true);

        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                // Dispose managed state (managed objects).
                _safeHandle?.Dispose();
            }

            _disposed = true;
        }
        #endregion
    }
}
