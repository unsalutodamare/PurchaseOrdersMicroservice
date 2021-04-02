using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseOrders.Data
{
    [Table("PurchaseOrderItem")]
    public class PurchaseOrderItem : Base
    {
        public virtual int Quantity { get; set; }
        public virtual double Price { get; set; }
        public virtual double TotalPrice { get; set; }
        public virtual Product Product { get; set; }
    }
}
