using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseOrders.Data
{
    [Table("Product")]
    public class Product : Base
    {
        public virtual string Name { get; set; }
        public virtual int Type { get; set; }
        public virtual string UnitOfMeasure { get; set; }

        public static void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().Property(property => property.Name).HasMaxLength(20);

            modelBuilder.Entity<Product>().Property(property => property.Type).HasMaxLength(15);
        }
    }
   
}
