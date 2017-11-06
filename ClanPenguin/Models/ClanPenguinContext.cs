using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClanPenguin.Models
{
    public class ClanPenguinContext : IdentityDbContext<User>
    {
        public ClanPenguinContext(DbContextOptions<ClanPenguinContext> options) : base(options)
        {
        }
        public DbSet<Chatroom> Chatrooms { get; set; }
        public DbSet<Message> Messages { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                    .HasMany(t => t.Chatrooms);
            modelBuilder.Entity<User>()
                    .HasMany(t => t.Messages);
            modelBuilder.Entity<User>()
                    .HasMany(t => t.Friends);
            modelBuilder.Entity<Chatroom>()
                .HasMany(t => t.Users);
            modelBuilder.Entity<Chatroom>()
                    .HasMany(t => t.Messages);
            modelBuilder.Entity<User>()
                .ToTable("User");
            base.OnModelCreating(modelBuilder);
        }
    }
}
