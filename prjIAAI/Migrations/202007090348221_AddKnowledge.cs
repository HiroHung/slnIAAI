namespace prjIAAI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddKnowledge : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Knowledges",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 50),
                        Introduction = c.String(nullable: false),
                        Image = c.String(),
                        Sticky = c.Int(nullable: false),
                        KnowledgeContent = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Knowledges");
        }
    }
}
