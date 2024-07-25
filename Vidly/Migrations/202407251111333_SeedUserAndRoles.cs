namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUserAndRoles : DbMigration
    {
        public override void Up()
        {
            Sql(@"
            
            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'0a4a54eb-68c8-48e6-93f2-69006a968ab2', N'admin@vidly.com', 0, N'ABZ/Iog4N/LIv3Bcp/mENPAGmF/M982nxn21DFliqctx3m3UJv+i8a4Kh+qVAy8OMw==', N'ed67dd37-b0bc-4a7e-84ae-221b137343f8', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'18e5cdb7-e5cc-4a3a-b76b-07b962f2ed6b', N'guest@vidly.com', 0, N'AN+riMtd/5/tzcWth5YRfnUFbiHegvYx6kiiJ94bn2+wLpmTDY+J0wdbf+ocjGREjw==', N'4e07c655-7a8b-4e18-acec-60a6e3a78dfc', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')

            INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'a0331810-23ea-4727-858d-aaef1cbccf8b', N'CanManageMovies')

            INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'0a4a54eb-68c8-48e6-93f2-69006a968ab2', N'a0331810-23ea-4727-858d-aaef1cbccf8b')

             ");
        }
        
        public override void Down()
        {
        }
    }
}
