using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DAL.Models
{
    public class EventDetailsContext : DbContext
    {
        public DbSet<UserInfo> Users { get; set; }
        public DbSet<EventDetails> Events { get; set; }
        public DbSet<SpeakersDetails> Speakers { get; set; }
        public DbSet<SessionInfo> Sessions { get; set; }
        public DbSet<ParticipantEventDetails> ParticipantEvents { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(DatabaseHelper.GetConnectionString());
            }

            base.OnConfiguring(optionsBuilder);
        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    // Set primary key
        //    modelBuilder.Entity<UserInfo>().HasKey(u => u.EmailId);
        //    modelBuilder.Entity<EventDetails>().HasKey(e => e.EventId);
        //    modelBuilder.Entity<SpeakersDetails>().HasKey(s => s.SpeakerId);
        //    modelBuilder.Entity<SessionInfo>().HasKey(s => s.SessionId);
        //    modelBuilder.Entity<ParticipantEventDetails>().HasKey(p => p.Id);
        //}
    }
}
