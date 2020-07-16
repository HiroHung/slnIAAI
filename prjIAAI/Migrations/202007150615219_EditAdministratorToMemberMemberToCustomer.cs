namespace prjIAAI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditAdministratorToMemberMemberToCustomer : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RoleAdministrations", "Role_Id", "dbo.Roles");
            DropForeignKey("dbo.RoleAdministrations", "Administration_Id", "dbo.Administrations");
            DropIndex("dbo.RoleAdministrations", new[] { "Role_Id" });
            DropIndex("dbo.RoleAdministrations", new[] { "Administration_Id" });
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Account = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 100),
                        PasswordSalt = c.String(),
                        Name = c.String(nullable: false, maxLength: 50),
                        Gender = c.Int(nullable: false),
                        BirthDate = c.DateTime(nullable: false),
                        Type = c.Int(nullable: false),
                        Tel = c.String(nullable: false, maxLength: 50),
                        CellPhone = c.String(nullable: false, maxLength: 50),
                        Address = c.String(nullable: false, maxLength: 500),
                        Email = c.String(nullable: false, maxLength: 200),
                        Membership = c.String(),
                        CurrentJob = c.String(nullable: false),
                        CurrentJobTitle = c.String(nullable: false),
                        HighestEducation = c.String(nullable: false),
                        ServiceUnits = c.String(nullable: false),
                        ServiceJobTitle = c.String(nullable: false),
                        StartYear = c.String(nullable: false),
                        StartMonth = c.String(nullable: false),
                        EndYear = c.String(nullable: false),
                        EndMonth = c.String(nullable: false),
                        SeniorityYear = c.String(nullable: false),
                        SeniorityMonth = c.String(nullable: false),
                        Verify = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Members", "Photo", c => c.String());
            AddColumn("dbo.Members", "JobTitle", c => c.String());
            AlterColumn("dbo.Members", "Tel", c => c.String(maxLength: 50));
            DropColumn("dbo.Members", "BirthDate");
            DropColumn("dbo.Members", "Type");
            DropColumn("dbo.Members", "CellPhone");
            DropColumn("dbo.Members", "Address");
            DropColumn("dbo.Members", "Membership");
            DropColumn("dbo.Members", "CurrentJob");
            DropColumn("dbo.Members", "CurrentJobTitle");
            DropColumn("dbo.Members", "HighestEducation");
            DropColumn("dbo.Members", "ServiceUnits");
            DropColumn("dbo.Members", "ServiceJobTitle");
            DropColumn("dbo.Members", "StartYear");
            DropColumn("dbo.Members", "StartMonth");
            DropColumn("dbo.Members", "EndYear");
            DropColumn("dbo.Members", "EndMonth");
            DropColumn("dbo.Members", "SeniorityYear");
            DropColumn("dbo.Members", "SeniorityMonth");
            DropColumn("dbo.Members", "Verify");
            DropTable("dbo.Administrations");
            DropTable("dbo.RoleAdministrations");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.RoleAdministrations",
                c => new
                    {
                        Role_Id = c.Int(nullable: false),
                        Administration_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Role_Id, t.Administration_Id });
            
            CreateTable(
                "dbo.Administrations",
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
                        Photo = c.String(),
                        JobTitle = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Members", "Verify", c => c.Int());
            AddColumn("dbo.Members", "SeniorityMonth", c => c.String(nullable: false));
            AddColumn("dbo.Members", "SeniorityYear", c => c.String(nullable: false));
            AddColumn("dbo.Members", "EndMonth", c => c.String(nullable: false));
            AddColumn("dbo.Members", "EndYear", c => c.String(nullable: false));
            AddColumn("dbo.Members", "StartMonth", c => c.String(nullable: false));
            AddColumn("dbo.Members", "StartYear", c => c.String(nullable: false));
            AddColumn("dbo.Members", "ServiceJobTitle", c => c.String(nullable: false));
            AddColumn("dbo.Members", "ServiceUnits", c => c.String(nullable: false));
            AddColumn("dbo.Members", "HighestEducation", c => c.String(nullable: false));
            AddColumn("dbo.Members", "CurrentJobTitle", c => c.String(nullable: false));
            AddColumn("dbo.Members", "CurrentJob", c => c.String(nullable: false));
            AddColumn("dbo.Members", "Membership", c => c.String());
            AddColumn("dbo.Members", "Address", c => c.String(nullable: false, maxLength: 500));
            AddColumn("dbo.Members", "CellPhone", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Members", "Type", c => c.Int(nullable: false));
            AddColumn("dbo.Members", "BirthDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Members", "Tel", c => c.String(nullable: false, maxLength: 50));
            DropColumn("dbo.Members", "JobTitle");
            DropColumn("dbo.Members", "Photo");
            DropTable("dbo.Customers");
            CreateIndex("dbo.RoleAdministrations", "Administration_Id");
            CreateIndex("dbo.RoleAdministrations", "Role_Id");
            AddForeignKey("dbo.RoleAdministrations", "Administration_Id", "dbo.Administrations", "Id", cascadeDelete: true);
            AddForeignKey("dbo.RoleAdministrations", "Role_Id", "dbo.Roles", "Id", cascadeDelete: true);
        }
    }
}
