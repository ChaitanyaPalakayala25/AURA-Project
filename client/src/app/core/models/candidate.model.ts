export interface Candidate {
    id: number;
    title: string;
    status?: string;
    navitasEmailId?: string;
    candidateDesignation?: string;
    contactDetails?: string;
    personalEmailId?: string;
    location?: string;
    region?: string;
    experienceInYears?: number;
    workAuthorization?: string;
    employeeType?: string;
    technicalSkillsSet?: string;
    certifications?: string;
    projectName?: string;
    projectStartDate?: Date;
    projectDuration?: string;
    billRate?: number;
    recruiterName?: string;
    reportingManager?: string;
    securityClearance?: string;
    onboardYear?: number;
    onboardMonth?: string;

    // Recruiter Checklist
    resumeCollection?: boolean;
    passportCopy?: boolean;
    h1bApprovalCopy?: boolean;
    recruiterTimestamp?: Date;

    // HR Checklist
    hrDesignation?: string;
    hrWorkAuthorization?: string;
    backgroundVerificationStatus?: string;
    payrollSetupStatus?: boolean;
    orientationCompleted?: boolean;
    hrTimestamp?: Date;

    // IT Checklist
    vpnAccess?: boolean;
    sharedFolderAccess?: boolean;
    sharepointAccess?: boolean;
    laptopIssued?: boolean;
    laptopSerialNumber?: string;
    distroEmailCreated?: boolean;
    itTimestamp?: Date;

    // Audit Checklist
    msaSigned?: boolean;
    workOrderReceived?: boolean;
    coiReceived?: boolean;
    backgroundInvestigationStatus?: string;
    vendorSetupApproval?: boolean;
    auditTimestamp?: Date;

    // PCT Checklist
    vendorSetupInUnanet?: boolean;
    resourceSetupInUnanet?: boolean;
    projectAssignmentToResource?: boolean;
    billingCodesSetup?: boolean;
    pctTimestamp?: Date;
    managerTimestamp?: Date;
}
