namespace prjIAAI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addForum : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Groups", newName: "Roles");
            RenameTable(name: "dbo.GroupAdministrations", newName: "RoleAdministrations");
            RenameColumn(table: "dbo.RoleAdministrations", name: "Group_Id", newName: "Role_Id");
            RenameIndex(table: "dbo.RoleAdministrations", name: "IX_Group_Id", newName: "IX_Role_Id");
            CreateTable(
                "dbo.ForumPosts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 50),
                        PostContent = c.String(),
                        PostDate = c.DateTime(),
                        Publisher = c.String(),
                        Clicks = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ForumReplies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ReplyContent = c.String(),
                        ReplyDate = c.DateTime(),
                        ReplyPublisher = c.String(),
                        PostId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ForumPosts", t => t.PostId, cascadeDelete: true)
                .Index(t => t.PostId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ForumReplies", "PostId", "dbo.ForumPosts");
            DropIndex("dbo.ForumReplies", new[] { "PostId" });
            DropTable("dbo.ForumReplies");
            DropTable("dbo.ForumPosts");
            RenameIndex(table: "dbo.RoleAdministrations", name: "IX_Role_Id", newName: "IX_Group_Id");
            RenameColumn(table: "dbo.RoleAdministrations", name: "Role_Id", newName: "Group_Id");
            RenameTable(name: "dbo.RoleAdministrations", newName: "GroupAdministrations");
            RenameTable(name: "dbo.Roles", newName: "Groups");
        }
    }
}
