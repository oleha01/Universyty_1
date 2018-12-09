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
    /// Encapsulates the information about the order to use in database.
    /// </summary>
    public class OrderModel
    {
        /// <summary>
        /// Boolean that indicate whether the address is final.
        /// </summary>
        private bool isFinalAddress = false;

        /// <summary>
        /// Order ID.
        /// </summary>
        private int orderID;

        /// <summary>
        /// Address of order.
        /// </summary>
        private Address address2;

        /// <summary>
        /// Gets or sets client ID.
        /// </summary>
        public static int ID { get; set; }

        /// <summary>
        /// Gets or sets order time.
        /// </summary>
        public string Time { get; set; }

        /// <summary>
        /// Gets or sets phone number.
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets client name.
        /// </summary>
        public string ClientName { get; set; }

        /// <summary>
        /// Gets or sets address.
        /// </summary>
        public Address Address1 { get; set; }

        /// <summary>
        /// Gets or sets additional wishes to order.
        /// </summary>
        public string Wishes { get; set; }
    }
}
