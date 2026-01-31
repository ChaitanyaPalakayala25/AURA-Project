# User & Access Management Schema – AURA

## Overview
Defines authentication, authorization, and system access tracking.

---

## 1. aura_users

**Purpose**  
Manages system users and role-based access.

**Primary Key**
- ID

**Key Fields**
| Column | Description |
|------|------------|
| full_name | User full name |
| user_name | Login username |
| password | Encrypted password |
| otp | One-time password |
| is_recruiter | Recruiter role |
| is_reporting_manager | Reporting Manager role |
| is_hr_team | HR role |
| is_contracts_team | Contracts role |
| is_audit_team | Audit role |
| is_project_control_team | PCT role |
| is_itsupport | IT Support |
| is_admin | Admin access |

---

## 2. it_checklist

**Purpose**  
Tracks IT provisioning tasks per candidate.

**Key Fields**
| Column | Description |
|------|------------|
| candidate_id | Linked candidate |
| navitas_email_id | Email created |
| vpn_access | VPN enabled |
| shared_folder | Folder access |
| sharepoint_access | SharePoint access |
| laptop_setup | Laptop issued |
| laptop_series_no | Asset number |
| distro_email | Distribution list |
