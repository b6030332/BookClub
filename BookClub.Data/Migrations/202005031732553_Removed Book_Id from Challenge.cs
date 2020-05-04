namespace BookClub.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedBook_IdfromChallenge : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Challenges", "Book_Id", "dbo.Books");
            DropIndex("dbo.Challenges", new[] { "Book_Id" });
            DropColumn("dbo.Challenges", "Book_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Challenges", "Book_Id", c => c.Int());
            CreateIndex("dbo.Challenges", "Book_Id");
            AddForeignKey("dbo.Challenges", "Book_Id", "dbo.Books", "Id");
        }
    }
}
