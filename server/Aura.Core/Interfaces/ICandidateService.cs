using Aura.Core.DTOs;

namespace Aura.Core.Interfaces;

public interface ICandidateService
{
    Task<IEnumerable<CandidateDTO>> GetAllCandidatesAsync();
    Task<CandidateDTO?> GetCandidateByIdAsync(int id);
    Task<IEnumerable<CandidateDTO>> GetActiveOnboardingsAsync();
    Task<CandidateDTO> CreateCandidateAsync(CandidateDTO candidateDto);
    Task<bool> UpdateCandidateAsync(int id, CandidateDTO candidateDto);
    Task<bool> DeleteCandidateAsync(int id);
}
