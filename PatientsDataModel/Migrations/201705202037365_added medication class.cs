namespace PatientsDataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedmedicationclass : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Medications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Dosage = c.String(),
                        Frequency = c.String(),
                        Patient_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Patients", t => t.Patient_Id, cascadeDelete: true)
                .Index(t => t.Patient_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Medications", "Patient_Id", "dbo.Patients");
            DropIndex("dbo.Medications", new[] { "Patient_Id" });
            DropTable("dbo.Medications");
        }
    }
}
