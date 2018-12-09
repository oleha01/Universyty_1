//-----------------------------------------------------------------------
// <copyright file="Loader1122.cs" company="LNU">
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
    using System.Data.Entity.Migrations;

    /// <summary>
    /// Loader for migration 3.
    /// </summary>
    public partial class Loader1122 : DbMigration
    {
        /// <summary>
        /// Create migration.
        /// </summary>
        public override void Up()
        {
            this.DropForeignKey("dbo.Addresses", "Client_ClientID", "dbo.Clients");
            this.DropIndex("dbo.Addresses", new[] { "Client_ClientID" });
            this.DropColumn("dbo.Addresses", "Client_ClientID");
        }

        /// <summary>
        /// Cancel migration.
        /// </summary>
        public override void Down()
        {
            this.AddColumn("dbo.Addresses", "Client_ClientID", c => c.Int());
            this.CreateIndex("dbo.Addresses", "Client_ClientID");
            this.AddForeignKey("dbo.Addresses", "Client_ClientID", "dbo.Clients", "ClientID");
        }
    }
}
