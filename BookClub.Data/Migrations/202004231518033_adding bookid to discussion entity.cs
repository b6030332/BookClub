namespace BookClub.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingbookidtodiscussionentity : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Discussions", name: "Books_Id", newName: "BookId");
            RenameIndex(table: "dbo.Discussions", name: "IX_Books_Id", newName: "IX_BookId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Discussions", name: "IX_BookId", newName: "IX_Books_Id");
            RenameColumn(table: "dbo.Discussions", name: "BookId", newName: "Books_Id");
        }
    }
}
