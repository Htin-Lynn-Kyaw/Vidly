namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DebuggRental : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Rentals", "ReturnDate", c => c.DateTime());
            AlterColumn("dbo.Rentals", "RentalDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Rentals", "RentalDate", c => c.DateTime());
            AlterColumn("dbo.Rentals", "ReturnDate", c => c.DateTime(nullable: false));
        }
    }
}
