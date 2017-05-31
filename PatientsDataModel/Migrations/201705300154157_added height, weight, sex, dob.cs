
namespace PatientsDataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedheightweightsexdob : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Patients", "DOB", c => c.String());
            AddColumn("dbo.Patients", "Height", c => c.String());
            AddColumn("dbo.Patients", "Weight", c => c.String());
            AddColumn("dbo.Patients", "MiddleName", c => c.String());
            AddColumn("dbo.Patients", "Sex", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Patients", "Sex");
            DropColumn("dbo.Patients", "MiddleName");
            DropColumn("dbo.Patients", "Weight");
            DropColumn("dbo.Patients", "Height");
            DropColumn("dbo.Patients", "DOB");
        }
    }
}
