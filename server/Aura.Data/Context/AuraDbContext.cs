using Aura.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Aura.Data.Context;

public class AuraDbContext : DbContext
{
    public AuraDbContext(DbContextOptions<AuraDbContext> options) : base(options)
    {
    }

    public DbSet<CandidateData> Candidates { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<ReportingManager> ReportingManagers { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<AuditLog> AuditLogs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // CandidateData Configuration
        modelBuilder.Entity<CandidateData>(entity =>
        {
            entity.ToTable("Candidate_data");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Title).IsRequired().HasMaxLength(200);
            
            // Checklist mapping
            entity.Property(e => e.ResumeCollection).HasColumnName("resume_collection");
            entity.Property(e => e.PassportCopy).HasColumnName("passport_copy");
            entity.Property(e => e.H1bApprovalCopy).HasColumnName("h1b_approval_copy");
            entity.Property(e => e.RecruiterTimestamp).HasColumnName("recruiter_timestamp");

            entity.Property(e => e.HrTimestamp).HasColumnName("hr_timestamp");
            entity.Property(e => e.ItTimestamp).HasColumnName("it_timestamp");
            entity.Property(e => e.AuditTimestamp).HasColumnName("audit_timestamp");
            entity.Property(e => e.PctTimestamp).HasColumnName("pct_timestamp");
            entity.Property(e => e.ManagerTimestamp).HasColumnName("manager_timestamp");
        });

        // User Configuration
        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("users");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Username).IsRequired().HasMaxLength(100);
            entity.HasIndex(e => e.Username).IsUnique();
        });

        // AuditLog Configuration
        modelBuilder.Entity<AuditLog>(entity =>
        {
            entity.ToTable("audit_logs");
            entity.HasKey(e => e.Id);
        });

        // Project Configuration
        modelBuilder.Entity<Project>(entity =>
        {
            entity.ToTable("projects");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Title).IsRequired().HasMaxLength(200);
            entity.Property(e => e.CustomerName).HasColumnName("customer_name");
            entity.Property(e => e.LcatPositionTitle).HasColumnName("lcat_position_title");
            entity.Property(e => e.ProjectStartDate).HasColumnName("project_start_date");
            entity.Property(e => e.ProjectDuration).HasColumnName("project_duration");
            entity.Property(e => e.ProjectBillRate).HasColumnName("project_bill_rate").HasPrecision(18, 2);
            entity.Property(e => e.ProjectReportingManager).HasColumnName("project_reporting_manager");
            entity.Property(e => e.ProjectRecruiter).HasColumnName("project_recruiter");
        });

        // ReportingManager Configuration
        modelBuilder.Entity<ReportingManager>(entity =>
        {
            entity.ToTable("reporting_managers");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Title).IsRequired().HasMaxLength(200);
            entity.Property(e => e.ReportingManagerEmailId).HasColumnName("reporting_manager_emailid");
            entity.Property(e => e.ReportingManagerNumber).HasColumnName("reporting_manager_number");
        });
    }
}
