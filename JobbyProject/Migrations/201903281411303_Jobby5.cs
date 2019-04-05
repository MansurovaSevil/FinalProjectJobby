namespace JobbyProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Jobby5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Programs", "Description", c => c.String(storeType: "ntext"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Programs", "Description");
        }
    }
}
