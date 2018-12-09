//-----------------------------------------------------------------------
// <copyright file="Client.cs" company="LNU">
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
    /// Encapsulates the information about the user.
    /// </summary>
    [Serializable]
    public class Client
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Client" /> class.
        /// </summary>
        public Client()
        {
            this.Name = string.Empty;
            this.LastName = string.Empty;
            this.Login = string.Empty;
            this.Password = string.Empty;
            this.Phone = string.Empty;
            this.Adress_Client = new Address();
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="Client" /> class.
        /// </summary>
        /// <param name="name">The first name of the user.</param>
        /// <param name="lastname">The last name of the user.</param>
        /// <param name="login">The login of the user account.</param>
        /// <param name="passwrod">The password of the user account.</param>
        /// <param name="phone">The phone number of the user.</param>
        /// <param name="ad">The address of the user.</param>
        public Client(string name, string lastname, string login, string passwrod, string phone, Address ad)
        {
            this.Name = name;
            this.LastName = lastname;
            this.Login = login;
            this.Password = passwrod;
            this.Phone = phone;
            this.Adress_Client = new Address();
            this.Adress_Client = ad;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Client" /> class.
        /// </summary>
        /// <param name="name">Client`s name.</param>
        /// <param name="phone">Client`s phone number.</param>
        public Client(string name, string phone)
        {
            this.Name = name;
            this.Phone = phone;
        }

        /// <summary>
        /// Gets or sets client id.
        /// </summary>
        [Key]
        public int ClientID { get; set; }

        /// <summary>
        /// Gets or sets the first name of the user.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the last name of the user.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the login of the user account.
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Gets or sets the password of the user account.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the phone number of the user.
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Gets or sets the address of the user.
        /// </summary>
        public Address Adress_Client { get; set; }

        /// <summary>
        /// Shows the information about the user.
        /// </summary>
        /// <returns>Returns the information about the user as the string.</returns>
        public override string ToString()
        {
            return string.Format("{0}, {1}, {2},{3},{4}", this.Name, this.LastName, this.Login, this.Password, this.Phone);
        }
    }
}