//-----------------------------------------------------------------------
// <copyright file="Contact.cs" company="LNU">
//     Copyright (c) Top Coders. All rights reserved.
// </copyright>
// <author>Burdein Irina</author>
// <author>Butry Oleg</author>
// <author>Ivanova Antonina</author>
// <author>Koltun Roman</author>
// <date> " + DateTime.Now + @"</date>
//-----------------------------------------------------------------------
namespace Task1
{
    /// <summary>
    /// 
    /// </summary>
    public class Contact
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name_"></param>
        public Contact(string name_)
        {
            this.Name = name_;
        }

        /// <summary>
        /// 
        /// </summary>
        public Contact()
        {
            this.Name = string.Empty;
        }

        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }
    }
}