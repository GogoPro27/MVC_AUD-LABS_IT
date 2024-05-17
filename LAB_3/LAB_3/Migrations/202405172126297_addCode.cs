namespace LAB_3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addCode : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Patients", "PatientCode", c => c.String(maxLength: 5));
            AlterColumn("dbo.Patients", "FullName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Patients", "FullName", c => c.String());
            DropColumn("dbo.Patients", "PatientCode");
        }
    }
}
