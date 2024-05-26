namespace LAB_3_onceMore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addvalidation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Patients", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Patients", "Name", c => c.String());
        }
    }
}
