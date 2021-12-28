namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newcvvalidation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Cvs", "Competence", c => c.String(maxLength: 150));
            AlterColumn("dbo.Cvs", "Education", c => c.String(maxLength: 150));
            AlterColumn("dbo.Cvs", "Experience", c => c.String(maxLength: 150));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Cvs", "Experience", c => c.String());
            AlterColumn("dbo.Cvs", "Education", c => c.String());
            AlterColumn("dbo.Cvs", "Competence", c => c.String());
        }
    }
}
