//-----------------------------------------------------------------------
// <copyright file="201812052053042_loader11.cs" company="LNU">
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
    public partial class loader11 : DbMigration
    {
        /// <summary>
        /// Creates migration.
        /// </summary>
        public override void Up()
        {
            this.DropForeignKey("dbo.Addresses", "Order_OrderID", "dbo.Orders");
            this.DropIndex("dbo.Addresses", new[] { "Order_OrderID" });
            this.AddColumn("dbo.Addresses", "Client_ClientID", c => c.Int());
            this.CreateIndex("dbo.Addresses", "Client_ClientID");
            this.AddForeignKey("dbo.Addresses", "Client_ClientID", "dbo.Clients", "ClientID");
            this.DropColumn("dbo.Addresses", "Order_OrderID");
        }

        /// <summary>
        /// Cancels migration.
        /// </summary>
        public override void Down()
        {
            this.AddColumn("dbo.Addresses", "Order_OrderID", c => c.Int());
            this.DropForeignKey("dbo.Addresses", "Client_ClientID", "dbo.Clients");
            this.DropIndex("dbo.Addresses", new[] { "Client_ClientID" });
            this.DropColumn("dbo.Addresses", "Client_ClientID");
            this.CreateIndex("dbo.Addresses", "Order_OrderID");
            this.AddForeignKey("dbo.Addresses", "Order_OrderID", "dbo.Orders", "OrderID");
        }
    }
}
