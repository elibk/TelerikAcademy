using Forum.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Data
{
    public class ForumContext : DbContext
    {
        public ForumContext()
            : base("ForumDb")
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Tag> Tags { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<User>()
        //        .Property(usr => usr.SessionKey)
        //        .IsFixedLength()
        //        .HasMaxLength(40);
        //    base.OnModelCreating(modelBuilder);

        //    modelBuilder.Entity<User>()
        //        .Property(usr => usr.SessionKey)
        //        .HasMaxLength(40)
        //        .IsOptional()
        //        .;
        //    base.OnModelCreating(modelBuilder);
        //}
    }
}
