namespace BookClub.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedfkinbook : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Books", name: "Author_Id1", newName: "AuthorId");
            RenameColumn(table: "dbo.Books", name: "Genre_Id1", newName: "GenreId");
            RenameIndex(table: "dbo.Books", name: "IX_Genre_Id1", newName: "IX_GenreId");
            RenameIndex(table: "dbo.Books", name: "IX_Author_Id1", newName: "IX_AuthorId");
            DropColumn("dbo.Books", "Genre_Id");
            DropColumn("dbo.Books", "Author_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Books", "Author_Id", c => c.Int());
            AddColumn("dbo.Books", "Genre_Id", c => c.Int());
            RenameIndex(table: "dbo.Books", name: "IX_AuthorId", newName: "IX_Author_Id1");
            RenameIndex(table: "dbo.Books", name: "IX_GenreId", newName: "IX_Genre_Id1");
            RenameColumn(table: "dbo.Books", name: "GenreId", newName: "Genre_Id1");
            RenameColumn(table: "dbo.Books", name: "AuthorId", newName: "Author_Id1");
        }
    }
}
