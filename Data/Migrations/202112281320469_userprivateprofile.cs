namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userprivateprofile : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "PrivateProfile", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "PrivateProfile");
        }
    }
}
