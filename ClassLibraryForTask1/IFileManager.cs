//-----------------------------------------------------------------------
// <copyright file="IFileManager.cs" company="LNU">
//     Copyright (c) Top Coders. All rights reserved.
// </copyright>
// <author>Burdein Irina</author>
// <author>Butry Oleg</author>
// <author>Ivanova Antonina</author>
// <author>Koltun Roman</author>
// <date> " + DateTime.Now + @"</date>
//-----------------------------------------------------------------------
using System;
using System.IO;

namespace Task1
{
    /// <summary>
    /// The interface <c>IFileManager</c> that inherites from interface <c>IComparable</c>.
    /// Helps to read and write to a file.
    /// </summary>
    public interface IFileManager : IComparable
    {
        /// <summary>
        /// Gets or sets the name of person.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Reads info from the file.
        /// </summary>
        /// <param name="path">The path to the file.</param>
        void ReadFromFile(StreamReader path);

        /// <summary>
        /// Writes info to the file.
        /// </summary>
        /// <param name="path">The path to the file.</param>
        void WrtiteToFile(StreamWriter path);
    }
}
