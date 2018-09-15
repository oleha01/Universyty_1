//-----------------------------------------------------------------------
// <copyright file="Interface1.cs" company="LNU">
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
    public interface IFileManager : IComparable
    {
        string Name { get; set; }

        void ReadFromFile(StreamReader parth);

        void WrtiteToFile(StreamWriter parth);
    }
}
