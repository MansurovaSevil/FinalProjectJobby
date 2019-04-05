namespace JobbyProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Jobby6 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "Image", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "Image", c => c.String(nullable: false, maxLength: 255));
        }
    }
}
