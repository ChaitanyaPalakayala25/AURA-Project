using System.ComponentModel.DataAnnotations;

namespace Aura.Core.Entities;

public class CandidateData : BaseEntity
{
    [Required]
    [MaxLength(200)]
    public string Title { get; set; } = string.Empty;

    public string? Status { get; set; }

    public string? NavitasEmailId { get; set; }

    public string? CandidateDesignation { get; set; }

    public string? ContactDetails { get; set; }

    public string? PersonalEmailId { get; set; }

    public string? Location { get; set; }

    public string? Region { get; set; }

    public decimal? ExperienceInYears { get; set; }

    public string? WorkAuthorization { get; set; }

    public string? EmployeeType { get; set; }

    public string? TechnicalSkillsSet { get; set; }

    public string? Certifications { get; set; }

    public string? ProjectName { get; set; }

    public DateTime? ProjectStartDate { get; set; }

    public string? ProjectDuration { get; set; }

    public decimal? BillRate { get; set; }

    public string? RecruiterName { get; set; }

    public string? ReportingManager { get; set; }

    public string? SecurityClearance { get; set; }

    public int? OnboardYear { get; set; }

    public string? OnboardMonth { get; set; }

    // Recruiter Checklist
    public bool? ResumeCollection { get; set; }
    public bool? PassportCopy { get; set; }
    public bool? H1bApprovalCopy { get; set; }
    public DateTime? RecruiterTimestamp { get; set; }

    // HR Checklist
    public string? HrDesignation { get; set; }
    public string? HrWorkAuthorization { get; set; }
    public string? BackgroundVerificationStatus { get; set; }
    public bool? PayrollSetupStatus { get; set; }
    public bool? OrientationCompleted { get; set; }
    public DateTime? HrTimestamp { get; set; }

    // IT Checklist
    public bool? VpnAccess { get; set; }
    public bool? SharedFolderAccess { get; set; }
    public bool? SharepointAccess { get; set; }
    public bool? LaptopIssued { get; set; }
    public string? LaptopSerialNumber { get; set; }
    public bool? DistroEmailCreated { get; set; }
    public DateTime? ItTimestamp { get; set; }

    // Audit Checklist
    public bool? MsaSigned { get; set; }
    public bool? WorkOrderReceived { get; set; }
    public bool? CoiReceived { get; set; }
    public string? BackgroundInvestigationStatus { get; set; }
    public bool? VendorSetupApproval { get; set; }
    public DateTime? AuditTimestamp { get; set; }

    // PCT Checklist
    public bool? VendorSetupInUnanet { get; set; }
    public bool? ResourceSetupInUnanet { get; set; }
    public bool? ProjectAssignmentToResource { get; set; }
    public bool? BillingCodesSetup { get; set; }
    public DateTime? PctTimestamp { get; set; }
    
    // Manager Gate
    public DateTime? ManagerTimestamp { get; set; }
}
