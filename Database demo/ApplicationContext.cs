using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Database_demo
{
    internal class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Challenge> Challenges { get; set; } = null!;

        public ApplicationContext()
        {
            //    Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=../../../demoMigrations1.db");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Challenge>()
                .HasMany(c => c.Members)
                .WithMany(s => s.Challenges)
                .UsingEntity<Enrollment>(
                   j => j
                    .HasOne(pt => pt.User)
                    .WithMany(t => t.Enrollments)
                    .HasForeignKey(pt => pt.UserId),
                j => j
                    .HasOne(pt => pt.Challenge)
                    .WithMany(p => p.Enrollments)
                    .HasForeignKey(pt => pt.ChallengeId),
                j =>
                {
                    j.Property(pt => pt.isCompleted).HasDefaultValue(false);
                    j.HasKey(t => new { t.ChallengeId, t.UserId });
                    j.ToTable("Enrollments");
                });

        }
    }
}
