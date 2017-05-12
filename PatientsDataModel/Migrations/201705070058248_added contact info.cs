namespace PatientsDataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedcontactinfo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Patients", "AddressLineOne", c => c.String());
            AddColumn("dbo.Patients", "AddressLineTwo", c => c.String());
            AddColumn("dbo.Patients", "City", c => c.String());
            AddColumn("dbo.Patients", "State", c => c.String());
            AddColumn("dbo.Patients", "PostalCode", c => c.String());
            AddColumn("dbo.Patients", "Country", c => c.String());
            AddColumn("dbo.Patients", "Phone", c => c.String());
            AddColumn("dbo.Patients", "Email", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Patients", "Email");
            DropColumn("dbo.Patients", "Phone");
            DropColumn("dbo.Patients", "Country");
            DropColumn("dbo.Patients", "PostalCode");
            DropColumn("dbo.Patients", "State");
            DropColumn("dbo.Patients", "City");
            DropColumn("dbo.Patients", "AddressLineTwo");
            DropColumn("dbo.Patients", "AddressLineOne");
        }
    }
}
