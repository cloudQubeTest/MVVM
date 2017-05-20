namespace PatientsDataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reworkingmedlist : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Medications", "Patient_Id", "dbo.Patients");
            DropIndex("dbo.Medications", new[] { "Patient_Id" });
            DropTable("dbo.Medications");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Medications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MedName = c.String(),
                        Patient_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Medications", "Patient_Id");
            AddForeignKey("dbo.Medications", "Patient_Id", "dbo.Patients", "Id");
        }
    }
}
