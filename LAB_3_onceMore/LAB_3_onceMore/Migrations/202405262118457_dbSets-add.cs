namespace LAB_3_onceMore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbSetsadd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Doctors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        Hospital_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Hospitals", t => t.Hospital_Id)
                .Index(t => t.Hospital_Id);
            
            CreateTable(
                "dbo.Hospitals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Img_Url = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        PatientCode = c.String(),
                        Doctor_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Doctors", t => t.Doctor_Id)
                .Index(t => t.Doctor_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Patients", "Doctor_Id", "dbo.Doctors");
            DropForeignKey("dbo.Doctors", "Hospital_Id", "dbo.Hospitals");
            DropIndex("dbo.Patients", new[] { "Doctor_Id" });
            DropIndex("dbo.Doctors", new[] { "Hospital_Id" });
            DropTable("dbo.Patients");
            DropTable("dbo.Hospitals");
            DropTable("dbo.Doctors");
        }
    }
}
