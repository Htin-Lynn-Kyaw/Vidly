namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterMembershipType : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MembershipTypes SET Name = 'Pay as you go', SignUpFee = 0, DurationInMonth = 0, DiscountRate = 0 WHERE ID = 1;");
            Sql("UPDATE MembershipTypes SET Name = 'Monthly', SignUpFee = 30, DurationInMonth = 1, DiscountRate = 10 WHERE ID = 2;");
            Sql("UPDATE MembershipTypes SET Name = 'Quaterly', SignUpFee = 90, DurationInMonth = 3, DiscountRate = 15 WHERE ID = 3;");
            Sql("UPDATE MembershipTypes SET Name = 'Yearly', SignUpFee = 300, DurationInMonth = 12, DiscountRate = 20 WHERE ID = 4;");
        }
        
        public override void Down()
        {
        }
    }
}
