namespace BookClub.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedatetime : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "MemberSince");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "MemberSince", c => c.DateTime(nullable: false));
        }
    }
}
