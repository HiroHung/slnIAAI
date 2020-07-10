namespace prjIAAI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAdmin : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Account = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 100),
                        PasswordSalt = c.String(),
                        Email = c.String(nullable: false, maxLength: 200),
                        Gender = c.Int(nullable: false),
                        Tel = c.String(maxLength: 50),
                        Permission = c.String(nullable: false, maxLength: 50),
                        Photo = c.String(),
                        JobTitle = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Admins");
        }
    }
}
