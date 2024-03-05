using Microsoft.EntityFrameworkCore;
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
    }
}