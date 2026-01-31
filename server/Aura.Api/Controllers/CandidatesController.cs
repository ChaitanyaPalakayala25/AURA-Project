using Aura.Core.DTOs;
using Aura.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Aura.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class CandidatesController : ControllerBase
{
    private readonly ICandidateService _candidateService;

    public CandidatesController(ICandidateService candidateService)
    {
        _candidateService = candidateService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CandidateDTO>>> GetAll()
    {
        var candidates = await _candidateService.GetAllCandidatesAsync();
        return Ok(candidates);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CandidateDTO>> GetById(int id)
    {
        var candidate = await _candidateService.GetCandidateByIdAsync(id);
        if (candidate == null) return NotFound();
        return Ok(candidate);
    }

    [HttpGet("active")]
    public async Task<ActionResult<IEnumerable<CandidateDTO>>> GetActive()
    {
        var candidates = await _candidateService.GetActiveOnboardingsAsync();
        return Ok(candidates);
    }

    [HttpPost]
    [Authorize(Roles = "Admin,Recruiter")]
    public async Task<ActionResult<CandidateDTO>> Create(CandidateDTO candidateDto)
    {
        var created = await _candidateService.CreateCandidateAsync(candidateDto);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, CandidateDTO candidateDto)
    {
        var result = await _candidateService.UpdateCandidateAsync(id, candidateDto);
        if (!result) return NotFound();
        return NoContent();
    }

    [HttpPatch("{id}/timestamp")]
    public async Task<IActionResult> UpdateTimestamp(int id, [FromBody] Dictionary<string, DateTime?> timestamps)
    {
        // For simplicity, we use the existing UpdateCandidateAsync or a new more granular method
        // But here we can check roles:
        var userRole = User.FindFirst(System.Security.Claims.ClaimTypes.Role)?.Value;
        
        // Example: Only IT role can update itTimestamp
        if (timestamps.ContainsKey("itTimestamp") && userRole != "IT" && userRole != "Admin")
        {
            return Forbid();
        }

        // Implementation would call service to update only specific fields
        // For now, let's assume the service handles granular updates
        // result = await _candidateService.UpdateTimestampsAsync(id, timestamps);
        
        return Ok();
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _candidateService.DeleteCandidateAsync(id);
        if (!result) return NotFound();
        return NoContent();
    }
}
