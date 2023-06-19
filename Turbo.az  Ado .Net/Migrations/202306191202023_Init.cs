namespace Turbo.az__Ado.Net.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Brands",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Models",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                        BrandId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Brands", t => t.BrandId, cascadeDelete: true)
                .Index(t => t.BrandId);
            
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CityId = c.Int(nullable: false),
                        ModelId = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ColorId = c.Int(nullable: false),
                        Km = c.Double(nullable: false),
                        Year = c.DateTime(nullable: false),
                        CarImage = c.String(),
                        FuelTypeId = c.Int(nullable: false),
                        IsNew = c.Boolean(nullable: false),
                        Engine = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.CityId, cascadeDelete: true)
                .ForeignKey("dbo.CarColors", t => t.ColorId, cascadeDelete: true)
                .ForeignKey("dbo.FuelTypes", t => t.FuelTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Models", t => t.ModelId, cascadeDelete: true)
                .Index(t => t.CityId)
                .Index(t => t.ModelId)
                .Index(t => t.ColorId)
                .Index(t => t.FuelTypeId);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CarColors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ColorName = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FuelTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cars", "ModelId", "dbo.Models");
            DropForeignKey("dbo.Cars", "FuelTypeId", "dbo.FuelTypes");
            DropForeignKey("dbo.Cars", "ColorId", "dbo.CarColors");
            DropForeignKey("dbo.Cars", "CityId", "dbo.Cities");
            DropForeignKey("dbo.Models", "BrandId", "dbo.Brands");
            DropIndex("dbo.Cars", new[] { "FuelTypeId" });
            DropIndex("dbo.Cars", new[] { "ColorId" });
            DropIndex("dbo.Cars", new[] { "ModelId" });
            DropIndex("dbo.Cars", new[] { "CityId" });
            DropIndex("dbo.Models", new[] { "BrandId" });
            DropTable("dbo.FuelTypes");
            DropTable("dbo.CarColors");
            DropTable("dbo.Cities");
            DropTable("dbo.Cars");
            DropTable("dbo.Models");
            DropTable("dbo.Brands");
        }
    }
}
