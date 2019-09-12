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
                        Id = c.Int(nullable: false),
                        DeskId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Desks", t => t.DeskId, cascadeDelete: true)
                .ForeignKey("dbo.ChairPeoples", t => t.Id)
                .Index(t => t.Id)
                .Index(t => t.DeskId);
            
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
                "dbo.ChairPeoples",
                c => new
                    {
                        ChairId = c.Int(nullable: false),
                        PersonId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ChairId)
                .ForeignKey("dbo.Chairs", t => t.ChairId)
                .ForeignKey("dbo.People", t => t.PersonId, cascadeDelete: true)
                .Index(t => t.ChairId)
                .Index(t => t.PersonId);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(),
                        Surname = c.String(),
                        Mail = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ChairPeoples", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Chairs", "Id", "dbo.ChairPeoples");
            DropForeignKey("dbo.ChairPeoples", "PersonId", "dbo.People");
            DropForeignKey("dbo.People", "Id", "dbo.ChairPeoples");
            DropForeignKey("dbo.ChairPeoples", "ChairId", "dbo.Chairs");
            DropForeignKey("dbo.Chairs", "DeskId", "dbo.Desks");
            DropForeignKey("dbo.Desks", "FloorId", "dbo.Floors");
            DropIndex("dbo.People", new[] { "Id" });
            DropIndex("dbo.ChairPeoples", new[] { "PersonId" });
            DropIndex("dbo.ChairPeoples", new[] { "ChairId" });
            DropIndex("dbo.Desks", new[] { "FloorId" });
            DropIndex("dbo.Chairs", new[] { "DeskId" });
            DropIndex("dbo.Chairs", new[] { "Id" });
            DropTable("dbo.People");
            DropTable("dbo.ChairPeoples");
            DropTable("dbo.Floors");
            DropTable("dbo.Desks");
            DropTable("dbo.Chairs");
        }
    }
}
