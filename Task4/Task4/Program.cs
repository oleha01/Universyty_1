//-----------------------------------------------------------------------
// <copyright file="Program.cs" company="LNU">
//     Copyright (c) Top Coders. All rights reserved.
// </copyright>
// <author>Burdein Irina</author>
// <author>Butry Oleg</author>
// <author>Ivanova Antonina</author>
// <author>Koltun Roman</author>
// <date> " + DateTime.Now + @"</date>
//-----------------------------------------------------------------------

namespace Task4
{
    using System;
    using System.Configuration;

    /// <summary>
    /// Main program.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Delegate for queries.
        /// </summary>
        public delegate void Que();

        /// <summary>
        /// The entry point of program.
        /// </summary>
        /// <param name="args">Collection of Strings, separated by a space, which can be typed into the program on the terminal.</param>
        public static void Main(string[] args)
        {
            Queries que = new Queries(ConfigurationManager.ConnectionStrings["NorthwindConnectionString"].ConnectionString);

            //   que.RunAll();
            ////que.Q34();
            que.Q20();
             que.connection.Close();
            Console.ReadKey();
        }
    }
}
