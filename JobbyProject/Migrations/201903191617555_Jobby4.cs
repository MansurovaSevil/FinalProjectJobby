namespace JobbyProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Jobby4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Blogs", "BlogUser", c => c.Int(nullable: false));
            DropColumn("dbo.Blogs", "Adminka");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Blogs", "Adminka", c => c.Int(nullable: false));
            DropColumn("dbo.Blogs", "BlogUser");
        }
    }
}
