namespace prjIAAI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FKRoleAndMember : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RoleMembers",
                c => new
                    {
                        Role_Id = c.Int(nullable: false),
                        Member_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Role_Id, t.Member_Id })
                .ForeignKey("dbo.Roles", t => t.Role_Id, cascadeDelete: true)
                .ForeignKey("dbo.Members", t => t.Member_Id, cascadeDelete: true)
                .Index(t => t.Role_Id)
                .Index(t => t.Member_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RoleMembers", "Member_Id", "dbo.Members");
            DropForeignKey("dbo.RoleMembers", "Role_Id", "dbo.Roles");
            DropIndex("dbo.RoleMembers", new[] { "Member_Id" });
            DropIndex("dbo.RoleMembers", new[] { "Role_Id" });
            DropTable("dbo.RoleMembers");
        }
    }
}
