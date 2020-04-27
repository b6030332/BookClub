namespace BookClub.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedChallengesModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Challenges", "From", c => c.DateTime(nullable: false));
            AddColumn("dbo.Challenges", "Until", c => c.DateTime(nullable: false));
            AddColumn("dbo.Challenges", "User_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Challenges", "User_Id");
            AddForeignKey("dbo.Challenges", "User_Id", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.Challenges", "Active");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Challenges", "Active", c => c.Boolean(nullable: false));
            DropForeignKey("dbo.Challenges", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Challenges", new[] { "User_Id" });
            DropColumn("dbo.Challenges", "User_Id");
            DropColumn("dbo.Challenges", "Until");
            DropColumn("dbo.Challenges", "From");
        }
    }
}
