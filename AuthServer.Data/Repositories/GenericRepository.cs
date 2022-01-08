using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AuthServer.Core.Repository;
using Microsoft.EntityFrameworkCore;

namespace AuthServer.Data.Repositories
{
    public class GenericRepository<TEntity>:IGenericRepository<TEntity> where TEntity:class
    {
        private readonly DbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public GenericRepository(AppDbContext context)
        {
            _context = context;

            _dbSet = context.Set<TEntity>();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);

            // EntityState.Detached yapısını service classında gösterecez.
            if (entity != null)
            {
                _context.Entry(entity).State = EntityState.Detached;// bu memoryde takip edilmesin

            }

            return entity;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            // Tüm datayı memory aldık bundan sonra yapacağımız orderby,select gibi sorgular o an memorydeki datada gerçekleşir.
            // data geldikten sonra , gelen data üzerine memoryde işlem yaparız.
           return  await _dbSet.ToListAsync();
        }

        public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate)
        {
            // memoryde gerçekleşir ama veritabanından çekmez, her şeyi ekledikten sonra, tolist dediğim anda o anda yazdığımız sorgular
            // birleştirilir ve veritabanına yazılır Queryable mantığı budur.
            return _dbSet.Where(predicate);
        }

        public async Task AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public void Remove(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public TEntity Update(TEntity entity)
        {
            // biz bir tane ürünü değiştirsek bile diğer tüm alanlarıda hiç değiştirmese bile güncelleme yapar. bu dezavantajdır.
            _context.Entry(entity).State = EntityState.Modified;

            return entity;

        }
    }
}
