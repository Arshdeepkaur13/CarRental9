namespace CarRental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initiatescript4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CarRentals",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CustomerID = c.Int(nullable: false),
                        CarID = c.Int(nullable: false),
                        IssueDate = c.DateTime(nullable: false),
                        DueDate = c.DateTime(),
                        ReturnDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Cars", t => t.CarID, cascadeDelete: true)
                .ForeignKey("dbo.Customers", t => t.CustomerID, cascadeDelete: true)
                .Index(t => t.CustomerID)
                .Index(t => t.CarID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CarRentals", "CustomerID", "dbo.Customers");
            DropForeignKey("dbo.CarRentals", "CarID", "dbo.Cars");
            DropIndex("dbo.CarRentals", new[] { "CarID" });
            DropIndex("dbo.CarRentals", new[] { "CustomerID" });
            DropTable("dbo.CarRentals");
        }
    }
}
