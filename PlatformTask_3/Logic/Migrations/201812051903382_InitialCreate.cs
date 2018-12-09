//-----------------------------------------------------------------------
// <copyright file="201812051903382_InitialCreate.cs" company="LNU">
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
    /// Creates initial migration.
    /// </summary>
    public partial class InitialCreate : DbMigration
    {
        /// <summary>
        /// Creates migration.
        /// </summary>
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        AddressID = c.Int(nullable: false, identity: true),
                        City = c.String(),
                        Street = c.String(),
                        House = c.String(),
                        Entrance = c.String(),
                    })
                .PrimaryKey(t => t.AddressID);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        ClientID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        LastName = c.String(),
                        Login = c.String(),
                        Password = c.String(),
                        Phone = c.String(),
                        Adress_Client_AddressID = c.Int(),
                    })
                .PrimaryKey(t => t.ClientID)
                .ForeignKey("dbo.Addresses", t => t.Adress_Client_AddressID)
                .Index(t => t.Adress_Client_AddressID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderID = c.Int(nullable: false, identity: true),
                        Time = c.String(),
                        PhoneNumber = c.String(),
                        ClientName = c.String(),
                        Wishes = c.String(),
                        Address1_AddressID = c.Int(),
                        Address2_AddressID = c.Int(),
                    })
                .PrimaryKey(t => t.OrderID)
                .ForeignKey("dbo.Addresses", t => t.Address1_AddressID)
                .ForeignKey("dbo.Addresses", t => t.Address2_AddressID)
                .Index(t => t.Address1_AddressID)
                .Index(t => t.Address2_AddressID);
        }

        /// <summary>
        /// Cancels migration.
        /// </summary>
        public override void Down()
        {
            this.DropForeignKey("dbo.Orders", "Address2_AddressID", "dbo.Addresses");
            this.DropForeignKey("dbo.Orders", "Address1_AddressID", "dbo.Addresses");
            this.DropForeignKey("dbo.Clients", "Adress_Client_AddressID", "dbo.Addresses");
            this.DropIndex("dbo.Orders", new[] { "Address2_AddressID" });
            this.DropIndex("dbo.Orders", new[] { "Address1_AddressID" });
            this.DropIndex("dbo.Clients", new[] { "Adress_Client_AddressID" });
            this.DropTable("dbo.Orders");
            this.DropTable("dbo.Clients");
            this.DropTable("dbo.Addresses");
        }
    }
}
