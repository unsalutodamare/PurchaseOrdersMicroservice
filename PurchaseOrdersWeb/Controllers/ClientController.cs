using Microsoft.AspNetCore.Mvc;
using PurchaseOrders.Data;
using PurchaseOrders.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PurchaseOrdersWeb.Controllers
{
    [Route("api/client")]
    public class ClientController : BaseController<Client>
    {
       public ClientController(IClientService clientService) : base(clientService)
        {

        }
    }
}
