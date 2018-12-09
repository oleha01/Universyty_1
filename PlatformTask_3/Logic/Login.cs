//-----------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.IO;
    using System.Xml.Serialization;

    /// <summary>
    /// Encapsulates the information that needs for signing in.
    /// </summary>
    public static class Login
    {
        /// <summary>
        /// Boolean that indicate if user information was changed.
        /// </summary>
        private static bool ifChanged = false;

        /// <summary>
        /// Initializes static members of the <see cref="Login" /> class.
        /// </summary>
        static Login()
        {
            BS = new BaseContext();

            ////XmlSerializer f = new XmlSerializer(typeof(List<Client>));
        }

        /// <summary>
        /// Gets or sets the list of users.
        /// </summary>
        public static BaseContext BS { get; set; }
    }
}