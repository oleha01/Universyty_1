namespace Logic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class loader : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Addresses", "Order_OrderID", c => c.Int());
            CreateIndex("dbo.Addresses", "Order_OrderID");
            AddForeignKey("dbo.Addresses", "Order_OrderID", "dbo.Orders", "OrderID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Addresses", "Order_OrderID", "dbo.Orders");
            DropIndex("dbo.Addresses", new[] { "Order_OrderID" });
            DropColumn("dbo.Addresses", "Order_OrderID");
        }
    }
}
