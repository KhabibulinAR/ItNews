namespace ITNews.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AuthorEntityModels",
                c => new
                    {
                        AuthorId = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Firstname = c.String(),
                        Lastname = c.String(),
                        Email = c.String(),
                        Likes = c.Int(nullable: false),
                        AuthorImagePath = c.String(),
                    })
                .PrimaryKey(t => t.AuthorId);
            
            CreateTable(
                "dbo.CommentEntityModels",
                c => new
                    {
                        CommentId = c.Int(nullable: false, identity: true),
                        NewsId = c.Int(),
                        AuthorId = c.Int(),
                        Content = c.String(),
                        CommentCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CommentId)
                .ForeignKey("dbo.AuthorEntityModels", t => t.AuthorId)
                .ForeignKey("dbo.NewsEntityModels", t => t.NewsId)
                .Index(t => t.NewsId)
                .Index(t => t.AuthorId);
            
            CreateTable(
                "dbo.NewsEntityModels",
                c => new
                    {
                        NewsId = c.Int(nullable: false, identity: true),
                        AuthorId = c.Int(),
                        NewsCreated = c.DateTime(nullable: false),
                        Title = c.String(),
                        Summary = c.String(),
                        Category = c.String(),
                        Content = c.String(),
                        RatingCount = c.Int(nullable: false),
                        Rating = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CategoryEntityModel_CategoryId = c.Int(),
                    })
                .PrimaryKey(t => t.NewsId)
                .ForeignKey("dbo.AuthorEntityModels", t => t.AuthorId)
                .ForeignKey("dbo.CategoryEntityModels", t => t.CategoryEntityModel_CategoryId)
                .Index(t => t.AuthorId)
                .Index(t => t.CategoryEntityModel_CategoryId);
            
            CreateTable(
                "dbo.TagEntityModels",
                c => new
                    {
                        TagId = c.Int(nullable: false, identity: true),
                        TagName = c.String(),
                    })
                .PrimaryKey(t => t.TagId);
            
            CreateTable(
                "dbo.CategoryEntityModels",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.TagEntityModelNewsEntityModels",
                c => new
                    {
                        TagEntityModel_TagId = c.Int(nullable: false),
                        NewsEntityModel_NewsId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.TagEntityModel_TagId, t.NewsEntityModel_NewsId })
                .ForeignKey("dbo.TagEntityModels", t => t.TagEntityModel_TagId, cascadeDelete: true)
                .ForeignKey("dbo.NewsEntityModels", t => t.NewsEntityModel_NewsId, cascadeDelete: true)
                .Index(t => t.TagEntityModel_TagId)
                .Index(t => t.NewsEntityModel_NewsId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.NewsEntityModels", "CategoryEntityModel_CategoryId", "dbo.CategoryEntityModels");
            DropForeignKey("dbo.TagEntityModelNewsEntityModels", "NewsEntityModel_NewsId", "dbo.NewsEntityModels");
            DropForeignKey("dbo.TagEntityModelNewsEntityModels", "TagEntityModel_TagId", "dbo.TagEntityModels");
            DropForeignKey("dbo.CommentEntityModels", "NewsId", "dbo.NewsEntityModels");
            DropForeignKey("dbo.NewsEntityModels", "AuthorId", "dbo.AuthorEntityModels");
            DropForeignKey("dbo.CommentEntityModels", "AuthorId", "dbo.AuthorEntityModels");
            DropIndex("dbo.TagEntityModelNewsEntityModels", new[] { "NewsEntityModel_NewsId" });
            DropIndex("dbo.TagEntityModelNewsEntityModels", new[] { "TagEntityModel_TagId" });
            DropIndex("dbo.NewsEntityModels", new[] { "CategoryEntityModel_CategoryId" });
            DropIndex("dbo.NewsEntityModels", new[] { "AuthorId" });
            DropIndex("dbo.CommentEntityModels", new[] { "AuthorId" });
            DropIndex("dbo.CommentEntityModels", new[] { "NewsId" });
            DropTable("dbo.TagEntityModelNewsEntityModels");
            DropTable("dbo.CategoryEntityModels");
            DropTable("dbo.TagEntityModels");
            DropTable("dbo.NewsEntityModels");
            DropTable("dbo.CommentEntityModels");
            DropTable("dbo.AuthorEntityModels");
        }
    }
}
