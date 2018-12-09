//-----------------------------------------------------------------------
// <copyright file="ClientRepo.cs" company="LNU">
//     Copyright (c) Top Coders. All rights reserved.
// </copyright>
// <author>Burdein Irina</author>
// <author>Butry Oleg</author>
// <author>Ivanova Antonina</author>
// <author>Koltun Roman</author>
// <date> " + DateTime.Now + @"</date>
//-----------------------------------------------------------------------
namespace Logic.Repo
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Repository design pattern for client.
    /// </summary>
    public class ClientRepo : IRepository<Client>
    {
        /// <summary>
        /// Data base.
        /// </summary>
        private BaseContext db;

        /// <summary>
        /// Initializes a new instance of the <see cref="ClientRepo" /> class.
        /// </summary>
        /// <param name="bs">Data base.</param>
        public ClientRepo(BaseContext bs)
        {
            this.db = bs;
        }

        /// <summary>
        /// Adds client info.
        /// </summary>
        /// <param name="item">Current client.</param>
        public void Create(Client item)
        {
            this.db.Clients.Add(item);
        }

        /// <summary>
        /// Deletes client info.
        /// </summary>
        /// <param name="id">Order ID.</param>
        public void Delete(int id)
        {
            Client cl = this.db.Clients.Find(id);
            if (cl != null)
            {
                this.db.Clients.Remove(cl);
            }
        }

        /// <summary>
        /// Gets client info.
        /// </summary>
        /// <param name="id">Order ID.</param>
        /// <returns>Client info.</returns>
        public Client Get(int id)
        {
            return this.db.Clients.Find(id);
        }

        /// <summary>
        /// Gets all clients.
        /// </summary>
        /// <returns>All clients.</returns>
        public IEnumerable<Client> GetAll()
        {
            return this.db.Clients;
        }

        /// <summary>
        /// Updates client info.
        /// </summary>
        /// <param name="item">Current client.</param>
        public void Update(Client item)
        {
            this.db.Entry(item).State = EntityState.Modified;
        }
    }
}
