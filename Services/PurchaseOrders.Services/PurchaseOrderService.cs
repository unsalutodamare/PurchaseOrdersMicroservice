using PurchaseOrders.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseOrders.Services
{
    public class PurchaseOrderService : BaseService<PurchaseOrder>, IPurchaseOrderService
    {
        public PurchaseOrderService(PurchaseOrdersDbContext purchaseOrdersDbContext) : base(purchaseOrdersDbContext) { }


        public List<PurchaseOrder> SearchStatusAsync(string keyword)
        {
            return GetAllAsync().Where(p => p.Status.Contains(keyword)).ToList();
        }

        public List<PurchaseOrder> SearchTotalAsync(double min, double max)
        {
            return GetAllAsync().Where(p => p.Total >= min && p.Total <= max).ToList();
        }

        public List<PurchaseOrder> SearchBetweenDateAsync(DateTime dateFrom, DateTime dateTo)
        {
            return GetAllAsync().Where(p => p.DateCreated >= dateFrom && p.DateCreated <= dateTo).ToList();
        }

        public List<PurchaseOrder> SearchByClientNameAsync(string name)
        {
            return GetAllAsync().Where(p => p.Client.Name.Contains(name)).ToList();
        }

        public List<PurchaseOrder> SearchByProductAsync(string productName)
        {
            return GetAllAsync().Where(p => p.PurchaseOrderItem.Product.Name.Contains(productName)).ToList();
        }
    }
}
