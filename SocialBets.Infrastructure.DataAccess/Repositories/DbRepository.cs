using Microsoft.EntityFrameworkCore;
using SocialBets.Domain.Core.Models;
using SocialBets.Domain.Interfaces.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialBets.Infrastructure.DataAccess.Repositories
{
    class DbRepository<TEntity, TKey> : IRepository<TEntity, TKey> 
        where TEntity : class
        where TKey : struct
    {
        private readonly ApplicationDbContext _ctx;

        public DbRepository(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task Add(TEntity entity)
        {
            if (entity is null)
                throw new NullReferenceException();

            await _ctx.Set<TEntity>().AddAsync(entity);
        }

        public void DeleteByItem(TEntity entity)
        {
            if (entity is null)
                throw new NullReferenceException();

            _ctx.Set<TEntity>().Remove(entity);

        }

        public void DeleteById(TKey id)
        {
            var entity = _ctx.Set<TEntity>().Find(id);

            DeleteByItem(entity);
        }

        public async Task<List<TEntity>> GetAll()
        {
            return await _ctx.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetItem(TKey id)
        {
            return await _ctx.Set<TEntity>().FindAsync(id);
        }

        public void Update(TEntity entity)
        {
            if (entity is null)
                throw new NullReferenceException();

            _ctx.Set<TEntity>().Update(entity);
        }
    }
}
