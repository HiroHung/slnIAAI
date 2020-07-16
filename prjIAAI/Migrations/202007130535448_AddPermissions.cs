namespace prjIAAI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPermissions : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Permissions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Subject = c.String(nullable: false, maxLength: 50),
                        pid = c.Int(),
                        pvalue = c.String(nullable: false, maxLength: 50),
                        url = c.String(maxLength: 200),
                        icon = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Permissions", t => t.pid)
                .Index(t => t.pid);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Permissions", "pid", "dbo.Permissions");
            DropIndex("dbo.Permissions", new[] { "pid" });
            DropTable("dbo.Permissions");
        }
    }
}
