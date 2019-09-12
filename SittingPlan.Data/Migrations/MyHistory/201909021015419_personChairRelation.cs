namespace SittingPlan.Data.Migrations.MyHistory
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class personChairRelation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Chairs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Person_Id = c.Int(nullable: false),
                        Desk_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.Person_Id, cascadeDelete: true)
                .ForeignKey("dbo.Desks", t => t.Desk_Id)
                .Index(t => t.Person_Id)
                .Index(t => t.Desk_Id);
            
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
            DropForeignKey("dbo.Chairs", "Desk_Id", "dbo.Desks");
            DropForeignKey("dbo.Chairs", "Person_Id", "dbo.People");
            DropIndex("dbo.Chairs", new[] { "Desk_Id" });
            DropIndex("dbo.Chairs", new[] { "Person_Id" });
            DropTable("dbo.People");
            DropTable("dbo.Chairs");
        }
    }
}
