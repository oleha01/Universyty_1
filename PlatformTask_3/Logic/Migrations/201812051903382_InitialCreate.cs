namespace Logic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
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
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "Address2_AddressID", "dbo.Addresses");
            DropForeignKey("dbo.Orders", "Address1_AddressID", "dbo.Addresses");
            DropForeignKey("dbo.Clients", "Adress_Client_AddressID", "dbo.Addresses");
            DropIndex("dbo.Orders", new[] { "Address2_AddressID" });
            DropIndex("dbo.Orders", new[] { "Address1_AddressID" });
            DropIndex("dbo.Clients", new[] { "Adress_Client_AddressID" });
            DropTable("dbo.Orders");
            DropTable("dbo.Clients");
            DropTable("dbo.Addresses");
        }
    }
}
