//-----------------------------------------------------------------------
// <copyright file="UnitOfWork.cs" company="LNU">
//     Copyright (c) Top Coders. All rights reserved.
// </copyright>
// <author>Burdein Irina</author>
// <author>Butry Oleg</author>
// <author>Ivanova Antonina</author>
// <author>Koltun Roman</author>
// <date> " + DateTime.Now + @"</date>
//-----------------------------------------------------------------------

namespace Logic
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Logic;
    using Logic.Repo;

    /// <summary>
    /// Unit of Work Design Pattern.
    /// </summary>
    public class UnitOfWork : IDisposable
    {
        /// <summary>
        /// Connect to the database.
        /// </summary>
        private BaseContext db = new BaseContext();

        /// <summary>
        /// Client repository.
        /// </summary>
        private ClientRepo cl;

        /// <summary>
        /// Order repository.
        /// </summary>
        private OrderRepo or;

        /// <summary>
        /// Address repository.
        /// </summary>
        private AddresRepo adr;

        /// <summary>
        /// Boolean that indicates whether this instance is disposed of.
        /// </summary>
        private bool disposed = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWork" /> class.
        /// </summary>
        public UnitOfWork()
        {
            this.db.Addresss.Load();
            this.db.Orders.Load();
        }

        /// <summary>
        /// Gets client`s info.
        /// </summary>
        public ClientRepo Clients
        {
            get
            {
                if (this.cl == null)
                {
                    this.cl = new ClientRepo(this.db);
                }

                return this.cl;
            }
        }

        /// <summary>
        /// Gets order info.
        /// </summary>
        public OrderRepo Orders
        {
            get
            {
                if (this.or == null)
                {
                    this.or = new OrderRepo(this.db);
                }

                return this.or;
            }
        }

        /// <summary>
        /// Gets address info.
        /// </summary>
        public AddresRepo Addres
        {
            get
            {
                if (this.adr == null)
                {
                    this.adr = new AddresRepo(this.db);
                }

                return this.adr;
            }
        }

        /// <summary>
        /// Save changes.
        /// </summary>
        public void Save()
        {
            this.db.SaveChanges();
        }

        /// <summary>
        /// Disposes of the current instance.
        /// </summary>
        /// <param name="disposing">Boolean that indicates whether this instance is disposed of.</param>
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this.db.Dispose();
                }

                this.disposed = true;
            }
        }

        /// <summary>
        /// Disposes of the current instance.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}