using Aura.Core.Entities;

namespace Aura.Core.Interfaces;

public interface ICandidateRepository : IGenericRepository<CandidateData>
{
    Task<IEnumerable<CandidateData>> GetActiveOnboardingsAsync();
}
