namespace CarRental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initiatescript2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CarName = c.String(),
                        CarCategoryID = c.Int(nullable: false),
                        CarTypeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.CarCategories", t => t.CarCategoryID, cascadeDelete: true)
                .ForeignKey("dbo.CarTypes", t => t.CarTypeID, cascadeDelete: true)
                .Index(t => t.CarCategoryID)
                .Index(t => t.CarTypeID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cars", "CarTypeID", "dbo.CarTypes");
            DropForeignKey("dbo.Cars", "CarCategoryID", "dbo.CarCategories");
            DropIndex("dbo.Cars", new[] { "CarTypeID" });
            DropIndex("dbo.Cars", new[] { "CarCategoryID" });
            DropTable("dbo.Cars");
        }
    }
}
