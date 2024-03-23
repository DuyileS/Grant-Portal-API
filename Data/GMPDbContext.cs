using GMP.API.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Task = GMP.API.Models.Domain.Task;

namespace GMP.API.Data
{
    public class GMPDbContext : DbContext
    {

        public GMPDbContext(DbContextOptions<GMPDbContext> dbContextOptions) : base(dbContextOptions) 
        {
            
        }

        public DbSet<Applicant> Applicants { get; set; }
        public DbSet<Awardees> Awardees { get; set; }
        public DbSet<Grant> Grants { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Notification> Notifications { get; set; }
/*
        public DbSet<GrantApplicant> GrantApplicants { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GrantApplicant>()
                .HasKey(ga => new { ga.GrantId, ga.ApplicantId });
            modelBuilder.Entity<GrantApplicant>()
                .HasOne(g => g.Grant)
                .WithMany(ga => ga.GrantApplicants)
                .HasForeignKey(g => g.GrantId);
            modelBuilder.Entity<GrantApplicant>()
               .HasOne(a => a.Applicant)
               .WithMany(ga => ga.GrantApplicants)
               .HasForeignKey(a => a.ApplicantId);

            base.OnModelCreating(modelBuilder);
        }
       */
    }
}
