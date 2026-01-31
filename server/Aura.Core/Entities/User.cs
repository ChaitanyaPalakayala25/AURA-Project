using System.ComponentModel.DataAnnotations;

namespace Aura.Core.Entities;

public class User : BaseEntity
{
    [Required]
    [MaxLength(100)]
    public string Username { get; set; } = string.Empty;

    [Required]
    public string PasswordHash { get; set; } = string.Empty;

    [Required]
    public string Role { get; set; } = "User"; // Admin, Recruiter, Manager, HR, IT, Audit

    [MaxLength(100)]
    public string FullName { get; set; } = string.Empty;

    public string? Email { get; set; }
}
