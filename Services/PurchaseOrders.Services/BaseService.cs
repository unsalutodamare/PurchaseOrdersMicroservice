using Microsoft.EntityFrameworkCore;
using PurchaseOrders.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseOrders.Services
{
    public abstract class BaseService<TEntity> : IBaseService<TEntity>
            where TEntity : class, IBase
    {
        protected PurchaseOrdersDbContext _purchaseOrdersDbContext;

        protected BaseService([NotNull] PurchaseOrdersDbContext purchaseOrdersDbContext)
        {
            _purchaseOrdersDbContext = purchaseOrdersDbContext;
        }

        public virtual async Task<TEntity> CreateAsync(TEntity entity)
        {
            await _purchaseOrdersDbContext.Set<TEntity>().AddAsync(entity);
            await _purchaseOrdersDbContext.SaveChangesAsync();

            return entity;
        }

        public virtual async Task<TEntity> ReadAsync(int id, bool tracking = true)
        {
            var query = _purchaseOrdersDbContext.Set<TEntity>().AsQueryable();

            if (!tracking)
            {
                query = query.AsNoTracking();
            }

            return await query.FirstOrDefaultAsync(entity => entity.Id == id && !entity.Deleted.HasValue);
        }

        public virtual async Task<TEntity> UpdateAsync(int id, TEntity updateEntity)
        {
            // Check that the record exists.
            var entity = await ReadAsync(id);

            if (entity == null)
            {
                throw new Exception("Unable to find record with id '" + id + "'.");
            }

            // Update changes if any of the properties have been modified.
            _purchaseOrdersDbContext.Entry(entity).CurrentValues.SetValues(updateEntity);
            _purchaseOrdersDbContext.Entry(entity).State = EntityState.Modified;

            if (_purchaseOrdersDbContext.Entry(entity).Properties.Any(property => property.IsModified))
            {
                await _purchaseOrdersDbContext.SaveChangesAsync();
            }
            return entity;
        }

        public virtual async Task DeleteAsync(int id)
        {
            // Check that the record exists.
            var entity = await ReadAsync(id);

            if (entity == null)
            {
                throw new Exception("Unable to find record with id '" + id + "'.");
            }

            // Set the deleted flag.
            entity.Deleted = DateTimeOffset.Now;
            _purchaseOrdersDbContext.Entry(entity).State = EntityState.Modified;

            // Save changes to the Db Context.
            await _purchaseOrdersDbContext.SaveChangesAsync();
        }
    }
}
