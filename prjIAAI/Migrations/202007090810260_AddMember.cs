namespace prjIAAI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMember : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Members",
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
                        Tel = c.String(maxLength: 50),
                        CellPhone = c.String(maxLength: 50),
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
                        Verify = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Members");
        }
    }
}
