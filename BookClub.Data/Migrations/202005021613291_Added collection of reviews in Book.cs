namespace BookClub.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedcollectionofreviewsinBook : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Reviews", "BookId");
            AddForeignKey("dbo.Reviews", "BookId", "dbo.Books", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reviews", "BookId", "dbo.Books");
            DropIndex("dbo.Reviews", new[] { "BookId" });
        }
    }
}
