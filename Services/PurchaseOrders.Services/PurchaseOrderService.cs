using Microsoft.EntityFrameworkCore;
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
            return GetAllAsync().Where(p => p.Status.Name.Contains(keyword)).ToList();
        }

        public List<PurchaseOrder> SearchTotalAsync(double min, double max)
        {
            return GetAllAsync().Where(p => p.Total >= min && p.Total <= max).ToList();
        }

        public List<PurchaseOrder> SearchBetweenDateAsync(DateTime dateFrom, DateTime dateTo)
        {
            return GetAllAsync().Where(p => p.Created >= dateFrom && p.Created <= dateTo).ToList();
        }

        public List<PurchaseOrder> SearchByMonthAsync(int month)
        {
             return GetAllWithIncludeAsync().Include(c => c.PurchaseOrderItem).ThenInclude(cs => cs.Product).Where(p => p.DateCreated.Month == month).ToList();           
        }
  

        public List<PurchaseOrder> SearchByClientNameAsync(string name)
        {
            return GetAllAsync().Where(p => p.Client.Name.Contains(name)).ToList();
        }

        public List<PurchaseOrder> SearchByProductAsync(string productName)
        {
            return GetAllAsync().Where(p => p.PurchaseOrderItems.Any(p => p.Product.Name == productName)).ToList();
        }
    }
}