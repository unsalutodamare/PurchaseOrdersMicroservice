using PurchaseOrders.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseOrders.Services
{
    public interface IPurchaseOrderService : IBaseService<PurchaseOrder>
    {
        public List<PurchaseOrder> SearchStatusAsync(string keyword);
        public List<PurchaseOrder> SearchTotalAsync(double min, double max);

        public List<PurchaseOrder> SearchBetweenDateAsync(DateTime dateFrom, DateTime dateTo);

        public List<PurchaseOrder> SearchByClientNameAsync(string name);

        public List<PurchaseOrder> SearchByProductAsync(string productName);

        public List<PurchaseOrder> SearchByMonthAsync(int month);

     

    }
}
