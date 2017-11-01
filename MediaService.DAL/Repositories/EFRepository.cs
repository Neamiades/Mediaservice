﻿#define OBJECT_METHODS_REALIZATION

using MediaService.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MediaService.DAL.Repositories
{
    public class EFRepository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : class
    {
        private readonly DbContext      _context;
        private readonly DbSet<TEntity> _dbSet;

        public EFRepository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public TEntity FindByKey(TKey key) => _dbSet.Find(key);

        public async Task<TEntity> FindByKeyAsync(TKey key) => await _dbSet.FindAsync(key);


        public IQueryable<TEntity> GetQuery()
        {
            return _dbSet.AsNoTracking().AsQueryable();
        }

        public IQueryable<TEntity> GetQuery(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.AsNoTracking().Where(predicate);
        }


        public IEnumerable<TEntity> GetData() => _dbSet.AsNoTracking();

        public async Task<IEnumerable<TEntity>> GetDataAsync() => await Task.Run(() => _dbSet.AsNoTracking());


        public IEnumerable<TEntity> GetData(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.AsNoTracking().Where(predicate).AsEnumerable();
        }

        public async Task<IEnumerable<TEntity>> GetDataAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await Task.Run(() => _dbSet.AsNoTracking().Where(predicate).AsEnumerable());
        }

#if OBJECT_METHODS_REALIZATION

        public void Add(object item) => _dbSet.Add((TEntity)item);

        public async Task AddAsync(object item) => await Task.Run(() => _dbSet.Add((TEntity)item));


        public void AddRange(object items) => _dbSet.AddRange((IEnumerable<TEntity>)items);

        public async Task AddRangeAsync(object items) => await Task.Run(() => _dbSet.AddRange((IEnumerable<TEntity>)items));


        public void Update(object item) => _context.Entry(item).State = EntityState.Modified;

        public async Task UpdateAsync(object item) => await Task.Run(() => _context.Entry(item).State = EntityState.Modified);


        public void Remove(object item) => _dbSet.Remove((TEntity)item);

        public async Task RemoveAsync(object item) => await Task.Run(() => _dbSet.Remove((TEntity)item));


        public void RemoveRange(object items) => _dbSet.RemoveRange((IEnumerable<TEntity>)items);

        public async Task RemoveRangeAsync(object items) => await Task.Run(() => _dbSet.RemoveRange((IEnumerable<TEntity>)items));
#else
        
        public void Add(TEntity item) => _dbSet.Add(item);

        public async Task AddAsync(TEntity item) => await Task.Run(() => _dbSet.Add(item));


        public void AddRange(IEnumerable<TEntity> items) => _dbSet.AddRange(items);

        public async Task AddRangeAsync(IEnumerable<TEntity> items) => await Task.Run(() => _dbSet.AddRange(items));


        public void Update(TEntity item) => _context.Entry(item).State = EntityState.Modified;

        public async Task UpdateAsync(TEntity item) => await Task.Run(() => _context.Entry(item).State = EntityState.Modified);


        public void Remove(TEntity item) => _dbSet.Remove(item);

        public async Task RemoveAsync(TEntity item) => await Task.Run(() => _dbSet.Remove(item));


        public void RemoveRange(IEnumerable<TEntity> items) => _dbSet.RemoveRange(items);

        public async Task RemoveRangeAsync(IEnumerable<TEntity> items) => await Task.Run(() => _dbSet.RemoveRange(items));

#endif

    }
}
