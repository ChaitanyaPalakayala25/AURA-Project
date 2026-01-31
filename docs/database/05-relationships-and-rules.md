# Database Relationships & Rules – AURA

## Key Relationships

| Parent Table | Child Table | Relationship |
|-------------|-------------|--------------|
| Candidate_data | recruiter_checklist | One-to-One |
| Candidate_data | hr_checklist | One-to-One |
| Candidate_data | audit_team_checklist | One-to-One |
| Candidate_data | project_control_team_checklist | One-to-One |
| Candidate_data | it_checklist | One-to-One |
| customers | projects | One-to-Many |
| projects | Candidate_data | One-to-Many |

---

## Business Rules

1. A candidate must exist before any checklist record is created.
2. Archived candidates cannot be modified.
3. Role-based access is enforced via aura_users flags.
4. Status transitions are sequential and controlled by API.
5. Audit completion is mandatory before onboarding completion.

---

## EF Core Guidelines

- One DbSet per table
- Fluent API for relationships
- No cascade delete on Candidate_data
- Use enums for Status fields
