namespace prjIAAI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditMember : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Members", "Tel", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Members", "CellPhone", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Members", "CellPhone", c => c.String(maxLength: 50));
            AlterColumn("dbo.Members", "Tel", c => c.String(maxLength: 50));
        }
    }
}
