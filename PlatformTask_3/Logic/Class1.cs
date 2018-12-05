using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;


namespace Logic
{
    public class BaseContext : DbContext
    {
        public BaseContext() : base("name=DefaultConnection")
        {
        }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Address> Addresss { get; set; }
    }
}
