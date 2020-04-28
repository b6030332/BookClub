namespace BookClub.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NullableDatetimeinChallenges : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Challenges", "From", c => c.DateTime());
            AlterColumn("dbo.Challenges", "Until", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Challenges", "Until", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Challenges", "From", c => c.DateTime(nullable: false));
        }
    }
}
