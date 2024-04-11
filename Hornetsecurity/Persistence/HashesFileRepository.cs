using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Hornetsecurity.Models;

namespace Hornetsecurity.Persistence
{
    internal class HashesFileRepository
    {
        protected readonly DbContext Context;
        public HashesFileRepository(DbContext Context)
        {
            this.Context = Context;
        }


        public HashesFile? Get(Guid id)
        {
            var result = Context.Set<HashesFile>().Find(id);

            return result;
        }

        public List<HashesFile> GetAll()
        {
            var result = Context.Set<HashesFile>().AsNoTracking().AsQueryable().ToList();

            return result;
        }

        public void Add(HashesFile entity)
        {
            Context.Set<HashesFile>().Add(entity);
        }

        public void AddRange(IEnumerable<HashesFile> entities)
        {
            Context.Set<HashesFile>().AddRange(entities);
        }


        public void Remove(HashesFile entity)
        {
            Context.Set<HashesFile>().Remove(entity);
        }

        public async Task<int> Remove(Expression<Func<HashesFile, bool>> prediction)
        {
            return await Context.Set<HashesFile>().Where(prediction).ExecuteDeleteAsync();
        }

        public void Update(HashesFile entity)
        {
            Context.Set<HashesFile>().Update(entity);
        }

        public int Update(Expression<Func<HashesFile, bool>> where, Expression<Func<SetPropertyCalls<HashesFile>, SetPropertyCalls<HashesFile>>> prop)
        {
            return Context.Set<HashesFile>().Where(where).ExecuteUpdate(prop);
        }


        public int Complete()
        {
            return Context.SaveChanges();
        }
    }
}
