namespace prjIAAI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditContentToNewsContent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.News", "newsContent", c => c.String());
            DropColumn("dbo.News", "content");
        }
        
        public override void Down()
        {
            AddColumn("dbo.News", "content", c => c.String());
            DropColumn("dbo.News", "newsContent");
        }
    }
}
