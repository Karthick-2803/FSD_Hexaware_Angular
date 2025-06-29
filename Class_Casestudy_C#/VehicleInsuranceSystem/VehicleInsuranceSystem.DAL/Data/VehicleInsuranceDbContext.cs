using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VehicleInsuranceSystem.DAL.Models;

namespace VehicleInsuranceSystem.DAL.Data
{
    public class VehicleInsuranceDbContext : DbContext
    {
        public VehicleInsuranceDbContext(DbContextOptions<VehicleInsuranceDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<PolicyProposal> PolicyProposals { get; set; }
        public DbSet<Policy> Policies { get; set; }
        public DbSet<AddOn> AddOns { get; set; }
        public DbSet<PolicyAddOn> PolicyAddOns { get; set; }
        public DbSet<Claim> Claims { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PolicyAddOn>()
                .HasKey(pa => new { pa.PolicyProposalId, pa.AddOnId });

            modelBuilder.Entity<PolicyAddOn>()
                .HasOne(pa => pa.PolicyProposal)
                .WithMany(p => p.PolicyAddOns)
                .HasForeignKey(pa => pa.PolicyProposalId);

            modelBuilder.Entity<PolicyAddOn>()
                .HasOne(pa => pa.AddOn)
                .WithMany(a => a.PolicyAddOns)
                .HasForeignKey(pa => pa.AddOnId);

            modelBuilder.Entity<PolicyProposal>()
              .HasOne(p => p.Vehicle)
              .WithOne(v => v.PolicyProposal)
              .HasForeignKey<PolicyProposal>(p => p.VehicleId)
              .OnDelete(DeleteBehavior.Restrict);  // Prevents cascade path error

            modelBuilder.Entity<PolicyProposal>()
                .HasOne(p => p.User)
                .WithMany(u => u.PolicyProposals)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<AddOn>().HasData(
              new AddOn { AddOnId = 1, Name = "Roadside Assistance", Cost = 1000 },
              new AddOn { AddOnId = 2, Name = "Engine Protection", Cost = 1500 },
              new AddOn { AddOnId = 3, Name = "Zero Depreciation", Cost = 2000 },
              new AddOn { AddOnId = 4, Name = "Tyre Cover", Cost = 800 },
              new AddOn { AddOnId = 5, Name = "Key Replacement", Cost = 600 }
              );

            //modelBuilder.Entity<PolicyProposal>()
            //    .HasOne(p => p.Claim)
            //    .WithOne(c => c.PolicyProposal)
            //    .HasForeignKey<PolicyProposal>(p => p.ClaimId)
            //    .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
