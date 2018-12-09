//-----------------------------------------------------------------------
// <copyright file="OrderModel.cs" company="LNU">
//     Copyright (c) Top Coders. All rights reserved.
// </copyright>
// <author>Burdein Irina</author>
// <author>Butry Oleg</author>
// <author>Ivanova Antonina</author>
// <author>Koltun Roman</author>
// <date> " + DateTime.Now + @"</date>
//-----------------------------------------------------------------------
namespace Logic.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Additional order class.
    /// </summary>
    public class OrderModel
    {
        /// <summary>
        /// Client ID.
        /// </summary>
        private static int id;

        /// <summary>
        /// Boolean that indicate whether the address is final.
        /// </summary>
        private bool isFinalAddress = false;

        /// <summary>
        /// OrderModel ID.
        /// </summary>
        private int orderID;

        /// <summary>
        /// Address of order.
        /// </summary>
        private Address address2;

        /// <summary>
        /// Gets or sets time of order.
        /// </summary>
        public string Time { get; set; }

        /// <summary>
        /// Gets or sets phone number of client.
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets client`s name.
        /// </summary>
        public string ClientName { get; set; }

        /// <summary>
        /// Gets or sets address.
        /// </summary>
        public Address Address1 { get; set; }

        /// <summary>
        /// Gets or sets additional wishes.
        /// </summary>
        public string Wishes { get; set; }
    }
}
