namespace SittingPlan.Data.Migrations.MyHistory
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changesAboutRelations : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Chairs", "Person_Id", "dbo.People");
            DropForeignKey("dbo.Chairs", "Desk_Id", "dbo.Desks");
            DropForeignKey("dbo.Desks", "Floor_Id", "dbo.Floors");
            DropIndex("dbo.Chairs", new[] { "Person_Id" });
            DropIndex("dbo.Chairs", new[] { "Desk_Id" });
            DropIndex("dbo.Desks", new[] { "Floor_Id" });
            RenameColumn(table: "dbo.Chairs", name: "Desk_Id", newName: "DeskId");
            RenameColumn(table: "dbo.Desks", name: "Floor_Id", newName: "FloorId");
            AlterColumn("dbo.Chairs", "Person_Id", c => c.Int());
            AlterColumn("dbo.Chairs", "DeskId", c => c.Int(nullable: false));
            AlterColumn("dbo.Desks", "FloorId", c => c.Int(nullable: false));
            CreateIndex("dbo.Chairs", "DeskId");
            CreateIndex("dbo.Chairs", "Person_Id");
            CreateIndex("dbo.Desks", "FloorId");
            AddForeignKey("dbo.Chairs", "Person_Id", "dbo.People", "Id");
            AddForeignKey("dbo.Chairs", "DeskId", "dbo.Desks", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Desks", "FloorId", "dbo.Floors", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Desks", "FloorId", "dbo.Floors");
            DropForeignKey("dbo.Chairs", "DeskId", "dbo.Desks");
            DropForeignKey("dbo.Chairs", "Person_Id", "dbo.People");
            DropIndex("dbo.Desks", new[] { "FloorId" });
            DropIndex("dbo.Chairs", new[] { "Person_Id" });
            DropIndex("dbo.Chairs", new[] { "DeskId" });
            AlterColumn("dbo.Desks", "FloorId", c => c.Int());
            AlterColumn("dbo.Chairs", "DeskId", c => c.Int());
            AlterColumn("dbo.Chairs", "Person_Id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Desks", name: "FloorId", newName: "Floor_Id");
            RenameColumn(table: "dbo.Chairs", name: "DeskId", newName: "Desk_Id");
            CreateIndex("dbo.Desks", "Floor_Id");
            CreateIndex("dbo.Chairs", "Desk_Id");
            CreateIndex("dbo.Chairs", "Person_Id");
            AddForeignKey("dbo.Desks", "Floor_Id", "dbo.Floors", "Id");
            AddForeignKey("dbo.Chairs", "Desk_Id", "dbo.Desks", "Id");
            AddForeignKey("dbo.Chairs", "Person_Id", "dbo.People", "Id", cascadeDelete: true);
        }
    }
}
