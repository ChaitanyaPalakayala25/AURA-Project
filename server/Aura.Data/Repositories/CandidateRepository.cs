using Aura.Core.Entities;
using Aura.Core.Interfaces;
using Aura.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Aura.Data.Repositories;

public class CandidateRepository : GenericRepository<CandidateData>, ICandidateRepository
{
    public CandidateRepository(AuraDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<CandidateData>> GetActiveOnboardingsAsync()
    {
        return await _context.Candidates
            .Where(c => c.Status != "Completed" && c.Status != "Archived")
            .ToListAsync();
    }
}
