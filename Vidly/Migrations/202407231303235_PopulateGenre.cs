namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenre : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (ID, Name) VALUES (1, 'Action');");
            Sql("INSERT INTO Genres (ID, Name) VALUES (2, 'Comedy');");
            Sql("INSERT INTO Genres (ID, Name) VALUES (3, 'Drama');");
            Sql("INSERT INTO Genres (ID, Name) VALUES (4, 'Horror');");
            Sql("INSERT INTO Genres (ID, Name) VALUES (5, 'Science Fiction');");
        }
        
        public override void Down()
        {
        }
    }
}
