using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseOrders.Data
{
    [Table("PurchaseOrder")]
    public class PurchaseOrder : Base
    {
        public virtual int ID { get; set; }
        public virtual DateTime DateCreated { get; set; }
        public virtual DateTime DateUpdated { get; set; }
        public virtual double Total { get; set; }
        public enum Status { Created, Processing, Confirmed, Declined, Sent, Completed }
        public virtual ICollection<PurchaseOrderItem> PurchaseOrderItems { get; set; }
        public virtual Client Client { get; set; }

    }
}
