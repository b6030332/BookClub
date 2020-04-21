namespace BookClub.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingfkonpost : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "Discussion_Id", c => c.Int());
            CreateIndex("dbo.Posts", "Discussion_Id");
            AddForeignKey("dbo.Posts", "Discussion_Id", "dbo.Discussions", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "Discussion_Id", "dbo.Discussions");
            DropIndex("dbo.Posts", new[] { "Discussion_Id" });
            DropColumn("dbo.Posts", "Discussion_Id");
        }
    }
}
