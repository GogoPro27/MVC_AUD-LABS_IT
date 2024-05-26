namespace LAB_3_onceMore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mistakes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Hospitals", "Address", c => c.String());
            DropColumn("dbo.Doctors", "Address");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Doctors", "Address", c => c.String());
            DropColumn("dbo.Hospitals", "Address");
        }
    }
}
