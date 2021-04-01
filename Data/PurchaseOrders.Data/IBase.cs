using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseOrders.Data
{
    public interface IBase
    {
        int Id { get; set; }

        DateTimeOffset Created { get; set; }
        DateTimeOffset? LastUpdated { get; set; }
    }
}
