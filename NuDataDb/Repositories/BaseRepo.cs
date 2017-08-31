using NuDataDb.AppInterfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using NuDataDb.EF;
using System.Threading.Tasks;
using Newtonsoft.Json;

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

        public virtual void Delete(Int64 id)
        {
            throw new NotImplementedException();
        }

        public virtual void Delete(Guid id)
        {
            throw new NotImplementedException();
        }


        public virtual IEnumerable<T> Get()
        {
            try
            {
                return ctx.Set<T>().AsEnumerable<T>();
            }
            catch (Exception e)
            {
                throw new Exception($"Error getting {typeof(T)} collection from database.", e);
            }
        }

        public virtual IQueryable<T> GetAsQueryable()
        {
            try
            {
                return ctx.Set<T>().AsQueryable<T>();
            }
            catch (Exception e)
            {
                throw new Exception($"Error getting {typeof(T)} collection from database.", e);
            }
            
        }

        public virtual T GetSingle(int id)
        {
            throw new NotImplementedException();
        }

        public virtual T GetSingle(Int64 id)
        {
            throw new NotImplementedException();
        }

        public virtual T GetSingle(Guid id)
        {
            throw new NotImplementedException();
        }

        public virtual void Insert(T entity)
        {
            try
            {
                ctx.Add<T>(entity);
            }
            catch (Exception e)
            {
                var ser = JsonConvert.SerializeObject(entity);
                throw new Exception($"Error adding {typeof(T)} entity to context. /n/r{ser}", e);
            }
        }

        public async virtual Task InsertAsync(T entity)
        {
            try
            {
                await ctx.AddAsync<T>(entity);
            }
            catch (Exception e)
            {
                var ser = JsonConvert.SerializeObject(entity);
                throw new Exception($"Error adding {typeof(T)} entity to context. /n/r{ser}", e);
            }
        }

        public virtual int Save()
        {
            try
            {
                return ctx.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception("Error saving changes to database.", e);
            }
        }

        public async virtual Task<int> SaveAsync()
        {
            try
            {
                return await ctx.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception("Error saving changes to database.", e);
            }
            
        }

        public virtual void Update(T entity)
        {
            try
            {
                ctx.Update<T>(entity);
            }
            catch (Exception e)
            {
                var ser = JsonConvert.SerializeObject(entity);
                throw new Exception($"Error updating {typeof(T)} entity on context. /n/r{ser}", e);
            }
            
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
