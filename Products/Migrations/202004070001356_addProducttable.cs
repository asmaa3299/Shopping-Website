namespace Products.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addProducttable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        description = c.String(),
                        image = c.String(),
                        price = c.Single(nullable: false),
                        categoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Categories", t => t.categoryId, cascadeDelete: true)
                .Index(t => t.categoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "categoryId", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "categoryId" });
            DropTable("dbo.Products");
        }
    }
}
