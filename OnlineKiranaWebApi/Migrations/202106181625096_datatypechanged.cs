namespace OnlineKirana.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class datatypechanged : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.OrderMasters", "OrderDate", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.OrderMasters", "OrderDate", c => c.DateTime(nullable: false));
        }
    }
}
