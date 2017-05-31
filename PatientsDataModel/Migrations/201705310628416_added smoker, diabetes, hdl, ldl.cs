namespace PatientsDataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedsmokerdiabeteshdlldl : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Patients", "Smoker", c => c.Boolean(nullable: false));
            AddColumn("dbo.Patients", "Diabetes", c => c.Boolean(nullable: false));
            AddColumn("dbo.Patients", "LDL", c => c.Single(nullable: false));
            AddColumn("dbo.Patients", "HDL", c => c.Single(nullable: false));
            DropColumn("dbo.Patients", "Med1Name");
            DropColumn("dbo.Patients", "Med1Dosage");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Patients", "Med1Dosage", c => c.String());
            AddColumn("dbo.Patients", "Med1Name", c => c.String());
            DropColumn("dbo.Patients", "HDL");
            DropColumn("dbo.Patients", "LDL");
            DropColumn("dbo.Patients", "Diabetes");
            DropColumn("dbo.Patients", "Smoker");
        }
    }
}
