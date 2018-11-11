﻿//-----------------------------------------------------------------------
// <copyright file="Login.cs" company="LNU">
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
    using System.Collections.Generic;
    using System.IO;
    using System.Xml.Serialization;

    /// <summary>
    /// Encapsulates the information that needs for signing in.
    /// </summary>
    public static class Login
    {
        /// <summary>
        /// List of users.
        /// </summary>
        private static List<Client> users;

        /// <summary>
        /// Gets or sets path for user information.
        /// </summary>
        public static string PathUsers { get; set; }
        static bool ifChanged = false;
        public static List<Client> Users { get { ifChanged = true; return users; } set { users = value; } }
        public static List<Order> orders;


        /// <summary>
        /// Boolean that indicate if user information was changed.
        /// </summary>
        private static bool ifChanged = false;

        /// <summary>
        /// Initializes static members of the <see cref="Login" /> class.
        /// </summary>
        static Login()
        {
            PathPassword = "password.txt";

            PathUsers = "orders.txt";
            XmlSerializer f = new XmlSerializer(typeof(List<Client>));
            XmlSerializer f1 = new XmlSerializer(typeof(List<Order>));
 


            using (FileStream sr = new FileStream(PathPassword, FileMode.OpenOrCreate))

            {
                try
                {
                    users = f.Deserialize(sr) as List<Client>;
                }
                catch
                {
                    users = new List<Client>();
                }
            }

            using (FileStream sr = new FileStream(PathUsers, FileMode.OpenOrCreate))
            {
                try
                {
                    orders = f1.Deserialize(sr) as List<Order>;
                }
                catch
                {
                    orders = new List<Order>();
                }
            }


        }
        }

        /// <summary>
        /// Gets or sets path for password.
        /// </summary>
        public static string PathPassword { get; set; }

        /// <summary>
        /// Gets or sets path for user information.
        /// </summary>
        public static string PathUsers { get; set; }

        /// <summary>
        /// Gets or sets list of users.
        /// </summary>
        public static List<Client> Users
        {
            get
            {
                ifChanged = true;
                return users;
            }

            set
            {
                users = value;
            }
        }

        /// <summary>
        /// Serializes clients and paths.
        /// </summary>

        public static void Seria()
        {
            XmlSerializer f = new XmlSerializer(typeof(List<Client>));
            using (FileStream sr = new FileStream(PathPassword, FileMode.OpenOrCreate))
            {
                f.Serialize(sr, users);
            }
        }
        public static void SeriaOrd()
        {
            XmlSerializer f1 = new XmlSerializer(typeof(List<Order>));
            using (FileStream sr = new FileStream(PathUsers, FileMode.OpenOrCreate))
            {
                f1.Serialize(sr, orders);
            }
        }
    }
}