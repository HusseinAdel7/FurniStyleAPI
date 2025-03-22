using FurniStyle.Core.Entities;
using FurniStyle.Core.IRepositories;
using FurniStyle.Repository.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurniStyle.Repository.Repositories
{
    public class GenericRepository<TEntity, TKey> : IGenericRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        private readonly FurniStyleDbContext _furniStyleDbContext;

        public GenericRepository(FurniStyleDbContext furniStyleDbContext)
        {
            _furniStyleDbContext = furniStyleDbContext;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            if(typeof(TEntity) ==typeof(Furni))
                return (IEnumerable<TEntity>) await _furniStyleDbContext.Furnis.Include(p=>p.Category).Include(p=>p.Room).ToListAsync();
            return await _furniStyleDbContext.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetAsync(TKey id)
        {
            if (typeof(TEntity) == typeof(Furni))
                return await _furniStyleDbContext.Furnis.Include(p => p.Category).Include(p => p.Room).FirstOrDefaultAsync(p=>p.Id==id as int?) as TEntity;
            return await _furniStyleDbContext.Set<TEntity>().FindAsync(id);

        }

        public async Task AddAsync(TEntity entity)
        {
            await _furniStyleDbContext.AddAsync(entity);
        }

        public void Update(TEntity entity)
        {
             _furniStyleDbContext.Remove(entity);
        }

        public  void Delete(TEntity entity)
        {
             _furniStyleDbContext.Update(entity);
        }

    }
}
