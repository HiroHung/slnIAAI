namespace prjIAAI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddExpert : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Experts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        JobTitle = c.String(nullable: false),
                        Photo = c.String(),
                        Education = c.String(nullable: false),
                        Introduction = c.String(),
                        About = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Experts");
        }
    }
}
