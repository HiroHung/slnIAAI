namespace prjIAAI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class delAdminPermission : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Administrations", "Permission");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Administrations", "Permission", c => c.String(nullable: false));
        }
    }
}
