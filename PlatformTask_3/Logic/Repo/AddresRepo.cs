using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Repo
{
   public class AddresRepo : IRepository<Address>
    {
        private BaseContext db;
        public AddresRepo(BaseContext bs)
        {
            db = bs;
        }
        public void Create(Address item)
        {
            db.Addresss.Add(item);
        }

        public void Delete(int id)
        {
            Address or = db.Addresss.Find(id);
            if (or != null)
                db.Addresss.Remove(or);
        }

        public Address Get(int id)
        {
            return db.Addresss.Find(id);
        }

        public IEnumerable<Address> GetAll()
        {
            return db.Addresss;
        }

        public void Update(Address item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
