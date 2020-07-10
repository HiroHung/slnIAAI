namespace prjIAAI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editAdminName : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Admins", newName: "Administrations");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Administrations", newName: "Admins");
        }
    }
}
