namespace SittingPlan.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newFloorAttribute : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Floors", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Floors", "Name");
        }
    }
}
