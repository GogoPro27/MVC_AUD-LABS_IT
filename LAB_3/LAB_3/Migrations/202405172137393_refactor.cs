namespace LAB_3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class refactor : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Patients", "PatientCode", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Patients", "PatientCode", c => c.String(maxLength: 5));
        }
    }
}
