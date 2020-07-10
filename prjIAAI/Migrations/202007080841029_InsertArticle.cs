namespace prjIAAI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InsertArticle : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Articles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        title = c.String(nullable: false, maxLength: 50),
                        articleContent = c.String(),
                        postDate = c.DateTime(),
                        publisher = c.String(),
                        editDate = c.DateTime(),
                        editor = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Articles");
        }
    }
}
