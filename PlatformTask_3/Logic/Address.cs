//-----------------------------------------------------------------------
// <copyright file="Address.cs" company="LNU">
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
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Encapsulates the physical address of the user.
    /// </summary>
    [Serializable]
    public class Address
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Address" /> class.
        /// </summary>
        public Address()
        {
            this.City = string.Empty;
            this.Street = string.Empty;
            this.House = string.Empty;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Address" /> class.
        /// </summary>
        /// <param name="city">The name of the city.</param>
        /// <param name="street">The name of the street.</param>
        /// <param name="house">The number of the house.</param>
        /// <param name="entrance">The number of the entrance.</param>
        public Address(string city, string street, string house, string entrance)
        {
            this.City = city;
            this.Street = street;
            this.House = house;
            this.Entrance = entrance;
        }
        public virtual ICollection<Client> Clients { get; set; }
        [Key]
        public int AddressID { get; set; }

        /// <summary>
        /// Gets or sets the name of the city.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the name of the street.
        /// </summary>
        public string Street { get; set; }

        /// <summary>
        /// Gets or sets the number of the house.
        /// </summary>
        public string House { get; set; }

        /// <summary>
        /// Gets or sets the number of the entrance.
        /// </summary>
        public string Entrance { get; set; }

        /// <summary>
        /// Shows the address of the user.
        /// </summary>
        /// <returns>Returns the address as the string.</returns>
        public override string ToString()
        {
            return string.Format("{0}, st.{1}, {2}", this.City, this.Street, this.House);
        }
    }
}