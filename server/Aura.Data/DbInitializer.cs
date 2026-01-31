using Aura.Core.Entities;
using Aura.Data.Context;

namespace Aura.Data;

public static class DbInitializer
{
    public static void Seed(AuraDbContext context)
    {
        context.Database.EnsureCreated();

        if (context.Candidates.Any()) return;

        var candidates = new List<CandidateData>
        {
            new CandidateData 
            { 
                Title = "John Doe (Recruiter Review)", 
                Status = "Recruiter Review",
                RecruiterName = "Sarah Smith",
                OnboardYear = 2026,
                OnboardMonth = "January"
            },
            new CandidateData 
            { 
                Title = "Jane Smith (Manager Approval)", 
                Status = "Manager Approval",
                RecruiterTimestamp = DateTime.UtcNow.AddDays(-2),
                RecruiterName = "Sarah Smith",
                ReportingManager = "Michael Scott"
            },
            new CandidateData 
            { 
                Title = "Robert Brown (HR Verification)", 
                Status = "HR Verification",
                RecruiterTimestamp = DateTime.UtcNow.AddDays(-5),
                ManagerTimestamp = DateTime.UtcNow.AddDays(-3),
                ReportingManager = "Michael Scott"
            },
            new CandidateData 
            { 
                Title = "Emily White (IT Provisioning)", 
                Status = "IT Provisioning",
                RecruiterTimestamp = DateTime.UtcNow.AddDays(-7),
                ManagerTimestamp = DateTime.UtcNow.AddDays(-5),
                HrTimestamp = DateTime.UtcNow.AddDays(-2)
            },
            new CandidateData 
            { 
                Title = "David Black (Completed)", 
                Status = "Completed",
                RecruiterTimestamp = DateTime.UtcNow.AddDays(-10),
                ManagerTimestamp = DateTime.UtcNow.AddDays(-8),
                HrTimestamp = DateTime.UtcNow.AddDays(-5),
                ItTimestamp = DateTime.UtcNow.AddDays(-3),
                AuditTimestamp = DateTime.UtcNow.AddDays(-1)
            }
        };

        context.Candidates.AddRange(candidates);
        context.SaveChanges();
    }
}
