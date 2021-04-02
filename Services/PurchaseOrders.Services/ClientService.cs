using PurchaseOrders.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseOrders.Services
{
    public class ClientService : BaseService<Client>, IClientService
    {
        public ClientService(PurchaseOrdersDbContext purchaseOrdersDbContext) : base(purchaseOrdersDbContext) { }
    }
}
