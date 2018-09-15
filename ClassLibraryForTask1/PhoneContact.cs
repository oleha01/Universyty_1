//-----------------------------------------------------------------------
// <copyright file="PhoneContact.cs" company="LNU">
//     Copyright (c) Top Coders. All rights reserved.
// </copyright>
// <author>Burdein Irina</author>
// <author>Butry Oleg</author>
// <author>Ivanova Antonina</author>
// <author>Koltun Roman</author>
// <date> " + DateTime.Now + @"</date>
//-----------------------------------------------------------------------
using System.IO;

namespace Task1
{
    /// <summary>
    /// The <c>PhoneContact</c> class that iherit from the abstract <c>Contact</c> class.
    /// Contains the <c>Phone</c> of the person.
    /// Implament <c>IFileManager</c> interface.
    /// </summary>
    public class PhoneContact : Contact, IFileManager
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PhoneContact" /> class, using the class constructor with parameter.
        /// Inherit base info from the abstrsct <see cref="Contact" /> class.
        /// </summary>
        /// <param name="name_">Parson`s name.</param>
        /// <param name="number_">Parson`s number.</param>
        public PhoneContact(string name_, string number_) : base(name_)
        {
            this.Number = number_;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PhoneContact" /> class, using the default class constructor.
        /// Inherit base info from the abstrsct <see cref="Contact" /> class.
        /// </summary>
        public PhoneContact() : base()
        {
            this.Number = string.Empty;
        }

        /// <summary>
        /// Gets or sets
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// Reads info from the file.
        /// </summary>
        /// <param name="parth">The path to the file.</param>
        public void ReadFromFile(StreamReader parth)
        {
            string row = parth.ReadLine();
            string[] s = row.Split(' ');
            this.Name = s[0];
            this.Number = s[1];
        }

        /// <summary>
        /// Writes info to the file.
        /// </summary>
        /// <param name="parth">The path to the file.</param>
        public void WrtiteToFile(StreamWriter parth)
        {
            parth.WriteLine("{0}, {1}", this.Name, this.Number);
        }

        /// <summary>
        /// Displays info on the screen.
        /// </summary>
        /// <returns>Returns string with parson`s name and e-mail.</returns>
        public override string ToString()
        {
            return string.Format("{0}, {1}\n", this.Name, this.Number);
        }

        /// <summary>
        /// Compares names in an alphabetical order.
        /// </summary>
        /// <param name="obj">The object to compare.</param>
        /// <returns>Retuns boolean value of comparison.</returns>
        public int CompareTo(object obj)
        {
            var element2 = obj as IFileManager;
            return string.Compare(this.Name, element2.Name);
        }
    }
}
