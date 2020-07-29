namespace prjIAAI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBackendBase : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Articles", "Poster", c => c.String(maxLength: 20));
            AddColumn("dbo.Articles", "InitDate", c => c.DateTime());
            AddColumn("dbo.Articles", "Updater", c => c.String(maxLength: 20));
            AddColumn("dbo.Articles", "UpdateDate", c => c.DateTime());
            AddColumn("dbo.Experts", "Poster", c => c.String(maxLength: 20));
            AddColumn("dbo.Experts", "InitDate", c => c.DateTime());
            AddColumn("dbo.Experts", "Updater", c => c.String(maxLength: 20));
            AddColumn("dbo.Experts", "UpdateDate", c => c.DateTime());
            AddColumn("dbo.ForumPosts", "Poster", c => c.String(maxLength: 20));
            AddColumn("dbo.ForumPosts", "InitDate", c => c.DateTime());
            AddColumn("dbo.ForumPosts", "Updater", c => c.String(maxLength: 20));
            AddColumn("dbo.ForumPosts", "UpdateDate", c => c.DateTime());
            AddColumn("dbo.ForumReplies", "Poster", c => c.String(maxLength: 20));
            AddColumn("dbo.ForumReplies", "InitDate", c => c.DateTime());
            AddColumn("dbo.ForumReplies", "Updater", c => c.String(maxLength: 20));
            AddColumn("dbo.ForumReplies", "UpdateDate", c => c.DateTime());
            AddColumn("dbo.IndexImages", "Poster", c => c.String(maxLength: 20));
            AddColumn("dbo.IndexImages", "InitDate", c => c.DateTime());
            AddColumn("dbo.IndexImages", "Updater", c => c.String(maxLength: 20));
            AddColumn("dbo.IndexImages", "UpdateDate", c => c.DateTime());
            AddColumn("dbo.Knowledges", "Poster", c => c.String(maxLength: 20));
            AddColumn("dbo.Knowledges", "InitDate", c => c.DateTime());
            AddColumn("dbo.Knowledges", "Updater", c => c.String(maxLength: 20));
            AddColumn("dbo.Knowledges", "UpdateDate", c => c.DateTime());
            AddColumn("dbo.Links", "Poster", c => c.String(maxLength: 20));
            AddColumn("dbo.Links", "InitDate", c => c.DateTime());
            AddColumn("dbo.Links", "Updater", c => c.String(maxLength: 20));
            AddColumn("dbo.Links", "UpdateDate", c => c.DateTime());
            AddColumn("dbo.Members", "Poster", c => c.String(maxLength: 20));
            AddColumn("dbo.Members", "InitDate", c => c.DateTime());
            AddColumn("dbo.Members", "Updater", c => c.String(maxLength: 20));
            AddColumn("dbo.Members", "UpdateDate", c => c.DateTime());
            AddColumn("dbo.Roles", "Poster", c => c.String(maxLength: 20));
            AddColumn("dbo.Roles", "InitDate", c => c.DateTime());
            AddColumn("dbo.Roles", "Updater", c => c.String(maxLength: 20));
            AddColumn("dbo.Roles", "UpdateDate", c => c.DateTime());
            AddColumn("dbo.News", "Poster", c => c.String(maxLength: 20));
            AddColumn("dbo.News", "InitDate", c => c.DateTime());
            AddColumn("dbo.News", "Updater", c => c.String(maxLength: 20));
            AddColumn("dbo.News", "UpdateDate", c => c.DateTime());
            DropColumn("dbo.Articles", "PostDate");
            DropColumn("dbo.Articles", "Publisher");
            DropColumn("dbo.Articles", "EditDate");
            DropColumn("dbo.Articles", "Editor");
            DropColumn("dbo.ForumPosts", "PostDate");
            DropColumn("dbo.ForumPosts", "Publisher");
            DropColumn("dbo.ForumReplies", "ReplyDate");
            DropColumn("dbo.ForumReplies", "ReplyPublisher");
            DropColumn("dbo.News", "PostDate");
            DropColumn("dbo.News", "Publisher");
        }
        
        public override void Down()
        {
            AddColumn("dbo.News", "Publisher", c => c.String());
            AddColumn("dbo.News", "PostDate", c => c.DateTime());
            AddColumn("dbo.ForumReplies", "ReplyPublisher", c => c.String());
            AddColumn("dbo.ForumReplies", "ReplyDate", c => c.DateTime());
            AddColumn("dbo.ForumPosts", "Publisher", c => c.String());
            AddColumn("dbo.ForumPosts", "PostDate", c => c.DateTime());
            AddColumn("dbo.Articles", "Editor", c => c.String());
            AddColumn("dbo.Articles", "EditDate", c => c.DateTime());
            AddColumn("dbo.Articles", "Publisher", c => c.String());
            AddColumn("dbo.Articles", "PostDate", c => c.DateTime());
            DropColumn("dbo.News", "UpdateDate");
            DropColumn("dbo.News", "Updater");
            DropColumn("dbo.News", "InitDate");
            DropColumn("dbo.News", "Poster");
            DropColumn("dbo.Roles", "UpdateDate");
            DropColumn("dbo.Roles", "Updater");
            DropColumn("dbo.Roles", "InitDate");
            DropColumn("dbo.Roles", "Poster");
            DropColumn("dbo.Members", "UpdateDate");
            DropColumn("dbo.Members", "Updater");
            DropColumn("dbo.Members", "InitDate");
            DropColumn("dbo.Members", "Poster");
            DropColumn("dbo.Links", "UpdateDate");
            DropColumn("dbo.Links", "Updater");
            DropColumn("dbo.Links", "InitDate");
            DropColumn("dbo.Links", "Poster");
            DropColumn("dbo.Knowledges", "UpdateDate");
            DropColumn("dbo.Knowledges", "Updater");
            DropColumn("dbo.Knowledges", "InitDate");
            DropColumn("dbo.Knowledges", "Poster");
            DropColumn("dbo.IndexImages", "UpdateDate");
            DropColumn("dbo.IndexImages", "Updater");
            DropColumn("dbo.IndexImages", "InitDate");
            DropColumn("dbo.IndexImages", "Poster");
            DropColumn("dbo.ForumReplies", "UpdateDate");
            DropColumn("dbo.ForumReplies", "Updater");
            DropColumn("dbo.ForumReplies", "InitDate");
            DropColumn("dbo.ForumReplies", "Poster");
            DropColumn("dbo.ForumPosts", "UpdateDate");
            DropColumn("dbo.ForumPosts", "Updater");
            DropColumn("dbo.ForumPosts", "InitDate");
            DropColumn("dbo.ForumPosts", "Poster");
            DropColumn("dbo.Experts", "UpdateDate");
            DropColumn("dbo.Experts", "Updater");
            DropColumn("dbo.Experts", "InitDate");
            DropColumn("dbo.Experts", "Poster");
            DropColumn("dbo.Articles", "UpdateDate");
            DropColumn("dbo.Articles", "Updater");
            DropColumn("dbo.Articles", "InitDate");
            DropColumn("dbo.Articles", "Poster");
        }
    }
}
