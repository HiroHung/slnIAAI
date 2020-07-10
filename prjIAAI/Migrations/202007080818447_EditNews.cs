namespace prjIAAI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditNews : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.News", "title", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.News", "introduction", c => c.String(nullable: false, maxLength: 60));
            AddColumn("dbo.News", "content", c => c.String());
            AddColumn("dbo.News", "postDate", c => c.DateTime());
            AddColumn("dbo.News", "publisher", c => c.String());
            AddColumn("dbo.News", "image", c => c.String());
            AddColumn("dbo.News", "top", c => c.Int(nullable: false));
            AddColumn("dbo.News", "highlight", c => c.Int(nullable: false));
            AddColumn("dbo.News", "clicks", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.News", "clicks");
            DropColumn("dbo.News", "highlight");
            DropColumn("dbo.News", "top");
            DropColumn("dbo.News", "image");
            DropColumn("dbo.News", "publisher");
            DropColumn("dbo.News", "postDate");
            DropColumn("dbo.News", "content");
            DropColumn("dbo.News", "introduction");
            DropColumn("dbo.News", "title");
        }
    }
}
