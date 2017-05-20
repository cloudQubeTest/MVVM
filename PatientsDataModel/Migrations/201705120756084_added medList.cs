namespace PatientsDataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedmedList : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Medications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MedName = c.String(),
                        Patient_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Patients", t => t.Patient_Id)
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
