namespace OnlineKirana.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tablesgenerated : DbMigration
    {
        public override void Up()
        {
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
        }
    }
}
