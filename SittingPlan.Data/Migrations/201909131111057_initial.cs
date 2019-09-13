namespace SittingPlan.Data.Migrations.MyHistory
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Chairs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DeskId = c.Int(nullable: false),
                        PersonId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Desks", t => t.DeskId, cascadeDelete: true)
                .ForeignKey("dbo.People", t => t.PersonId)
                .Index(t => t.DeskId)
                .Index(t => t.PersonId);
            
            CreateTable(
                "dbo.Desks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FloorId = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Floors", t => t.FloorId, cascadeDelete: true)
                .Index(t => t.FloorId);
            
            CreateTable(
                "dbo.Floors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        Mail = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Chairs", "PersonId", "dbo.People");
            DropForeignKey("dbo.Chairs", "DeskId", "dbo.Desks");
            DropForeignKey("dbo.Desks", "FloorId", "dbo.Floors");
            DropIndex("dbo.Desks", new[] { "FloorId" });
            DropIndex("dbo.Chairs", new[] { "PersonId" });
            DropIndex("dbo.Chairs", new[] { "DeskId" });
            DropTable("dbo.People");
            DropTable("dbo.Floors");
            DropTable("dbo.Desks");
            DropTable("dbo.Chairs");
        }
    }
}
