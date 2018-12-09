//-----------------------------------------------------------------------
// <copyright file="Loader.cs" company="LNU">
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
    public partial class Loader : DbMigration
    {
        /// <summary>
        /// Create migration.
        /// </summary>
        public override void Up()
        {
            this.AddColumn("dbo.Addresses", "Order_OrderID", c => c.Int());
            this.CreateIndex("dbo.Addresses", "Order_OrderID");
            this.AddForeignKey("dbo.Addresses", "Order_OrderID", "dbo.Orders", "OrderID");
        }
        
        /// <summary>
        /// Cancel migration.
        /// </summary>
        public override void Down()
        {
            this.DropForeignKey("dbo.Addresses", "Order_OrderID", "dbo.Orders");
            this.DropIndex("dbo.Addresses", new[] { "Order_OrderID" });
            this.DropColumn("dbo.Addresses", "Order_OrderID");
        }
    }
}
