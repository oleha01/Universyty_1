using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using Logic;
using System.Threading.Tasks;
using Logic.Repo;

namespace Logic
{
    public class UnitOfWork:IDisposable
    {
        private BaseContext db = new BaseContext();
        private ClientRepo cl;
        private OrderRepo or;
        private AddresRepo adr;
        public UnitOfWork()
        {
            db.Addresss.Load();
            db.Orders.Load();
        }
        public ClientRepo Clients
        {
            get
            {
                if ( cl== null)
                    cl = new ClientRepo(db);
                return cl;
            }
        }
        public OrderRepo Orders
        {
            get
            {
                if (or == null)
                    or = new OrderRepo(db);
                return or;
            }
        }
        public AddresRepo Addres
        {
            get
            {
                if (adr == null)
                    adr = new AddresRepo(db);
                return adr;
            }
        }
        public void Save()
        {
            db.SaveChanges();
        }
        private bool disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
