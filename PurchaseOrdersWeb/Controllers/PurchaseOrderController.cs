using Microsoft.AspNetCore.Mvc;
using PurchaseOrders.Data;
using PurchaseOrders.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PurchaseOrdersWeb.Controllers
{
    [Route("api/purchaseorder")]
    public class PurchaseOrderController : BaseController<PurchaseOrder>
    {
        public PurchaseOrderController(IPurchaseOrderService purchaseOrderService) : base(purchaseOrderService)
        {

        }
    }
}
