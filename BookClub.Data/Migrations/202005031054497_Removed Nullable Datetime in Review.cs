namespace BookClub.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedNullableDatetimeinReview : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Reviews", "Created", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Reviews", "Created", c => c.DateTime());
        }
    }
}
