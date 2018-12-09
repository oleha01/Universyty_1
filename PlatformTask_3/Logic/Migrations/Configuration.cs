//-----------------------------------------------------------------------
// <copyright file="Configuration.cs" company="LNU">
//     Copyright (c) Top Coders. All rights reserved.
// </copyright>
// <author>Burdein Irina</author>
// <author>Butry Oleg</author>
// <author>Ivanova Antonina</author>
// <author>Koltun Roman</author>
// <date> " + DateTime.Now + @"</date>
//-----------------------------------------------------------------------
namespace Logic.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    /// <summary>
    /// Configuration relating to the use of migrations for a given model. 
    /// </summary>
    internal sealed class Configuration : DbMigrationsConfiguration<Logic.BaseContext>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Configuration" /> class.
        /// </summary>
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = false;
            this.ContextKey = "Logic.BaseContext";
        }

        /// <summary>
        /// This method will be called after migrating to the latest version.
        /// </summary>
        /// <param name="context">Class for database.</param>
        protected override void Seed(Logic.BaseContext context)
        {
            //// You can use the DbSet<T>.AddOrUpdate() helper extension method to avoid creating duplicate seed data.
        }
    }
}
