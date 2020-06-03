using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApp.Models;

namespace ToDoApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Todo> Todos { get; set; }
        public DbSet<TodoTag> TodoTags { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //primary key for TodoTag would be a composite key(Tag and Todo)
            builder.Entity<TodoTag>()
                   .HasKey(tt => new { tt.TagId, tt.TodoId });

            builder.Entity<TodoTag>()
                   .HasOne(tt => tt.Todo)
                   .WithMany(tt => tt.TodoTags)
                   .HasForeignKey(tt => tt.TodoId);

            builder.Entity<TodoTag>()
                   .HasOne(tt => tt.Tag)
                   .WithMany(tt => tt.TodoTags)
                   .HasForeignKey(tt => tt.TagId);

            //optimistic concurrency
            builder.Entity<Todo>()
                   .Property(p => p.RowVersion)
                   .IsRowVersion();
        }
    }
}
