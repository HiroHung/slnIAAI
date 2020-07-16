namespace prjIAAI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editPermission : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Permissions", "ControlName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Permissions", "ControlName");
        }
    }
}
