using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Repo
{
   public  class OrderRepo : IRepository<Order>
    {
        private BaseContext db;
       public OrderRepo(BaseContext bs)
        {
            db = bs;
        }
        public void Create(Order item)
        {
            db.Orders.Add(item);
        }

        public void Delete(int id)
        {
            Order or = db.Orders.Find(id);
            if (or != null)
                db.Orders.Remove(or);
        }

        public Order Get(int id)
        {
            return db.Orders.Find(id);
        }

        public IEnumerable<Order> GetAll()
        {
            return db.Orders;
        }

        public void Update(Order item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
