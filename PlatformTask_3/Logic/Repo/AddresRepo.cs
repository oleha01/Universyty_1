//-----------------------------------------------------------------------
// <copyright file="AddresRepo.cs" company="LNU">
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
    /// Repository design pattern for address.
    /// </summary>
    public class AddresRepo : IRepository<Address>
    {
        /// <summary>
        /// Data base.
        /// </summary>
        private BaseContext db;

        /// <summary>
        /// Initializes a new instance of the <see cref="AddresRepo" /> class.
        /// </summary>
        /// <param name="bs">Data base.</param>
        public AddresRepo(BaseContext bs)
        {
            this.db = bs;
        }

        /// <summary>
        /// Adds address.
        /// </summary>
        /// <param name="item">Address of order.</param>
        public void Create(Address item)
        {
            this.db.Addresss.Add(item);
        }

        /// <summary>
        /// Deletes address.
        /// </summary>
        /// <param name="id">Order ID.</param>
        public void Delete(int id)
        {
            Address or = this.db.Addresss.Find(id);
            if (or != null)
            {
                this.db.Addresss.Remove(or);
            }
        }

        /// <summary>
        /// Gets address of order.
        /// </summary>
        /// <param name="id">Order ID.</param>
        /// <returns>Address of order.</returns>
        public Address Get(int id)
        {
            return this.db.Addresss.Find(id);
        }

        /// <summary>
        /// Gets all addresses.
        /// </summary>
        /// <returns>All addresses.</returns>
        public IEnumerable<Address> GetAll()
        {
            return this.db.Addresss;
        }

        /// <summary>
        /// Updates address.
        /// </summary>
        /// <param name="item">Address of order.</param>
        public void Update(Address item)
        {
            this.db.Entry(item).State = EntityState.Modified;
        }
    }
}
