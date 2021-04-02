using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseOrders.Data
{
    [Table("Client")]
    public class Client : Base
    {
        public virtual string Name { get; set; }
        public virtual string Surname { get; set; }
        public virtual string Email { get; set; }
        public virtual string PhoneNumber { get; set; }
        public virtual string Adress { get; set; }

        public static void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>().Property(property => property.Name).HasMaxLength(20);

            modelBuilder.Entity<Client>().Property(property => property.Surname).HasMaxLength(20);

            modelBuilder.Entity<Client>().Property(property => property.Email).HasMaxLength(25);

            modelBuilder.Entity<Client>().Property(property => property.PhoneNumber).HasMaxLength(15);

            modelBuilder.Entity<Client>().Property(property => property.Adress).HasMaxLength(30);
        }
    }
}
