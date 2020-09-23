namespace CarRental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initiatescript5 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CustomerFeedbacks",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CustomerID = c.Int(nullable: false),
                        Feedback = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Customers", t => t.CustomerID, cascadeDelete: true)
                .Index(t => t.CustomerID);
            
            CreateTable(
                "dbo.Fines",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CarRentalID = c.Int(nullable: false),
                        AmountFine = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FineDeposit = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DepositDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.CarRentals", t => t.CarRentalID, cascadeDelete: true)
                .Index(t => t.CarRentalID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Fines", "CarRentalID", "dbo.CarRentals");
            DropForeignKey("dbo.CustomerFeedbacks", "CustomerID", "dbo.Customers");
            DropIndex("dbo.Fines", new[] { "CarRentalID" });
            DropIndex("dbo.CustomerFeedbacks", new[] { "CustomerID" });
            DropTable("dbo.Fines");
            DropTable("dbo.CustomerFeedbacks");
        }
    }
}
