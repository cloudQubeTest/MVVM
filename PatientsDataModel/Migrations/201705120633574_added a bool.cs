namespace PatientsDataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedabool : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Patients", "Sedentary", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Patients", "Sedentary");
        }
    }
}
