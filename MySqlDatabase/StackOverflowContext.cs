using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel;

namespace MySqlDatabase
{
    public class StackOverflowContext : DbContext
    {
        public StackOverflowContext() : base("stackoverlfow")
        {

        }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Annotation> Annotations { get; set; }
        public DbSet<SearchHistory> SearchHisotries { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            /***************************************
                        Posts
            ***************************************/
            modelBuilder.Entity<Post>().ToTable("posts");
            modelBuilder.Entity<Post>().Property(p => p.Id).HasColumnName("id");
            modelBuilder.Entity<Post>().Property(p => p.PostTypeId).HasColumnName("posttypeid");
            modelBuilder.Entity<Post>().Property(p => p.ParentId).HasColumnName("parentid");
            modelBuilder.Entity<Post>().Property(p => p.AcceptedAnswerId).HasColumnName("acceptedanswerid");
            modelBuilder.Entity<Post>().Property(p => p.CreatedDate).HasColumnName("creationdate");
            modelBuilder.Entity<Post>().Property(p => p.Score).HasColumnName("score");
            modelBuilder.Entity<Post>().Property(p => p.Body).HasColumnName("body");
            modelBuilder.Entity<Post>().Property(p => p.CloseDate).HasColumnName("closeddate");
            modelBuilder.Entity<Post>().Property(p => p.Title).HasColumnName("title");
            modelBuilder.Entity<Post>().Property(p => p.UserId).HasColumnName("userid");
            modelBuilder.Entity<Post>().Property(p => p.Mark).HasColumnName("mark");

            /***************************************
                        Annotation
            ***************************************/
            modelBuilder.Entity<Annotation>().ToTable("annotation");
            modelBuilder.Entity<Annotation>().Property(a => a.Id).HasColumnName("annotationid");
            modelBuilder.Entity<Annotation>().Property(a => a.PostId).HasColumnName("postid");
            modelBuilder.Entity<Annotation>().Property(a => a.CommentId).HasColumnName("commentid");
            modelBuilder.Entity<Annotation>()
                .Property(a => a.AnnotationDescription)
                .HasColumnName("annotationdescription");
            modelBuilder.Entity<Annotation>()
                .Property(a => a.AnnotationCreateDate)
                .HasColumnName("annotationcreatedate");
            base.OnModelCreating(modelBuilder);
            

            /***************************************
                    Comments
            ****************************************/
            modelBuilder.Entity<Comment>().ToTable("comments");
            modelBuilder.Entity<Comment>().Property(c => c.Id).HasColumnName("commentid");
            modelBuilder.Entity<Comment>().Property(c => c.Score).HasColumnName("commentscore");
            modelBuilder.Entity<Comment>().Property(c => c.Text).HasColumnName("commenttext");
            modelBuilder.Entity<Comment>().Property(c => c.CreatedDate).HasColumnName("commentcreatedate");
            modelBuilder.Entity<Comment>().Property(c => c.PostId).HasColumnName("postid");
            modelBuilder.Entity<Comment>().Property(c => c.UserId).HasColumnName("userid");
            modelBuilder.Entity<Comment>().Property(c => c.Mark).HasColumnName("mark");

            /**************************************
                    Search Hisoty
            ***************************************/
            modelBuilder.Entity<SearchHistory>().ToTable("searchhistory");
            modelBuilder.Entity<SearchHistory>().Property(sh => sh.Id).HasColumnName("searchhistoryid");
            modelBuilder.Entity<SearchHistory>().Property(sh => sh.Keyword).HasColumnName("keyword");
            modelBuilder.Entity<SearchHistory>().Property(sh => sh.SearchDateTime).HasColumnName("searchdatetime");

            /**********************
                        Tags
            ***********************/
            modelBuilder.Entity<Tag>().ToTable("tags");
            modelBuilder.Entity<Tag>().Property(t => t.PostId).HasColumnName("postid");
            modelBuilder.Entity<Tag>().Property(t => t.Tagtype).HasColumnName("tagtype");


            /**********************
                    Users
            ***********************/
            modelBuilder.Entity<User>().ToTable("user");
            modelBuilder.Entity<User>().Property(u => u.Id).HasColumnName("userid");
            modelBuilder.Entity<User>().Property(u => u.DisplayName).HasColumnName("userdisplayname");
            modelBuilder.Entity<User>().Property(u => u.creationDate).HasColumnName("usercreationdate");
            modelBuilder.Entity<User>().Property(u => u.Location).HasColumnName("userlocation");
            modelBuilder.Entity<User>().Property(u => u.Age).HasColumnName("userage");

            base.OnModelCreating(modelBuilder);
        }
    }
}
