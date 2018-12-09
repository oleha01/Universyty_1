//-----------------------------------------------------------------------
// <copyright file="OrderRepo.cs" company="LNU">
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
    /// Repository design pattern for order.
    /// </summary>
    public class OrderRepo : IRepository<Order>
    {
        /// <summary>
        /// Data base.
        /// </summary>
        private BaseContext db;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderRepo" /> class.
        /// </summary>
        /// <param name="bs">Data base.</param>
        public OrderRepo(BaseContext bs)
        {
            this.db = bs;
        }

        /// <summary>
        /// Adds new order.
        /// </summary>
        /// <param name="item">Order info.</param>
        public void Create(Order item)
        {
            this.db.Orders.Add(item);
        }

        /// <summary>
        /// Deletes order.
        /// </summary>
        /// <param name="id">Order ID.</param>
        public void Delete(int id)
        {
            Order or = this.db.Orders.Find(id);
            if (or != null)
            {
                this.db.Orders.Remove(or);
            }
        }

        /// <summary>
        /// Gets order info.
        /// </summary>
        /// <param name="id">Order ID.</param>
        /// <returns>Order info.</returns>
        public Order Get(int id)
        {
            return this.db.Orders.Find(id);
        }

        /// <summary>
        /// Gets all orders.
        /// </summary>
        /// <returns>All orders.</returns>
        public IEnumerable<Order> GetAll()
        {
            return this.db.Orders;
        }

        /// <summary>
        /// Update order info.
        /// </summary>
        /// <param name="item">Order info.</param>
        public void Update(Order item)
        {
            this.db.Entry(item).State = EntityState.Modified;
        }
    }
}
