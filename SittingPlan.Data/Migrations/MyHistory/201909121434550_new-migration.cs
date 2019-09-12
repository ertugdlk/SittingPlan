namespace SittingPlan.Data.Migrations.MyHistory
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newmigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Chairs", "Person_Id", "dbo.People");
            DropIndex("dbo.Chairs", new[] { "Person_Id" });
            DropPrimaryKey("dbo.Chairs");
            DropPrimaryKey("dbo.People");
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
            
            AlterColumn("dbo.Chairs", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.People", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Chairs", "Id");
            AddPrimaryKey("dbo.People", "Id");
            CreateIndex("dbo.Chairs", "Id");
            CreateIndex("dbo.People", "Id");
            AddForeignKey("dbo.People", "Id", "dbo.ChairPeoples", "ChairId");
            AddForeignKey("dbo.Chairs", "Id", "dbo.ChairPeoples", "ChairId");
            DropColumn("dbo.Chairs", "Person_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Chairs", "Person_Id", c => c.Int());
            DropForeignKey("dbo.Chairs", "Id", "dbo.ChairPeoples");
            DropForeignKey("dbo.ChairPeoples", "PersonId", "dbo.People");
            DropForeignKey("dbo.People", "Id", "dbo.ChairPeoples");
            DropForeignKey("dbo.ChairPeoples", "ChairId", "dbo.Chairs");
            DropIndex("dbo.People", new[] { "Id" });
            DropIndex("dbo.ChairPeoples", new[] { "PersonId" });
            DropIndex("dbo.ChairPeoples", new[] { "ChairId" });
            DropIndex("dbo.Chairs", new[] { "Id" });
            DropPrimaryKey("dbo.People");
            DropPrimaryKey("dbo.Chairs");
            AlterColumn("dbo.People", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Chairs", "Id", c => c.Int(nullable: false, identity: true));
            DropTable("dbo.ChairPeoples");
            AddPrimaryKey("dbo.People", "Id");
            AddPrimaryKey("dbo.Chairs", "Id");
            CreateIndex("dbo.Chairs", "Person_Id");
            AddForeignKey("dbo.Chairs", "Person_Id", "dbo.People", "Id");
        }
    }
}
