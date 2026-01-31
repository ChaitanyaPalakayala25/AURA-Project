# Master Data Schema – AURA

## Overview
Contains reference and lookup tables.

---

## 1. customers

**Purpose**
Stores customer master records.

**Fields**
- Title
- customer_type
- customer_poc
- customer_mobilenumber
- customer_email
- MSA
- work_order

---

## 2. projects

**Purpose**
Stores project master data.

**Fields**
- Title
- customer_name
- lcat_position_title
- location
- project_start_date
- project_duration
- project_bill_rate
- project_reporting_manager
- project_recruiter

---

## 3. regions

**Purpose**
Lookup table for regions.

---

## 4. certificate

**Purpose**
Lookup table for certifications.

---

## 5. reporting_managers

**Purpose**
Stores reporting manager contact details.

**Fields**
- Title
- reporting_manager_emailid
- reporting_manager_number
