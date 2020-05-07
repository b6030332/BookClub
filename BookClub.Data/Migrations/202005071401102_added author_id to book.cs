namespace BookClub.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedauthor_idtobook : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Books", "Author_Id", "dbo.Authors");
            DropIndex("dbo.Books", new[] { "Author_Id" });
            RenameColumn(table: "dbo.Books", name: "GenreId", newName: "Genre_Id1");
            RenameIndex(table: "dbo.Books", name: "IX_GenreId", newName: "IX_Genre_Id1");
            AddColumn("dbo.Books", "Genre_Id", c => c.Int());
            AddColumn("dbo.Books", "Author_Id1", c => c.Int());
            CreateIndex("dbo.Books", "Author_Id1");
            AddForeignKey("dbo.Books", "Author_Id1", "dbo.Authors", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Books", "Author_Id1", "dbo.Authors");
            DropIndex("dbo.Books", new[] { "Author_Id1" });
            DropColumn("dbo.Books", "Author_Id1");
            DropColumn("dbo.Books", "Genre_Id");
            RenameIndex(table: "dbo.Books", name: "IX_Genre_Id1", newName: "IX_GenreId");
            RenameColumn(table: "dbo.Books", name: "Genre_Id1", newName: "GenreId");
            CreateIndex("dbo.Books", "Author_Id");
            AddForeignKey("dbo.Books", "Author_Id", "dbo.Authors", "Id");
        }
    }
}
