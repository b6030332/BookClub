namespace BookClub.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingpropertiestoApplicationUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Rating", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "ProfileImage", c => c.String());
            AddColumn("dbo.AspNetUsers", "MemberSince", c => c.DateTime(nullable: false));
            AddColumn("dbo.AspNetUsers", "IsActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "IsActive");
            DropColumn("dbo.AspNetUsers", "MemberSince");
            DropColumn("dbo.AspNetUsers", "ProfileImage");
            DropColumn("dbo.AspNetUsers", "Rating");
        }
    }
}
