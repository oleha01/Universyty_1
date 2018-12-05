namespace Logic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class loader1122 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Addresses", "Client_ClientID", "dbo.Clients");
            DropIndex("dbo.Addresses", new[] { "Client_ClientID" });
            DropColumn("dbo.Addresses", "Client_ClientID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Addresses", "Client_ClientID", c => c.Int());
            CreateIndex("dbo.Addresses", "Client_ClientID");
            AddForeignKey("dbo.Addresses", "Client_ClientID", "dbo.Clients", "ClientID");
        }
    }
}
