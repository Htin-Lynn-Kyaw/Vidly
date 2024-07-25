namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterRental : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Rentals", name: "Customer_Id", newName: "CustomerID");
            RenameColumn(table: "dbo.Rentals", name: "Movie_Id", newName: "MovieID");
            RenameIndex(table: "dbo.Rentals", name: "IX_Customer_Id", newName: "IX_CustomerID");
            RenameIndex(table: "dbo.Rentals", name: "IX_Movie_Id", newName: "IX_MovieID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Rentals", name: "IX_MovieID", newName: "IX_Movie_Id");
            RenameIndex(table: "dbo.Rentals", name: "IX_CustomerID", newName: "IX_Customer_Id");
            RenameColumn(table: "dbo.Rentals", name: "MovieID", newName: "Movie_Id");
            RenameColumn(table: "dbo.Rentals", name: "CustomerID", newName: "Customer_Id");
        }
    }
}
