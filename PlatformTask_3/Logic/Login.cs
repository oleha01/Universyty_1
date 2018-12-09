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
    using System.Data.Entity;
    using System.Xml.Serialization;

    /// <summary>
    /// Encapsulates the information that needs for signing in.
    /// </summary>
    public static class Login
    {
        /// <summary>
        /// List of different orders from one client.
        /// </summary>


        /// <summary>
        /// List of users.
        /// </summary>

        public static UnitOfWork unit;


        /// <summary>
        /// Boolean that indicate if user information was changed.
        /// </summary>
        private static bool ifChanged = false;

        /// <summary>
        /// Initializes static members of the <see cref="Login" /> class.
        /// </summary>
        static Login()
        {

            unit = new UnitOfWork();

            //XmlSerializer f = new XmlSerializer(typeof(List<Client>));


        }        
   
        
    }
}