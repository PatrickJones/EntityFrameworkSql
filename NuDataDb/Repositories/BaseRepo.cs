using NuDataDb.AppInterfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using NuDataDb.EF;
using System.Threading.Tasks;

namespace NuDataDb.Repositories
{
    public abstract class BaseRepo<T> : IRepository<T>, IDisposable where T : class
    {
        internal NuMedicsGlobalContext ctx;

        protected BaseRepo(NuMedicsGlobalContext dbContext)
        {
            this.ctx = dbContext;
        }

        public virtual void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public virtual void Delete(Guid id)
        {
            throw new NotImplementedException();
        }


        public virtual IEnumerable<T> Get()
        {
            return ctx.Set<T>().AsEnumerable<T>();
        }

        public virtual IQueryable<T> GetAsQueryable()
        {
            return ctx.Set<T>().AsQueryable<T>();
        }

        public virtual T GetSingle(int id)
        {
            throw new NotImplementedException();
        }

        public virtual T GetSingle(Guid id)
        {
            throw new NotImplementedException();
        }

        public virtual void Insert(T entity)
        {
            ctx.Add<T>(entity);
        }

        public async virtual Task InsertAsync(T entity)
        {
            await ctx.AddAsync<T>(entity);
        }

        public virtual int Save()
        {
            return ctx.SaveChanges();
        }

        public async virtual Task<int> SaveAsync()
        {
            return await ctx.SaveChangesAsync();
        }

        public virtual void Update(T entity)
        {
            ctx.Update<T>(entity);
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    ctx.Dispose();
                }

                disposedValue = true;
            }
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
        }
        #endregion
    }
}
