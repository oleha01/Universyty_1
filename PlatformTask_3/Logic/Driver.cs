//-----------------------------------------------------------------------
// <copyright file="Driver.cs" company="LNU">
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

    /// <summary>
    /// Encapsulates the information about the driver.
    /// </summary>
    public class Driver
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Driver" /> class.
        /// </summary>
        public Driver()
        {
            this.Name = string.Empty;
            this.Id = string.Empty;
            this.SurName = string.Empty;
            this.CarCl = CarClass.Universal;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Driver" /> class.
        /// </summary>
        /// <param name="n">The first name of the driver.</param>
        /// <param name="id">The driver`s id.</param>
        /// <param name="sur">The last name of the driver.</param>
        /// <param name="car">The driver`s car.</param>
        public Driver(string n, string id, string sur, CarClass car = CarClass.Econom)
        {
            this.Name = n;
            this.Id = id;
            this.SurName = sur;
            this.CarCl = car;
        }

        /// <summary>
        /// Gets or sets the first name of the driver.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the last name of the driver.
        /// </summary>
        public string SurName { get; set; }

        /// <summary>
        /// Gets or sets the driver`s id.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the information about the driver`s car.
        /// </summary>
        public CarClass CarCl { get; set; }

        /// <summary>
        /// Shows the information about the driver.
        /// </summary>
        /// <returns>Returns the information about the driver as the string.</returns>
        public override string ToString()
        {
            return string.Format("Name: {0}, SurName: {1}, ClassCar: {2} ;", this.Name, this.SurName, this.CarCl);
        }
    }
}