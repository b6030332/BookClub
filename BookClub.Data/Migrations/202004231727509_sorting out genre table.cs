namespace BookClub.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sortingoutgenretable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Genres", "Author_Id", "dbo.Authors");
            DropIndex("dbo.Genres", new[] { "Author_Id" });
            AddColumn("dbo.Authors", "Genre_Id", c => c.Int());
            CreateIndex("dbo.Authors", "Genre_Id");
            AddForeignKey("dbo.Authors", "Genre_Id", "dbo.Genres", "Id");
            DropColumn("dbo.Genres", "Author_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Genres", "Author_Id", c => c.Int());
            DropForeignKey("dbo.Authors", "Genre_Id", "dbo.Genres");
            DropIndex("dbo.Authors", new[] { "Genre_Id" });
            DropColumn("dbo.Authors", "Genre_Id");
            CreateIndex("dbo.Genres", "Author_Id");
            AddForeignKey("dbo.Genres", "Author_Id", "dbo.Authors", "Id");
        }
    }
}
