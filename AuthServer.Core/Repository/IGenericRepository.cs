using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AuthServer.Core.Repository
{
    public interface IGenericRepository<TEntity> where TEntity:class
    {
        Task<TEntity> GetByIdAsync(int id);
        //IQueryable<TEntity> GetAllAsync();
        Task<IEnumerable<TEntity>> GetAllAsync(); // direk çekeceksekm tüm verileri
        IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate); // sorgu yazacaksam where gibi
        Task AddAsync(TEntity entity);
        void Remove(TEntity entity);
        TEntity Update(TEntity entity);
    }
}
