namespace OnlineKirana.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tablesadded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        MobileNumber = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.CustomerID);
            
            CreateTable(
                "dbo.DeliveryAddresses",
                c => new
                    {
                        AddressID = c.Int(nullable: false, identity: true),
                        AddressLine1 = c.String(),
                        AddressLine2 = c.String(),
                        City = c.String(),
                        State = c.String(),
                        PinCode = c.Int(nullable: false),
                        CustomerID = c.Int(),
                    })
                .PrimaryKey(t => t.AddressID)
                .ForeignKey("dbo.Customers", t => t.CustomerID)
                .Index(t => t.CustomerID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderID = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Amount = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                        ProductID = c.Int(),
                        OrderMasterID = c.Int(nullable: false),
                        DeliveryAddress_AddressID = c.Int(),
                    })
                .PrimaryKey(t => t.OrderID)
                .ForeignKey("dbo.OrderMasters", t => t.OrderID)
                .ForeignKey("dbo.Products", t => t.ProductID)
                .ForeignKey("dbo.DeliveryAddresses", t => t.DeliveryAddress_AddressID)
                .Index(t => t.OrderID)
                .Index(t => t.ProductID)
                .Index(t => t.DeliveryAddress_AddressID);
            
            CreateTable(
                "dbo.OrderMasters",
                c => new
                    {
                        OrderMasterID = c.Int(nullable: false, identity: true),
                        OrderDate = c.DateTime(nullable: false),
                        OrderStatus = c.String(),
                        PaymentMode = c.String(),
                        TotalAmount = c.Int(nullable: false),
                        PaymentStatus = c.String(),
                        DeliveryStatus = c.String(),
                        OrderType = c.String(),
                        ProductID = c.Int(),
                        CustomerID = c.Int(),
                        AddressID = c.Int(),
                    })
                .PrimaryKey(t => t.OrderMasterID)
                .ForeignKey("dbo.Customers", t => t.CustomerID)
                .ForeignKey("dbo.DeliveryAddresses", t => t.AddressID)
                .ForeignKey("dbo.Products", t => t.ProductID)
                .Index(t => t.ProductID)
                .Index(t => t.CustomerID)
                .Index(t => t.AddressID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "DeliveryAddress_AddressID", "dbo.DeliveryAddresses");
            DropForeignKey("dbo.Orders", "ProductID", "dbo.Products");
            DropForeignKey("dbo.Orders", "OrderID", "dbo.OrderMasters");
            DropForeignKey("dbo.OrderMasters", "ProductID", "dbo.Products");
            DropForeignKey("dbo.OrderMasters", "AddressID", "dbo.DeliveryAddresses");
            DropForeignKey("dbo.OrderMasters", "CustomerID", "dbo.Customers");
            DropForeignKey("dbo.DeliveryAddresses", "CustomerID", "dbo.Customers");
            DropIndex("dbo.OrderMasters", new[] { "AddressID" });
            DropIndex("dbo.OrderMasters", new[] { "CustomerID" });
            DropIndex("dbo.OrderMasters", new[] { "ProductID" });
            DropIndex("dbo.Orders", new[] { "DeliveryAddress_AddressID" });
            DropIndex("dbo.Orders", new[] { "ProductID" });
            DropIndex("dbo.Orders", new[] { "OrderID" });
            DropIndex("dbo.DeliveryAddresses", new[] { "CustomerID" });
            DropTable("dbo.OrderMasters");
            DropTable("dbo.Orders");
            DropTable("dbo.DeliveryAddresses");
            DropTable("dbo.Customers");
        }
    }
}
