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
    }
}
