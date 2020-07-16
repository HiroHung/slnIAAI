namespace prjIAAI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGroup : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GroupName = c.String(nullable: false, maxLength: 50),
                        Permission = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GroupAdministrations",
                c => new
                    {
                        Group_Id = c.Int(nullable: false),
                        Administration_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Group_Id, t.Administration_Id })
                .ForeignKey("dbo.Groups", t => t.Group_Id, cascadeDelete: true)
                .ForeignKey("dbo.Administrations", t => t.Administration_Id, cascadeDelete: true)
                .Index(t => t.Group_Id)
                .Index(t => t.Administration_Id);
            
            AlterColumn("dbo.Administrations", "Permission", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GroupAdministrations", "Administration_Id", "dbo.Administrations");
            DropForeignKey("dbo.GroupAdministrations", "Group_Id", "dbo.Groups");
            DropIndex("dbo.GroupAdministrations", new[] { "Administration_Id" });
            DropIndex("dbo.GroupAdministrations", new[] { "Group_Id" });
            AlterColumn("dbo.Administrations", "Permission", c => c.String(nullable: false, maxLength: 50));
            DropTable("dbo.GroupAdministrations");
            DropTable("dbo.Groups");
        }
    }
}
