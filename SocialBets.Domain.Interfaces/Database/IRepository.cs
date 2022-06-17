using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SocialBets.Domain.Interfaces.Database
{
    public interface IRepository<TEntity, TId> 
        where TEntity : class
        where TId : struct
    {
        Task Add(TEntity entity);
        Task<TEntity> GetItem(TId id);
        Task<List<TEntity>> GetAll();
        void Update(TEntity entity);
        void DeleteByItem(TEntity entity);
        void DeleteById(TId id);
    }
}
