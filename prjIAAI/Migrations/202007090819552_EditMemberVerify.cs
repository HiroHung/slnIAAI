namespace prjIAAI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditMemberVerify : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Members", "Verify", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Members", "Verify", c => c.Int(nullable: false));
        }
    }
}
