//-----------------------------------------------------------------------
// <copyright file="201812052057170_loader1122.cs" company="LNU">
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
    /// Loader migration.
    /// </summary>
    public partial class loader1122 : DbMigration
    {
        /// <summary>
        /// Creates migration.
        /// </summary>
        public override void Up()
        {
            this.DropForeignKey("dbo.Addresses", "Client_ClientID", "dbo.Clients");
            this.DropIndex("dbo.Addresses", new[] { "Client_ClientID" });
            this.DropColumn("dbo.Addresses", "Client_ClientID");
        }

        /// <summary>
        /// Cancels migration.
        /// </summary>
        public override void Down()
        {
            this.AddColumn("dbo.Addresses", "Client_ClientID", c => c.Int());
            this.CreateIndex("dbo.Addresses", "Client_ClientID");
            this.AddForeignKey("dbo.Addresses", "Client_ClientID", "dbo.Clients", "ClientID");
        }
    }
}
