using PurchaseOrders.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseOrders.Services
{
    public interface IBaseService<TEntity>
            where TEntity : class, IBase
    {
        Task<TEntity> CreateAsync(TEntity entity);

        Task<TEntity> ReadAsync(int id, bool tracking = true);

        IQueryable<TEntity> GetAllAsync();

        Task<TEntity> UpdateAsync(int id, TEntity updateEntity);

        Task DeleteAsync(int id);
    }
}
