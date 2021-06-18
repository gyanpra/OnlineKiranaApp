namespace OnlineKirana.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tablesadded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        AdminID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.AdminID);
            
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
                        CustomerID = c.Int(nullable: false),
                        AddressLine1 = c.String(),
                        AddressLine2 = c.String(),
                        City = c.String(),
                        State = c.String(),
                        PinCode = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AddressID);
            
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        ImageID = c.Int(nullable: false, identity: true),
                        ImageCaption = c.String(),
                        ImageName = c.String(),
                    })
                .PrimaryKey(t => t.ImageID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderID = c.Int(nullable: false, identity: true),
                        ProductID = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Amount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderID);
            
            CreateTable(
                "dbo.OrderMasters",
                c => new
                    {
                        OrderMasterID = c.Int(nullable: false, identity: true),
                        OrderID = c.Int(nullable: false),
                        AddressID = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                        OrderDate = c.DateTime(nullable: false),
                        OrderStatus = c.String(),
                        PaymentMode = c.String(),
                        PaymentStatus = c.String(),
                        DeliveryStatus = c.String(),
                        OrderType = c.String(),
                    })
                .PrimaryKey(t => t.OrderMasterID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductID = c.Int(nullable: false, identity: true),
                        ProductName = c.String(),
                        Category = c.String(),
                        Brand = c.String(),
                        Price = c.Int(nullable: false),
                        ProductImage = c.String(),
                        QuantityOnHand = c.Int(nullable: false),
                        ReOrderLevel = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Products");
            DropTable("dbo.OrderMasters");
            DropTable("dbo.Orders");
            DropTable("dbo.Images");
            DropTable("dbo.DeliveryAddresses");
            DropTable("dbo.Customers");
            DropTable("dbo.Admins");
        }
    }
}
