namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAvaliableStockInMovie : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "AvailableStock", c => c.Int(nullable: false));
            Sql("UPDATE Movies SET AvailableStock = NumberOfStock");
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "AvailableStock");
        }
    }
}
