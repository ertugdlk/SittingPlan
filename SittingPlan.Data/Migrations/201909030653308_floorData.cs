namespace SittingPlan.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class floorData : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Floors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Desks", "Floor_Id", c => c.Int());
            CreateIndex("dbo.Desks", "Floor_Id");
            AddForeignKey("dbo.Desks", "Floor_Id", "dbo.Floors", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Desks", "Floor_Id", "dbo.Floors");
            DropIndex("dbo.Desks", new[] { "Floor_Id" });
            DropColumn("dbo.Desks", "Floor_Id");
            DropTable("dbo.Floors");
        }
    }
}
