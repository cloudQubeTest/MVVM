namespace PatientsDataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reworkingmedlist2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Patients", "Med1Name", c => c.String());
            AddColumn("dbo.Patients", "Med1Dosage", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Patients", "Med1Dosage");
            DropColumn("dbo.Patients", "Med1Name");
        }
    }
}
