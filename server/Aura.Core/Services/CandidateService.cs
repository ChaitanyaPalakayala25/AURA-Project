using Aura.Core.DTOs;
using Aura.Core.Entities;
using Aura.Core.Interfaces;

namespace Aura.Core.Services;

public class CandidateService : ICandidateService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly INotificationService _notificationService;

    public CandidateService(IUnitOfWork unitOfWork, INotificationService notificationService)
    {
        _unitOfWork = unitOfWork;
        _notificationService = notificationService;
    }

    public async Task<IEnumerable<CandidateDTO>> GetAllCandidatesAsync()
    {
        var candidates = await _unitOfWork.Candidates.GetAllAsync();
        return candidates.Select(MapToDto);
    }

    public async Task<CandidateDTO?> GetCandidateByIdAsync(int id)
    {
        var candidate = await _unitOfWork.Candidates.GetByIdAsync(id);
        return candidate != null ? MapToDto(candidate) : null;
    }

    public async Task<IEnumerable<CandidateDTO>> GetActiveOnboardingsAsync()
    {
        var candidates = await _unitOfWork.Candidates.GetActiveOnboardingsAsync();
        return candidates.Select(MapToDto);
    }

    public async Task<CandidateDTO> CreateCandidateAsync(CandidateDTO candidateDto)
    {
        var candidate = MapToEntity(candidateDto);
        candidate.Status = "Recruiter Review";
        await _unitOfWork.Candidates.AddAsync(candidate);
        await _unitOfWork.CompleteAsync();
        
        await _notificationService.SendEmailAsync("recruiter@aura.com", "New Candidate", $"Candidate {candidate.Title} assigned to you.");
        
        return MapToDto(candidate);
    }

    public async Task<bool> UpdateCandidateAsync(int id, CandidateDTO candidateDto)
    {
        var existingCandidate = await _unitOfWork.Candidates.GetByIdAsync(id);
        if (existingCandidate == null) return false;

        // Apply transition logic and validation
        if (!ValidateTransition(existingCandidate, candidateDto))
        {
            throw new InvalidOperationException("Invalid workflow step transition.");
        }

        // Update fields (excluding Id)
        UpdateEntityFromDto(existingCandidate, candidateDto);

        // Auto-update status based on timestamps
        UpdateStatusBasedOnTimestamps(existingCandidate);

        _unitOfWork.Candidates.Update(existingCandidate);
        await _unitOfWork.CompleteAsync();
        return true;
    }

    public async Task<bool> DeleteCandidateAsync(int id)
    {
        var candidate = await _unitOfWork.Candidates.GetByIdAsync(id);
        if (candidate == null) return false;

        _unitOfWork.Candidates.Remove(candidate);
        await _unitOfWork.CompleteAsync();
        return true;
    }

    private bool ValidateTransition(CandidateData existing, CandidateDTO dto)
    {
        // Manager cannot sign off until Recruiter is done
        if (dto.ManagerTimestamp.HasValue && !existing.RecruiterTimestamp.HasValue && !dto.RecruiterTimestamp.HasValue) return false;
        
        // HR cannot sign off until Manager approved
        if (dto.HrTimestamp.HasValue && !existing.ManagerTimestamp.HasValue && !dto.ManagerTimestamp.HasValue) return false;

        // IT cannot sign off until HR is done
        if (dto.ItTimestamp.HasValue && !existing.HrTimestamp.HasValue && !dto.HrTimestamp.HasValue) return false;

        // Audit cannot sign off until IT is done (as per general rule)
        if (dto.AuditTimestamp.HasValue && !existing.ItTimestamp.HasValue && !dto.ItTimestamp.HasValue) return false;

        return true;
    }

    private void UpdateStatusBasedOnTimestamps(CandidateData candidate)
    {
        if (candidate.AuditTimestamp.HasValue)
        {
            candidate.Status = "Completed";
        }
        else if (candidate.ItTimestamp.HasValue)
        {
            candidate.Status = "Audit Finalization";
        }
        else if (candidate.HrTimestamp.HasValue)
        {
            candidate.Status = "IT Provisioning";
        }
        else if (candidate.ManagerTimestamp.HasValue)
        {
            candidate.Status = "HR Verification";
        }
        else if (candidate.RecruiterTimestamp.HasValue)
        {
            candidate.Status = "Manager Approval";
        }
    }

    private void UpdateEntityFromDto(CandidateData entity, CandidateDTO dto)
    {
        entity.Title = dto.Title;
        entity.NavitasEmailId = dto.NavitasEmailId;
        entity.CandidateDesignation = dto.CandidateDesignation;
        entity.ContactDetails = dto.ContactDetails;
        entity.PersonalEmailId = dto.PersonalEmailId;
        entity.Location = dto.Location;
        entity.Region = dto.Region;
        entity.ExperienceInYears = dto.ExperienceInYears;
        entity.WorkAuthorization = dto.WorkAuthorization;
        entity.EmployeeType = dto.EmployeeType;
        entity.TechnicalSkillsSet = dto.TechnicalSkillsSet;
        entity.Certifications = dto.Certifications;
        entity.ProjectName = dto.ProjectName;
        entity.ProjectStartDate = dto.ProjectStartDate;
        entity.ProjectDuration = dto.ProjectDuration;
        entity.BillRate = dto.BillRate;
        entity.RecruiterName = dto.RecruiterName;
        entity.ReportingManager = dto.ReportingManager;
        entity.SecurityClearance = dto.SecurityClearance;
        entity.OnboardYear = dto.OnboardYear;
        entity.OnboardMonth = dto.OnboardMonth;

        entity.ResumeCollection = dto.ResumeCollection;
        entity.PassportCopy = dto.PassportCopy;
        entity.H1bApprovalCopy = dto.H1bApprovalCopy;
        entity.RecruiterTimestamp = dto.RecruiterTimestamp;

        entity.HrDesignation = dto.HrDesignation;
        entity.HrWorkAuthorization = dto.HrWorkAuthorization;
        entity.BackgroundVerificationStatus = dto.BackgroundVerificationStatus;
        entity.PayrollSetupStatus = dto.PayrollSetupStatus;
        entity.OrientationCompleted = dto.OrientationCompleted;
        entity.HrTimestamp = dto.HrTimestamp;

        entity.VpnAccess = dto.VpnAccess;
        entity.SharedFolderAccess = dto.SharedFolderAccess;
        entity.SharepointAccess = dto.SharepointAccess;
        entity.LaptopIssued = dto.LaptopIssued;
        entity.LaptopSerialNumber = dto.LaptopSerialNumber;
        entity.DistroEmailCreated = dto.DistroEmailCreated;
        entity.ItTimestamp = dto.ItTimestamp;

        entity.MsaSigned = dto.MsaSigned;
        entity.WorkOrderReceived = dto.WorkOrderReceived;
        entity.CoiReceived = dto.CoiReceived;
        entity.BackgroundInvestigationStatus = dto.BackgroundInvestigationStatus;
        entity.VendorSetupApproval = dto.VendorSetupApproval;
        entity.AuditTimestamp = dto.AuditTimestamp;

        entity.VendorSetupInUnanet = dto.VendorSetupInUnanet;
        entity.ResourceSetupInUnanet = dto.ResourceSetupInUnanet;
        entity.ProjectAssignmentToResource = dto.ProjectAssignmentToResource;
        entity.BillingCodesSetup = dto.BillingCodesSetup;
        entity.PctTimestamp = dto.PctTimestamp;

        entity.ManagerTimestamp = dto.ManagerTimestamp;
    }

    private CandidateDTO MapToDto(CandidateData entity)
    {
        return new CandidateDTO
        {
            Id = entity.Id,
            Title = entity.Title,
            Status = entity.Status,
            NavitasEmailId = entity.NavitasEmailId,
            CandidateDesignation = entity.CandidateDesignation,
            ContactDetails = entity.ContactDetails,
            PersonalEmailId = entity.PersonalEmailId,
            Location = entity.Location,
            Region = entity.Region,
            ExperienceInYears = entity.ExperienceInYears,
            WorkAuthorization = entity.WorkAuthorization,
            EmployeeType = entity.EmployeeType,
            TechnicalSkillsSet = entity.TechnicalSkillsSet,
            Certifications = entity.Certifications,
            ProjectName = entity.ProjectName,
            ProjectStartDate = entity.ProjectStartDate,
            ProjectDuration = entity.ProjectDuration,
            BillRate = entity.BillRate,
            RecruiterName = entity.RecruiterName,
            ReportingManager = entity.ReportingManager,
            SecurityClearance = entity.SecurityClearance,
            OnboardYear = entity.OnboardYear,
            OnboardMonth = entity.OnboardMonth,
            ResumeCollection = entity.ResumeCollection,
            PassportCopy = entity.PassportCopy,
            H1bApprovalCopy = entity.H1bApprovalCopy,
            RecruiterTimestamp = entity.RecruiterTimestamp,
            HrDesignation = entity.HrDesignation,
            HrWorkAuthorization = entity.HrWorkAuthorization,
            BackgroundVerificationStatus = entity.BackgroundVerificationStatus,
            PayrollSetupStatus = entity.PayrollSetupStatus,
            OrientationCompleted = entity.OrientationCompleted,
            HrTimestamp = entity.HrTimestamp,
            VpnAccess = entity.VpnAccess,
            SharedFolderAccess = entity.SharedFolderAccess,
            SharepointAccess = entity.SharepointAccess,
            LaptopIssued = entity.LaptopIssued,
            LaptopSerialNumber = entity.LaptopSerialNumber,
            DistroEmailCreated = entity.DistroEmailCreated,
            ItTimestamp = entity.ItTimestamp,
            MsaSigned = entity.MsaSigned,
            WorkOrderReceived = entity.WorkOrderReceived,
            CoiReceived = entity.CoiReceived,
            BackgroundInvestigationStatus = entity.BackgroundInvestigationStatus,
            VendorSetupApproval = entity.VendorSetupApproval,
            AuditTimestamp = entity.AuditTimestamp,
            VendorSetupInUnanet = entity.VendorSetupInUnanet,
            ResourceSetupInUnanet = entity.ResourceSetupInUnanet,
            ProjectAssignmentToResource = entity.ProjectAssignmentToResource,
            BillingCodesSetup = entity.BillingCodesSetup,
            PctTimestamp = entity.PctTimestamp,
            ManagerTimestamp = entity.ManagerTimestamp
        };
    }

    private CandidateData MapToEntity(CandidateDTO dto)
    {
        var entity = new CandidateData();
        UpdateEntityFromDto(entity, dto);
        return entity;
    }
}
