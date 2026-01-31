using System.ComponentModel.DataAnnotations;

namespace Aura.Core.Entities;

public class AuditLog : BaseEntity
{
    [Required]
    public int CandidateId { get; set; }

    [Required]
    public string Action { get; set; } = string.Empty; // e.g., "Updated IT Timestamp"

    [Required]
    public string PerformedBy { get; set; } = string.Empty; // Username

    public DateTime Timestamp { get; set; } = DateTime.UtcNow;

    public string? Details { get; set; }
}
