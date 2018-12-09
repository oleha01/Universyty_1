//-----------------------------------------------------------------------
// <copyright file="IRepository.cs" company="LNU">
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
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Repository design pattern 
    /// </summary>
    /// <typeparam name="T">Some class.</typeparam>
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Gets all instances of the given class from the database.
        /// </summary>
        /// <returns>All instances of the given class.</returns>
        IEnumerable<T> GetAll();

        /// <summary>
        /// Gets instance with a given ID.
        /// </summary>
        /// <param name="id">ID of instance.</param>
        /// <returns>Detected instance.</returns>
        T Get(int id);

        /// <summary>
        /// Create the new instance of the given class.
        /// </summary>
        /// <param name="item">Info about new instance.</param>
        void Create(T item);

        /// <summary>
        /// Updates the given instance.
        /// </summary>
        /// <param name="item">Instance to update.</param>
        void Update(T item);

        /// <summary>
        /// Deletes instance with a given ID.
        /// </summary>
        /// <param name="id">ID of instance to delete.</param>
        void Delete(int id);
    }
}
