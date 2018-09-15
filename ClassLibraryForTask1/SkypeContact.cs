//-----------------------------------------------------------------------
// <copyright file="SkypeContact.cs" company="LNU">
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
    /// The <c>SkypeContact</c> class that iherit from the abstract <c>Contact</c> class.
    /// Contains the <c>NicknameInSkype</c> of the person.
    /// Implament <c>IFileManager</c> interface.
    /// </summary>
    public class SkypeContact : Contact, IFileManager
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SkypeContact" /> class, using the class constructor with parameter.
        /// Inherit base info from the abstrsct <see cref="Contact" /> class.
        /// </summary>
        /// <param name="name_">Person`s name.</param>
        /// <param name="nicknameInSkype_">Person`s Skype nickname.</param>
        public SkypeContact(string name_, string nicknameInSkype_) : base(name_)
        {
            this.NicknameInSkype = nicknameInSkype_;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SkypeContact" /> class, using the default class constructor.
        /// Inherit base info from the abstrsct <see cref="Contact" /> class.
        /// </summary>
        public SkypeContact() : base()
        {
            this.NicknameInSkype = string.Empty;
        }

        /// <summary>
        /// Gets or sets Skype nickname of the person.
        /// </summary>
        public string NicknameInSkype { get; set; }

        /// <summary>
        /// Reads info from the file.
        /// </summary>
        /// <param name="parth">The path to the file.</param>
        public void ReadFromFile(StreamReader parth)
        {
            string row = parth.ReadLine();
            string[] s = row.Split(' ');
            this.Name = s[0];
            this.NicknameInSkype = s[1];
        }

        /// <summary>
        /// Writes info to the file.
        /// </summary>
        /// <param name="parth">The path to the file.</param>
        public void WrtiteToFile(StreamWriter parth)
        {
            parth.WriteLine("{0}, {1}", this.Name, this.NicknameInSkype);
        }

        /// <summary>
        /// Displays info on the screen.
        /// </summary>
        /// <returns>Returns string with parson`s name and e-mail.</returns>
        public override string ToString()
        {
            return string.Format("{0}, {1}\n", this.Name, this.NicknameInSkype);
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