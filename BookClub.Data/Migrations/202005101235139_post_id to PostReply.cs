namespace BookClub.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class post_idtoPostReply : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.PostReplies", name: "Post_Id", newName: "PostId");
            RenameIndex(table: "dbo.PostReplies", name: "IX_Post_Id", newName: "IX_PostId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.PostReplies", name: "IX_PostId", newName: "IX_Post_Id");
            RenameColumn(table: "dbo.PostReplies", name: "PostId", newName: "Post_Id");
        }
    }
}
