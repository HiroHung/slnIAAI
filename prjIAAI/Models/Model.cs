namespace prjIAAI.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model : DbContext
    {
        public Model()
            : base("name=dbIAAI")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
        public virtual DbSet<News> Newses { get; set; }
        public virtual DbSet<Article> Articles { get; set; }
        public virtual DbSet<Links> Linkses { get; set; }
        public virtual DbSet<Member> Members { get; set; }
        public virtual DbSet<Expert> Experts { get; set; }
        public virtual DbSet<Knowledge> Knowledges { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<IndexImage> IndexImages { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Permission> Permissions { get; set; }
        public virtual DbSet<ForumPost> ForumPosts { get; set; }
        public virtual DbSet<ForumReply> ForumReply { get; set; }
    }
}
