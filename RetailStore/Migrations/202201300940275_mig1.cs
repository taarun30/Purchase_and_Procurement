namespace RetailStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admin",
                c => new
                    {
                        Username = c.String(nullable: false, maxLength: 30, unicode: false),
                        Password = c.String(maxLength: 30, unicode: false),
                    })
                .PrimaryKey(t => t.Username);
            
            CreateTable(
                "dbo.Feedback",
                c => new
                    {
                        FeedbackId = c.Int(nullable: false),
                        FeedbackScore = c.String(maxLength: 100, unicode: false),
                        OrderId = c.Int(nullable: false),
                        RetailerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FeedbackId)
                .ForeignKey("dbo.OrdersMaster", t => t.OrderId, cascadeDelete: true)
                .ForeignKey("dbo.Retailers", t => t.RetailerId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.RetailerId);
            
            CreateTable(
                "dbo.OrdersMaster",
                c => new
                    {
                        OrderID = c.Int(nullable: false),
                        OrderDate = c.DateTime(storeType: "date"),
                        OrderStatus = c.String(maxLength: 50, unicode: false),
                        PaymentMode = c.String(maxLength: 50, unicode: false),
                        TotalAmount = c.Int(),
                        RetailerId = c.Int(),
                    })
                .PrimaryKey(t => t.OrderID)
                .ForeignKey("dbo.Retailers", t => t.RetailerId)
                .Index(t => t.RetailerId);
            
            CreateTable(
                "dbo.Invoice",
                c => new
                    {
                        InvoiceNo = c.Int(nullable: false),
                        InvoiceAmount = c.Int(),
                        InvoiceStatus = c.String(maxLength: 50, unicode: false),
                        InvoiceDate = c.DateTime(storeType: "date"),
                        OrderId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InvoiceNo)
                .ForeignKey("dbo.OrdersMaster", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.OrderId);
            
            CreateTable(
                "dbo.OrderDetail",
                c => new
                    {
                        slno = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        InventoryId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        PaymentMode = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.slno)
                .ForeignKey("dbo.Inventory", t => t.InventoryId, cascadeDelete: true)
                .ForeignKey("dbo.OrdersMaster", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.InventoryId);
            
            CreateTable(
                "dbo.Inventory",
                c => new
                    {
                        InventoryId = c.Int(nullable: false),
                        Productname = c.String(maxLength: 30, unicode: false),
                        ProductPrice = c.Int(),
                        ProductDescription = c.String(maxLength: 600, unicode: false),
                        QuantityInHand = c.Int(),
                        ReorderLevel = c.Int(),
                        Rating = c.Int(),
                    })
                .PrimaryKey(t => t.InventoryId);
            
            CreateTable(
                "dbo.Retailers",
                c => new
                    {
                        RetailerId = c.Int(nullable: false),
                        Firstname = c.String(maxLength: 30, unicode: false),
                        LastName = c.String(maxLength: 30, unicode: false),
                        email = c.String(maxLength: 30, unicode: false),
                        Contactnumber = c.String(maxLength: 15, unicode: false),
                        Address = c.String(maxLength: 50, unicode: false),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.RetailerId);
            
            CreateTable(
                "dbo.Manufacturer",
                c => new
                    {
                        ManufacturerID = c.Int(nullable: false),
                        CompanyName = c.String(maxLength: 30, unicode: false),
                        Firstname = c.String(maxLength: 30, unicode: false),
                        Lastname = c.String(maxLength: 30, unicode: false),
                        Address = c.String(maxLength: 30, unicode: false),
                        City = c.String(maxLength: 30, unicode: false),
                        State = c.String(maxLength: 30, unicode: false),
                        PostalCode = c.Int(),
                        Country = c.String(maxLength: 30, unicode: false),
                        Phone = c.String(maxLength: 15, unicode: false),
                        Email = c.String(maxLength: 30, unicode: false),
                    })
                .PrimaryKey(t => t.ManufacturerID);
            
            CreateTable(
                "dbo.PurchaseOrderMaster",
                c => new
                    {
                        PurchaseOrderID = c.Int(nullable: false),
                        PurchaseOrderDate = c.DateTime(storeType: "date"),
                        PurchaseOrderStatus = c.String(maxLength: 30, unicode: false),
                        PaymentMode = c.String(maxLength: 30, unicode: false),
                        TotalAmount = c.Int(),
                        PaymentStatus = c.String(maxLength: 30, unicode: false),
                        ManufacturerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PurchaseOrderID)
                .ForeignKey("dbo.Manufacturer", t => t.ManufacturerId, cascadeDelete: true)
                .Index(t => t.ManufacturerId);
            
            CreateTable(
                "dbo.PurchaseOrderDetail",
                c => new
                    {
                        slno = c.Int(nullable: false, identity: true),
                        PurchaseOrderID = c.Int(nullable: false),
                        InventoryId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Amount = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.slno)
                .ForeignKey("dbo.Inventory", t => t.InventoryId, cascadeDelete: true)
                .ForeignKey("dbo.PurchaseOrderMaster", t => t.PurchaseOrderID, cascadeDelete: true)
                .Index(t => t.PurchaseOrderID)
                .Index(t => t.InventoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PurchaseOrderDetail", "PurchaseOrderID", "dbo.PurchaseOrderMaster");
            DropForeignKey("dbo.PurchaseOrderDetail", "InventoryId", "dbo.Inventory");
            DropForeignKey("dbo.PurchaseOrderMaster", "ManufacturerId", "dbo.Manufacturer");
            DropForeignKey("dbo.OrdersMaster", "RetailerId", "dbo.Retailers");
            DropForeignKey("dbo.Feedback", "RetailerId", "dbo.Retailers");
            DropForeignKey("dbo.OrderDetail", "OrderId", "dbo.OrdersMaster");
            DropForeignKey("dbo.OrderDetail", "InventoryId", "dbo.Inventory");
            DropForeignKey("dbo.Invoice", "OrderId", "dbo.OrdersMaster");
            DropForeignKey("dbo.Feedback", "OrderId", "dbo.OrdersMaster");
            DropIndex("dbo.PurchaseOrderDetail", new[] { "InventoryId" });
            DropIndex("dbo.PurchaseOrderDetail", new[] { "PurchaseOrderID" });
            DropIndex("dbo.PurchaseOrderMaster", new[] { "ManufacturerId" });
            DropIndex("dbo.OrderDetail", new[] { "InventoryId" });
            DropIndex("dbo.OrderDetail", new[] { "OrderId" });
            DropIndex("dbo.Invoice", new[] { "OrderId" });
            DropIndex("dbo.OrdersMaster", new[] { "RetailerId" });
            DropIndex("dbo.Feedback", new[] { "RetailerId" });
            DropIndex("dbo.Feedback", new[] { "OrderId" });
            DropTable("dbo.PurchaseOrderDetail");
            DropTable("dbo.PurchaseOrderMaster");
            DropTable("dbo.Manufacturer");
            DropTable("dbo.Retailers");
            DropTable("dbo.Inventory");
            DropTable("dbo.OrderDetail");
            DropTable("dbo.Invoice");
            DropTable("dbo.OrdersMaster");
            DropTable("dbo.Feedback");
            DropTable("dbo.Admin");
        }
    }
}
