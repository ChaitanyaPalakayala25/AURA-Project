using System.ComponentModel.DataAnnotations;

namespace Aura.Core.Entities;

public class Project : BaseEntity
{
    [Required]
    [MaxLength(200)]
    public string Title { get; set; } = string.Empty;

    public string? CustomerName { get; set; }

    public string? LcatPositionTitle { get; set; }

    public string? Location { get; set; }

    public DateTime? ProjectStartDate { get; set; }

    public string? ProjectDuration { get; set; }

    public decimal? ProjectBillRate { get; set; }

    public string? ProjectReportingManager { get; set; }

    public string? ProjectRecruiter { get; set; }
}
