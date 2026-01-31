# AURA Project - User Guide

AURA is an automated onboarding and offboarding management system designed to streamline the transition for new candidates across multiple corporate departments.

## 🛠 Role-Based Instructions

### 🔸 Recruiter
- **Access**: Full access to initiate onboarding.
- **Tasks**: Collect initial documents (Resume, Passport), set project details, and sign off the first gate.
- **Dashboard**: Sees all active candidates; can click **"Initiate Onboarding"**.

### 🔸 Manager (RM)
- **Access**: Work Queue view.
- **Tasks**: Review project assignments and approve/reject the candidate after the recruiter's sign-off.
- **Dashboard**: Automatically filtered to candidates in **"Manager Approval"** status.

### 🔸 HR Desk
- **Access**: Work Queue view.
- **Tasks**: Completion of background verification, payroll setup, and orientation.
- **Dashboard**: Automatically filtered to candidates in **"HR Verification"** status.

### 🔸 IT Provisioning
- **Access**: Work Queue view.
- **Tasks**: Provision VPN, shared folders, laptop issuance, and email creation.
- **Dashboard**: Automatically filtered to candidates in **"IT Provisioning"** status.

### 🔸 Audit & Compliance
- **Access**: View-only audit history.
- **Tasks**: Verify document integrity and vendor setups.
- **Dashboard**: Sees candidates in **"Audit Finalization"** status.

---

## 📈 Workflow Legend

The progress bar at the top of the candidate form indicates the current "Gate":

- **Gate 1 (Recruiter)**: Candidate data is being collected.
- **Gate 2 (Manager)**: Awaiting project and reporting manager approval.
- **Gate 3 (HR)**: Human Resources setup and background checks.
- **Gate 4 (IT)**: Technical assets and access provisioning.
- **Gate 5 (Completed)**: Candidate is fully onboarded and active.

---

## ❓ Troubleshooting

### 🔑 Login Issues
- Ensure you are using the correct credentials provided by the Admin.
- If you receive a **"Forbid"** error, your role may not have permission to view that specific page or update that specific timestamp.

### 📁 Document Uploads
- Attachments are stored in Azure Blob Storage. Ensure your internet connection is stable during uploads.
- Maximum file size: 10MB.

### 🔄 Status Not Updating
- Status transitions are sequential. Gate 4 (IT) cannot be signed off until Gate 3 (HR) is completed. Ensure all preceding timestamps are set.

---

## 🚀 Quick Start for Stakeholders
To demonstrate the workflow, use the **Dashboard Stat Cards** to quickly jump to candidates in different phases of onboarding.
