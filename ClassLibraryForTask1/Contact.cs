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
    /// The abstract <c>Contact</c> class.
    /// Contains the <c>Name</c> of the person.
    /// </summary>
    public class Contact
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Contact" /> class, using the class constructor with parameter.
        /// </summary>
        /// <param name="name_">Person`s name.</param>
        public Contact(string name_)
        {
            this.Name = name_;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Contact" /> class, using the default class constructor.
        /// </summary>
        public Contact()
        {
            this.Name = string.Empty;
        }

        /// <summary>
        /// Gets or sets the name of person.
        /// </summary>
        public string Name { get; set; }
    }
}