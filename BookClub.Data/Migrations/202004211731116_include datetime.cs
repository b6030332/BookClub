namespace BookClub.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class includedatetime : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "MemberSince", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "MemberSince");
        }
    }
}
