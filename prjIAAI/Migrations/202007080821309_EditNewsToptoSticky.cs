namespace prjIAAI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditNewsToptoSticky : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.News", "sticky", c => c.Int(nullable: false));
            DropColumn("dbo.News", "top");
        }
        
        public override void Down()
        {
            AddColumn("dbo.News", "top", c => c.Int(nullable: false));
            DropColumn("dbo.News", "sticky");
        }
    }
}
