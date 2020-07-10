namespace prjIAAI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIndexImage : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.IndexImages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 50),
                        Image = c.String(),
                        LinkUrl = c.String(),
                        Display = c.Int(nullable: false),
                        Sort = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.IndexImages");
        }
    }
}
