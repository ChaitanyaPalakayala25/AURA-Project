using System.ComponentModel.DataAnnotations;

namespace Aura.Core.Entities;

public class ReportingManager : BaseEntity
{
    [Required]
    [MaxLength(200)]
    public string Title { get; set; } = string.Empty;

    public string? ReportingManagerEmailId { get; set; }

    public string? ReportingManagerNumber { get; set; }
}
