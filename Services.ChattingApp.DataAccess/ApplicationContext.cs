using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Services.ChattingApp.Domain.Entities;
using System.Collections.Generic;

namespace Services.ChattingApp.DataAccess
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Conversation> Conversations { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.Entity<GroupUsers>()
            //    .HasKey(e => new { e.UserId, e.GroupId });

            //builder.Entity<GroupUsers>()
            //    .HasOne(e => e.UserId)
            //    .WithMany(e => e.Groups)
            //    .HasForeignKey(e => e.UserId);

        }
    }
}