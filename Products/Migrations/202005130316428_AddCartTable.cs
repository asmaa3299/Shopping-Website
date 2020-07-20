namespace Products.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCartTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        productId = c.Int(nullable: false),
                        added_at = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.productId)
                .ForeignKey("dbo.Products", t => t.productId)
                .Index(t => t.productId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Carts", "productId", "dbo.Products");
            DropIndex("dbo.Carts", new[] { "productId" });
            DropTable("dbo.Carts");
        }
    }
}
