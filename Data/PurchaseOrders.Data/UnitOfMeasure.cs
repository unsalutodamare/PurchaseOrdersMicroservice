using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseOrders.Data
{
    [Table("UnitOfMeasure")]
    public class UnitOfMeasure : Base
    {
        [Required(ErrorMessage = "Name is requried!")]
        public virtual string Name { get; set; }
    }
}
