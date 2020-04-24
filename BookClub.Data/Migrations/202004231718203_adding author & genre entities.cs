namespace BookClub.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingauthorgenreentities : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Image = c.String(),
                        Name = c.String(),
                        Bio = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Author_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Authors", t => t.Author_Id)
                .Index(t => t.Author_Id);
            
            AddColumn("dbo.Books", "Author_Id", c => c.Int());
            AddColumn("dbo.Books", "Genre_Id", c => c.Int());
            CreateIndex("dbo.Books", "Author_Id");
            CreateIndex("dbo.Books", "Genre_Id");
            AddForeignKey("dbo.Books", "Author_Id", "dbo.Authors", "Id");
            AddForeignKey("dbo.Books", "Genre_Id", "dbo.Genres", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Genres", "Author_Id", "dbo.Authors");
            DropForeignKey("dbo.Books", "Genre_Id", "dbo.Genres");
            DropForeignKey("dbo.Books", "Author_Id", "dbo.Authors");
            DropIndex("dbo.Genres", new[] { "Author_Id" });
            DropIndex("dbo.Books", new[] { "Genre_Id" });
            DropIndex("dbo.Books", new[] { "Author_Id" });
            DropColumn("dbo.Books", "Genre_Id");
            DropColumn("dbo.Books", "Author_Id");
            DropTable("dbo.Genres");
            DropTable("dbo.Authors");
        }
    }
}
