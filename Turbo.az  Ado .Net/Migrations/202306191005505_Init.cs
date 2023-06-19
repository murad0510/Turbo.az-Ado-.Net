namespace Turbo.az__Ado.Net.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Colors", newName: "CarColors");
            CreateTable(
                "dbo.FuelTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Cars", "FuelTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Cars", "FuelTypeId");
            AddForeignKey("dbo.Cars", "FuelTypeId", "dbo.FuelTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cars", "FuelTypeId", "dbo.FuelTypes");
            DropIndex("dbo.Cars", new[] { "FuelTypeId" });
            DropColumn("dbo.Cars", "FuelTypeId");
            DropTable("dbo.FuelTypes");
            RenameTable(name: "dbo.CarColors", newName: "Colors");
        }
    }
}
