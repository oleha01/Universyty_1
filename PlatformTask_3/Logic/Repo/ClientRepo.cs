using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Repo
{
    public class ClientRepo : IRepository<Client>
    {
        private BaseContext db;
        public ClientRepo(BaseContext bs)
        {
            db = bs;
        }
        public void Create(Client item)
        {
            db.Clients.Add(item);
        }

        public void Delete(int id)
        {
            Client cl = db.Clients.Find(id);
            if (cl != null)
                db.Clients.Remove(cl);
        }

        public Client Get(int id)
        {
            return db.Clients.Find(id);
        }

        public IEnumerable<Client> GetAll()
        {
            return db.Clients;
        }

        public void Update(Client item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
