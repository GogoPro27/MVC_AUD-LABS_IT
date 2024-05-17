namespace LAB_3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addPatientsInDoctor : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Doctors", "Patient_Id", "dbo.Patients");
            DropIndex("dbo.Doctors", new[] { "Patient_Id" });
            CreateTable(
                "dbo.PatientDoctors",
                c => new
                    {
                        Patient_Id = c.Int(nullable: false),
                        Doctor_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Patient_Id, t.Doctor_Id })
                .ForeignKey("dbo.Patients", t => t.Patient_Id, cascadeDelete: true)
                .ForeignKey("dbo.Doctors", t => t.Doctor_Id, cascadeDelete: true)
                .Index(t => t.Patient_Id)
                .Index(t => t.Doctor_Id);
            
            DropColumn("dbo.Doctors", "Patient_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Doctors", "Patient_Id", c => c.Int());
            DropForeignKey("dbo.PatientDoctors", "Doctor_Id", "dbo.Doctors");
            DropForeignKey("dbo.PatientDoctors", "Patient_Id", "dbo.Patients");
            DropIndex("dbo.PatientDoctors", new[] { "Doctor_Id" });
            DropIndex("dbo.PatientDoctors", new[] { "Patient_Id" });
            DropTable("dbo.PatientDoctors");
            CreateIndex("dbo.Doctors", "Patient_Id");
            AddForeignKey("dbo.Doctors", "Patient_Id", "dbo.Patients", "Id");
        }
    }
}
