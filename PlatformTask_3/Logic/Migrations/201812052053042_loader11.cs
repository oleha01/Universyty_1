namespace Logic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class loader11 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Addresses", "Order_OrderID", "dbo.Orders");
            DropIndex("dbo.Addresses", new[] { "Order_OrderID" });
            AddColumn("dbo.Addresses", "Client_ClientID", c => c.Int());
            CreateIndex("dbo.Addresses", "Client_ClientID");
            AddForeignKey("dbo.Addresses", "Client_ClientID", "dbo.Clients", "ClientID");
            DropColumn("dbo.Addresses", "Order_OrderID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Addresses", "Order_OrderID", c => c.Int());
            DropForeignKey("dbo.Addresses", "Client_ClientID", "dbo.Clients");
            DropIndex("dbo.Addresses", new[] { "Client_ClientID" });
            DropColumn("dbo.Addresses", "Client_ClientID");
            CreateIndex("dbo.Addresses", "Order_OrderID");
            AddForeignKey("dbo.Addresses", "Order_OrderID", "dbo.Orders", "OrderID");
        }
    }
}
