using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ITNews.DAL.EntityModels;

namespace ITNews.DAL.EF
{
    public class NewsContext : DbContext
    {
        public NewsContext() : base("NewsContext")
        { }

        public DbSet<NewsEntityModel> News { get; set; }
        public DbSet<AuthorEntityModel> Authors { get; set; }
        public DbSet<CommentEntityModel> Comments { get; set; }
        public DbSet<TagEntityModel> Tags { get; set; }
        public DbSet<CategoryEntityModel> Categories { get; set; }

        static NewsContext()
        {
           
        }

        public NewsContext(string connectionString)
            : base(connectionString)
        {
        }

       

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {



            var comment = modelBuilder.Entity<CommentEntityModel>();
            comment.HasKey(s => s.CommentId);
            comment.HasOptional(s => s.Author)
                .WithMany(s => s.Comments)
                .HasForeignKey(s => s.AuthorId);

            var news = modelBuilder.Entity<NewsEntityModel>();
            news.HasKey(s => s.NewsId);
            news.HasOptional(s => s.Author)
                .WithMany(s => s.News)
                .HasForeignKey(s => s.AuthorId);

            //news.HasMany(s => s.Tags)
            //    .WithMany(s => s.News)
            //     .Map(mc =>
            //     {
            //         mc.ToTable("PostJoinTag");
            //         mc.MapLeftKey("NewsId");
            //         mc.MapRightKey("TagId");
            //     });


        }
    }
}
