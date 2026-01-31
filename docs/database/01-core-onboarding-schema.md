# Core Onboarding Database Schema – AURA

## Overview
This document defines the primary tables involved in the candidate onboarding lifecycle.

---

## 1. Candidate_data

**Purpose**  
Stores active onboarding records from recruiter initiation through onboarding completion.

**Primary Key**
- ID

**Key Fields**
| Column | Description |
|------|------------|
| Title | Candidate full name |
| Status | Current onboarding status |
| navitas_email_id | Company email |
| candidate_designation | Job title |
| contact_details | Mobile number |
| personal_email_id | Personal email |
| location | Work location |
| region | Geographic region |
| experience_in_years | Total experience |
| work_authorization | Visa / work permit |
| employee_type | Contract / Full-time |
| technical_skills_set | Skill summary |
| certifications | Certifications |
| project_name | Assigned project |
| project_start_date | Start date |
| project_duration | Duration |
| bill_rate | Client bill rate |
| recruiter_name | Recruiter owner |
| reporting_manager | Reporting manager |
| security_clearance | Clearance level |
| onboard_year | Year onboarded |
| onboard_month | Month onboarded |

---

## 2. archived_data

**Purpose**  
Stores historical onboarding records for auditing and reporting.

**Notes**
- Mirrors Candidate_data
- Records are immutable
- Used only for reporting and compliance

---

## 3. bench_candidates

**Purpose**  
Stores candidates who are onboarded but not assigned to a project.

**Notes**
- Linked to Candidate_data by candidate ID
- Excluded from active billing
